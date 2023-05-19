namespace Hashers
{
    public static class BCrypt
    {
        /// <summary>
        /// Hash a password using BCrypt
        /// </summary>
        public static string HashPassword(string password, int costFactor = 12)
        {
            return global::BCrypt.Net.BCrypt.HashPassword(password, costFactor);
        }

        /// <summary>
        /// Verify if the hashed password is equal to the processed one
        /// </summary>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return global::BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}