using GreenProject.Backend.Core.EntitiesExtensions;
using GreenProject.Backend.Core.Utils.Authentication;
using GreenProject.Backend.Core.Utils.PasswordHashing;
using GreenProject.Backend.Core.Utils.Time;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GreenProject.Backend.ApiLayer.Authentication
{
    public class JwtAuthentication : IAuthenticationHandler
    {
        private const int HashLength = 128;
        private const string RefreshTokenCookieName = "refresh_token";

        private readonly IHashCalculator _hashCalculator;
        private readonly ISaltGenerator _saltGenerator;
        private readonly IStringEncoding _encoding;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDateTime _dateTime;
        private readonly AuthenticationSettings _settings;
        private readonly TokenValidationParameters _refreshValidation;

        public JwtAuthentication(IDateTime dateTime,
                                 IHashCalculator hashCalculator,
                                 ISaltGenerator saltGenerator,
                                 IStringEncoding encoding,
                                 IHttpContextAccessor httpContextAccessor,
                                 AuthenticationSettings settings,
                                 TokenValidationParameters tokenValidationParameters)
        {
            _dateTime = dateTime;
            _hashCalculator = hashCalculator;
            _saltGenerator = saltGenerator;
            _encoding = encoding;
            _httpContextAccessor = httpContextAccessor;
            _settings = settings;
            _refreshValidation = tokenValidationParameters.Clone();
            _refreshValidation.ValidateLifetime = false;
        }

        public void AssignPassword(User user, string password)
        {
            byte[] salt = _saltGenerator.NewSalt(HashLength);
            byte[] passwordHash = _hashCalculator.Hash(password, salt, HashLength);

            user.Password = _encoding.BytesToString(passwordHash);
            user.Salt = _encoding.BytesToString(salt);
        }

        public bool IsPasswordCorrect(User user, string password)
        {
            byte[] salt = _encoding.StringToBytes(user.Salt);
            byte[] expectedHash = _encoding.StringToBytes(user.Password);
            byte[] actualHash = _hashCalculator.Hash(password, salt, HashLength);

            return expectedHash.SequenceEqual(actualHash);
        }

        public (AuthenticationResult, RefreshToken) OnUserAuthenticated(User user)
        {
            SecurityTokenDescriptor tokenDescriptor = GenerateTokenDescriptor(user);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            RefreshToken refreshToken = new RefreshToken
            {
                AccessTokenId = token.Id,
                User = user,
                Token = Guid.NewGuid().ToString(),
                CreationDate = _dateTime.Now,
                Expiration = _dateTime.Now.Add(_settings.RefreshTokenDuration)
            };

            SetRefreshTokenCookie(refreshToken);

            AuthenticationResult result = new AuthenticationResult
            {
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token,
                Expiration = tokenDescriptor.Expires.Value
            };

            return (result, refreshToken);
        }

        private void SetRefreshTokenCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new CookieOptions
            {
                HttpOnly = _settings.CookieSettings.HttpOnly,
                Secure = _settings.CookieSettings.Secure,
                Path = _settings.CookieSettings.Path,
                MaxAge = _settings.RefreshTokenDuration
            };

            _httpContextAccessor
                .HttpContext
                .Response
                .Cookies
                .Append(RefreshTokenCookieName, refreshToken.Token, cookieOptions);
        }

        private SecurityTokenDescriptor GenerateTokenDescriptor(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_settings.SecretKey);
            IEnumerable<Claim> claims = CreateClaimsList(user);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = _dateTime.Now,
                Expires = _dateTime.Now.Add(_settings.TokenDuration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return tokenDescriptor;
        }

        private IEnumerable<Claim> CreateClaimsList(User user)
        {
            return user.GetRoleTypes()
                .Select(CreateRoleClaim)
                .Append(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()))
                .Append(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
        }

        private Claim CreateRoleClaim(RoleType role)
        {
            return new Claim(ClaimTypes.Role, role.ToString());
        }

        public IOptional<string> FindCurrentRefreshToken()
        {
            if (_httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(RefreshTokenCookieName, out string refreshToken))
            {
                return Optional.Of(refreshToken);
            }
            return Optional.Empty<string>();
        }

        public string GenerateRandomPassword()
        {
            string chars = _settings.PasswordGeneration.AllowedCharacters;
            RandomNumberGenerator crypto = RandomNumberGenerator.Create();

            byte[] data = new byte[_settings.PasswordGeneration.Length];
            crypto.GetBytes(data);

            return data
                .Select(b => b % chars.Length)
                .Select(b => chars[b])
                .ConcatStrings();
        }

        public bool CanBeRefreshed(string accessToken, RefreshToken refreshToken)
        {
            return GetPrincipalFromToken(accessToken)
                .Filter(p => refreshToken.AccessTokenId == p.FindFirstValue(JwtRegisteredClaimNames.Jti))
                .IsPresent();
        }

        private IOptional<ClaimsPrincipal> GetPrincipalFromToken(string accessToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                ClaimsPrincipal principal = tokenHandler.ValidateToken(
                    accessToken,
                    _refreshValidation,
                    out SecurityToken validatedToken);

                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return Optional.Empty<ClaimsPrincipal>();
                }

                return Optional.Of(principal);
            }
            catch
            {
                return Optional.Empty<ClaimsPrincipal>();
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            if (!(validatedToken is JwtSecurityToken jwtSecurityToken))
            {
                return false;
            }
            return jwtSecurityToken
                .Header
                .Alg
                .Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }

        public ConfirmationToken NewConfirmationToken()
        {
            return new ConfirmationToken
            {
                Token = Guid.NewGuid().ToString(),
                CreationDate = _dateTime.Now,
                Expiration = _dateTime.Now.Add(_settings.ConfirmationTokenDuration)
            };
        }

        public PasswordRecoveryToken NewPasswordRecoveryToken()
        {
            return new PasswordRecoveryToken
            {
                Token = Guid.NewGuid().ToString(),
                CreationDate = _dateTime.Now,
                Expiration = _dateTime.Now.Add(_settings.PasswordRecoveryTokenDuration)
            };
        }
    }
}
