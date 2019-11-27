using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FruitRacers.Backend.Core.Utils
{
    public class CspSaltGenerator : ISaltGenerator, IDisposable
    {
        private const int SALT_LENGTH = 128;
        private readonly RNGCryptoServiceProvider csp;

        public CspSaltGenerator()
        {
            this.csp = new RNGCryptoServiceProvider();
        }

        public void Dispose()
        {
            this.csp.Dispose();
        }

        public byte[] NewSalt()
        {
            byte[] salt = new byte[SALT_LENGTH];
            this.csp.GetNonZeroBytes(salt);
            return salt;
        }
    }
}
