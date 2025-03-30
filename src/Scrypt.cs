using Scrypt;

namespace Hashers
{
    public static class Scrypt
    {
        /// <summary>
        /// Hash a password using Scrypt
        /// </summary>
        public static string HashPassword(string password, int iterations = 16384, int blockSize = 8, int threadCount = 4)
        {
            var encoder = new ScryptEncoder(iterations, blockSize, threadCount);
            return encoder.Encode(password);
        }

        /// <summary>
        /// Verify if the hashed password is equal to the processed one
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassowrd, int iterations = 16384, int blockSize = 8, int threadCount = 1)
        {
            var encoder = new ScryptEncoder(iterations, blockSize, threadCount);
            return encoder.Compare(password, hashedPassowrd);
        }
    }
}