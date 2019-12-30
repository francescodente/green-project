using FruitRacers.Backend.Core.Utils;
using System;
using System.Security.Cryptography;

namespace FruitRacers.Backend.Infrastructure.PasswordHashing
{
    public class CspSaltGenerator : ISaltGenerator, IDisposable
    {
        private const int SALT_LENGTH = 128;
        private readonly RNGCryptoServiceProvider csp;

        public CspSaltGenerator()
        {
            csp = new RNGCryptoServiceProvider();
        }

        public void Dispose()
        {
            csp.Dispose();
        }

        public byte[] NewSalt()
        {
            byte[] salt = new byte[SALT_LENGTH];
            csp.GetNonZeroBytes(salt);
            return salt;
        }
    }
}
