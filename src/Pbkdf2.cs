using System.Security.Cryptography;

namespace Hashers
{
    public class Pbkdf2
    {
        /// <summary>
        /// Hash a password using pbkdf2
        /// </summary>
        public static string HashPassword(string password, int saltSize = 16, int hashSize = 32, int iterations = 10000)
        {
            // Random salt
            byte[] salt = RandomNumberGenerator.GetBytes(saltSize);

            // Derived password from PBKDF2, see https://www.rfc-editor.org/info/rfc2898
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(hashSize);

                // salt + hash in byte array
                byte[] hashBytes = new byte[saltSize + hashSize];
                Array.Copy(salt, 0, hashBytes, 0, saltSize);
                Array.Copy(hash, 0, hashBytes, saltSize, hashSize);

                // Retorn hashed password in 64 base
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// Verify if the hashed password is equal to the processed one
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword, int saltSize = 16, int hashSize = 32, int iterations = 10000)
        {
            // Convert the hashed password from Base64 to byte array
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Extract the salt from the hashBytes
            byte[] salt = new byte[saltSize];
            Array.Copy(hashBytes, 0, salt, 0, saltSize);

            // Generate a new hash using the provided password and extracted salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] newHash = pbkdf2.GetBytes(hashSize);

                // Compare the newly generated hash with the hashedPassword
                return newHash.SequenceEqual(hashBytes.Skip(saltSize));
            }
        }
    }
}