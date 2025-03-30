using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Hashers
{
    public class Argon2
    {
        /// <summary>
        /// Hash a password using Argon2
        /// </summary>
        public static string HashPassword(
            string password, 
            int saltSize = 16,
            int parallelism = 8, 
            int iterations = 4, 
            int memorySize = 1_048_576, 
            int hashSize = 32
        )
        {
            var argon2 = new Argon2id(Encoding.Unicode.GetBytes(password));

            argon2.Salt = RandomNumberGenerator.GetBytes(saltSize);
            argon2.DegreeOfParallelism = parallelism;
            argon2.Iterations = iterations;
            argon2.MemorySize = memorySize;

            // Salt + hash
            var result = argon2.Salt;
            result = result.Concat(argon2.GetBytes(hashSize)).ToArray();

            return Convert.ToBase64String(result); 
        }

        /// <summary>
        /// Verify if the hashed password is equal to the processed one
        /// </summary>
        public static bool VerifyPassword(
            string password, 
            string hashedPassword,
            int saltSize = 16,
            int parallelism = 8,
            int iterations = 4,
            int memorySize = 1_048_576)
        {
            // Convert the hashed password from base64 to byte array
            var bytes = Convert.FromBase64String(hashedPassword);

            // Hash the provided password using the extracted salt
            var hasher = new Argon2id(Encoding.Unicode.GetBytes(password))
            {
                Salt = bytes.Take(saltSize).ToArray(),
                DegreeOfParallelism = parallelism,
                Iterations = iterations, 
                MemorySize = memorySize
            };

            // Compare hashes withou salts
            var hash = hasher.GetBytes(bytes.Length-saltSize);
            return bytes.Skip(saltSize).SequenceEqual(hash);
        }
    }
}