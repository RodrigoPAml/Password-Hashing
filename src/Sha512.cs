using System.Security.Cryptography;
using System.Text;

namespace Hashers
{
    public class Sha512
    {
        /// <summary>
        /// Hash a password using SHA512
        /// </summary>
        public static string HashPassword(string password)
        {
            using (var sha512 = SHA512.Create())
            {
                var encodedBytes = Encoding.Unicode.GetBytes(password);
                var bytes = sha512.ComputeHash(encodedBytes);

                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Verify if the hashed password is equal to the processed one
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword) => HashPassword(password) == hashedPassword;
    }
}