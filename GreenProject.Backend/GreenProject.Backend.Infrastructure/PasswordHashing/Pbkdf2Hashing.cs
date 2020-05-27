using GreenProject.Backend.Core.Utils.PasswordHashing;
using System.Security.Cryptography;

namespace GreenProject.Backend.Infrastructure.PasswordHashing
{
    public class Pbkdf2Hashing : IHashCalculator
    {
        private const int HashIterations = 10000;

        public byte[] Hash(string password, byte[] salt, int length)
        {
            using (var hashCalc = new Rfc2898DeriveBytes(password, salt, HashIterations))
            {
                return hashCalc.GetBytes(length);
            }
        }
    }
}
