using GreenProject.Backend.Core.Utils;
using System;
using System.Security.Cryptography;

namespace GreenProject.Backend.Infrastructure.PasswordHashing
{
    public class CspSaltGenerator : ISaltGenerator, IDisposable
    {
        private readonly RNGCryptoServiceProvider csp;

        public CspSaltGenerator()
        {
            csp = new RNGCryptoServiceProvider();
        }

        public void Dispose()
        {
            csp.Dispose();
        }

        public byte[] NewSalt(int length)
        {
            byte[] salt = new byte[length];
            csp.GetNonZeroBytes(salt);
            return salt;
        }
    }
}
