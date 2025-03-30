﻿using System.Security.Cryptography;
using System.Text;

namespace Hashers
{
    public class Sha256
    {
        /// <summary>
        /// Hash a password using SHA256
        /// </summary>
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var encodedBytes = Encoding.Unicode.GetBytes(password);
                var bytes = sha256.ComputeHash(encodedBytes);

                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Verify if the hashed password is equal to the processed one
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword) => HashPassword(password) == hashedPassword;
    }
}