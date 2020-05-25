using GreenProject.Backend.Core.Utils.PasswordHashing;
using System;
using System.Security.Cryptography;

namespace GreenProject.Backend.Infrastructure.PasswordHashing
{
    public class CspSaltGenerator : ISaltGenerator, IDisposable
    {
        private readonly RNGCryptoServiceProvider _csp;

        public CspSaltGenerator()
        {
            _csp = new RNGCryptoServiceProvider();
        }

        public void Dispose()
        {
            _csp.Dispose();
        }

        public byte[] NewSalt(int length)
        {
            byte[] salt = new byte[length];
            _csp.GetNonZeroBytes(salt);
            return salt;
        }
    }
}
