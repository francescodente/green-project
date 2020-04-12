using GreenProject.Backend.Contracts.Authentication;
using GreenProject.Backend.Core.Entities.Extensions;
using GreenProject.Backend.Core.Utils;
using GreenProject.Backend.Entities;
using GreenProject.Backend.Shared.Utils;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Authentication
{
    public class JwtAuthentication : IAuthenticationHandler
    {
        private const int HASH_LENGTH = 128;

        private readonly IHashCalculator hashCalculator;
        private readonly ISaltGenerator saltGenerator;
        private readonly IStringEncoding encoding;
        private readonly AuthenticationSettings settings;

        public JwtAuthentication(IHashCalculator hashCalculator,
                                 ISaltGenerator saltGenerator,
                                 IStringEncoding encoding,
                                 AuthenticationSettings settings)
        {
            this.hashCalculator = hashCalculator;
            this.saltGenerator = saltGenerator;
            this.encoding = encoding;
            this.settings = settings;
        }

        public void AssignPassword(User user, string password)
        {
            byte[] salt = this.saltGenerator.NewSalt(HASH_LENGTH);
            byte[] passwordHash = this.hashCalculator.Hash(password, salt, HASH_LENGTH);

            user.Password = this.encoding.BytesToString(passwordHash);
            user.Salt = this.encoding.BytesToString(salt);
        }

        public bool IsPasswordCorrect(User user, string password)
        {
            byte[] salt = this.encoding.StringToBytes(user.Salt);
            byte[] expectedHash = this.encoding.StringToBytes(user.Password);
            byte[] actualHash = this.hashCalculator.Hash(password, salt, HASH_LENGTH);

            return CompareSlow(expectedHash, actualHash);
        }

        private bool CompareSlow(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i];
            }

            return result == 0;
        }

        public Task<AuthenticationResultDto> OnUserAuthenticated(User user)
        {
            byte[] key = Encoding.ASCII.GetBytes(this.settings.SecretKey);
            IEnumerable<Claim> claims = CreateClaimsList(user);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.Add(this.settings.TokenDuration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            AuthenticationResultDto result = new AuthenticationResultDto
            {
                UserId = user.UserId,
                Token = tokenHandler.WriteToken(token),
                Expiration = tokenDescriptor.Expires.Value
            };

            return Task.FromResult(result);
        }

        private IEnumerable<Claim> CreateClaimsList(User user)
        {
            return user.GetRoleTypes()
                .Select(CreateRoleClaim)
                .Append(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
        }

        private Claim CreateRoleClaim(RoleType role)
        {
            return new Claim(ClaimTypes.Role, role.ToString());
        }

        public Task OnUserLoggedOut(User user)
        {
            return Task.CompletedTask;
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
    }
}
