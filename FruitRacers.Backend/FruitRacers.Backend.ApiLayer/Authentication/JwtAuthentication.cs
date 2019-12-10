using FruitRacers.Backend.Contracts.Authentication;
using FruitRacers.Backend.Core.Entities;
using FruitRacers.Backend.Core.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FruitRacers.Backend.ApiLayer.Authentication
{
    public class JwtAuthentication : IAuthenticationHandler
    {
        private readonly IHashCalculator hashCalculator;
        private readonly ISaltGenerator saltGenerator;
        private readonly IStringEncoding encoding;
        private readonly AuthenticationSettings settings;

        public JwtAuthentication(IHashCalculator hashCalculator,
                                 ISaltGenerator saltGenerator,
                                 IStringEncoding encoding,
                                 IOptions<AuthenticationSettings> settings)
        {
            this.hashCalculator = hashCalculator;
            this.saltGenerator = saltGenerator;
            this.encoding = encoding;
            this.settings = settings.Value;
        }

        public void AssignPassword(User user, string password)
        {
            byte[] salt = this.saltGenerator.NewSalt();
            byte[] passwordHash = this.hashCalculator.Hash(password, salt);

            user.Password = this.encoding.BytesToString(passwordHash);
            user.Salt = this.encoding.BytesToString(salt);
        }

        public bool IsPasswordCorrect(User user, string password)
        {
            byte[] salt = this.encoding.StringToBytes(user.Salt);
            byte[] expectedHash = this.encoding.StringToBytes(user.Password);
            byte[] actualHash = this.hashCalculator.Hash(password, salt);

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
            return Enumerable.Concat(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
                },
                this.GetUserRoles(user).Select(CreateRoleClaim)
            );
        }

        private IEnumerable<UserRole> GetUserRoles(User user)
        {
            if (user.Person != null)
            {
                yield return UserRole.Person;
            }
            if (user.CustomerBusiness != null)
            {
                yield return UserRole.CustomerBusiness;
            }
            if (user.Supplier != null)
            {
                yield return UserRole.Supplier;
            }
            if (user.Administrator != null)
            {
                yield return UserRole.Administrator;
            }
            if (user.DeliveryCompany != null)
            {
                yield return UserRole.DeliveryCompany;
            }
        }

        private Claim CreateRoleClaim(UserRole role)
        {
            return new Claim(ClaimTypes.Role, role.ToString());
        }

        public Task OnUserLoggedOut(User user)
        {
            return Task.CompletedTask;
        }
    }
}
