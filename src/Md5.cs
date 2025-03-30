using System.Security.Cryptography;
using System.Text;

namespace Hashers
{
    public class Md5
    {
        /// <summary>
        /// Hash a password using md5 considering an Unicode (UTF-16) password
        /// </summary>
        public static string HashPassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = Encoding.Unicode.GetBytes(password);
                var md5Bytes = md5.ComputeHash(bytes);

                return Convert.ToBase64String(md5Bytes);
            }
        }

        /// <summary>
        /// Verify if the hashed password is equal to the processed one
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassoword) => HashPassword(password) == hashedPassoword;   
    }
}