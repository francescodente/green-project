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

        private readonly IHashCalculator hashCalculator;
        private readonly ISaltGenerator saltGenerator;
        private readonly IStringEncoding encoding;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IDateTime dateTime;
        private readonly AuthenticationSettings settings;
        private readonly TokenValidationParameters refreshValidation;

        public JwtAuthentication(IDateTime dateTime,
                                 IHashCalculator hashCalculator,
                                 ISaltGenerator saltGenerator,
                                 IStringEncoding encoding,
                                 IHttpContextAccessor httpContextAccessor,
                                 AuthenticationSettings settings,
                                 TokenValidationParameters tokenValidationParameters)
        {
            this.dateTime = dateTime;
            this.hashCalculator = hashCalculator;
            this.saltGenerator = saltGenerator;
            this.encoding = encoding;
            this.httpContextAccessor = httpContextAccessor;
            this.settings = settings;
            this.refreshValidation = tokenValidationParameters.Clone();
            this.refreshValidation.ValidateLifetime = false;
        }

        public void AssignPassword(User user, string password)
        {
            byte[] salt = this.saltGenerator.NewSalt(HashLength);
            byte[] passwordHash = this.hashCalculator.Hash(password, salt, HashLength);

            user.Password = this.encoding.BytesToString(passwordHash);
            user.Salt = this.encoding.BytesToString(salt);
        }

        public bool IsPasswordCorrect(User user, string password)
        {
            byte[] salt = this.encoding.StringToBytes(user.Salt);
            byte[] expectedHash = this.encoding.StringToBytes(user.Password);
            byte[] actualHash = this.hashCalculator.Hash(password, salt, HashLength);

            return expectedHash.SequenceEqual(actualHash);
        }

        public (AuthenticationResult, RefreshToken) OnUserAuthenticated(User user)
        {
            SecurityTokenDescriptor tokenDescriptor = this.GenerateTokenDescriptor(user);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            RefreshToken refreshToken = new RefreshToken
            {
                AccessTokenId = token.Id,
                User = user,
                Token = Guid.NewGuid().ToString(),
                CreationDate = this.dateTime.Now,
                Expiration = this.dateTime.Now.Add(this.settings.RefreshTokenDuration)
            };

            this.SetRefreshTokenCookie(refreshToken);

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
                HttpOnly = this.settings.CookieSettings.HttpOnly,
                Secure = this.settings.CookieSettings.Secure,
                Path = this.settings.CookieSettings.Path,
                MaxAge = this.settings.RefreshTokenDuration
            };

            this.httpContextAccessor
                .HttpContext
                .Response
                .Cookies
                .Append(RefreshTokenCookieName, refreshToken.Token, cookieOptions);
        }

        private SecurityTokenDescriptor GenerateTokenDescriptor(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(this.settings.SecretKey);
            IEnumerable<Claim> claims = CreateClaimsList(user);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = this.dateTime.Now,
                Expires = this.dateTime.Now.Add(this.settings.TokenDuration),
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
            if (this.httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(RefreshTokenCookieName, out string refreshToken))
            {
                return Optional.Of(refreshToken);
            }
            return Optional.Empty<string>();
        }

        public string GenerateRandomPassword()
        {
            string chars = this.settings.PasswordGeneration.AllowedCharacters;
            RandomNumberGenerator crypto = RandomNumberGenerator.Create();

            byte[] data = new byte[this.settings.PasswordGeneration.Length];
            crypto.GetBytes(data);

            return data
                .Select(b => b % chars.Length)
                .Select(b => chars[b])
                .ConcatStrings();
        }

        public bool CanBeRefreshed(string accessToken, RefreshToken refreshToken)
        {
            return this.GetPrincipalFromToken(accessToken)
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
                    refreshValidation,
                    out SecurityToken validatedToken);

                if (!this.IsJwtWithValidSecurityAlgorithm(validatedToken))
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
    }
}
