using FruitRacers.Backend.Core.Utils;
using System.Security.Cryptography;

namespace FruitRacers.Backend.Infrastructure.PasswordHashing
{
    public class Pbkdf2Hashing : IHashCalculator
    {
        private const int HASH_ITERATIONS = 10000;
        private const int HASH_LENGTH = 128;

        public byte[] Hash(string password, byte[] salt)
        {
            using (Rfc2898DeriveBytes hashCalc = new Rfc2898DeriveBytes(password, salt, HASH_ITERATIONS))
            {
                return hashCalc.GetBytes(HASH_LENGTH);
            }
        }
    }
}
