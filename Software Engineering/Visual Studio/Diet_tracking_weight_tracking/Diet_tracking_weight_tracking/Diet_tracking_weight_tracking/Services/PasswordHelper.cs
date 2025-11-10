using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Diet_tracking_weight_tracking.Services
{
    /// <summary>
    /// Helper class for secure password hashing and verification using PBKDF2
    /// </summary>
    public static class PasswordHelper
    {
        private const int SaltSize = 16; // 16 bytes
        private const int KeySize = 32; // 32 bytes
        private const int Iterations = 100_000; // 100,000 iterations for security

        /// <summary>
        /// Hash a password using PBKDF2 with a random salt
        /// </summary>
        /// <param name="password">Plain text password to hash</param>
        /// <returns>Base64 encoded string containing salt and hash separated by colon</returns>
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            // Generate a random salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                // Generate the hash
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    byte[] hash = pbkdf2.GetBytes(KeySize);

                    // Combine salt and hash with separator
                    return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
                }
            }
        }

        /// <summary>
        /// Verify a password against its stored hash
        /// </summary>
        /// <param name="password">Plain text password to verify</param>
        /// <param name="storedHash">Stored hash in format "salt:hash"</param>
        /// <returns>True if password matches, false otherwise</returns>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            if (string.IsNullOrEmpty(storedHash))
                return false;

            try
            {
                // Split the stored hash into salt and hash parts
                var parts = storedHash.Split(':');
                if (parts.Length != 2)
                    return false;

                byte[] salt = Convert.FromBase64String(parts[0]);
                byte[] storedHashBytes = Convert.FromBase64String(parts[1]);

                // Generate hash from provided password with stored salt
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    byte[] testHash = pbkdf2.GetBytes(KeySize);

                    // Compare the hashes in a timing-safe manner
                    return SlowEquals(storedHashBytes, testHash);
                }
            }
            catch (Exception)
            {
                // Invalid format or other error
                return false;
            }
        }

        /// <summary>
        /// Compares two byte arrays in length-constant time to prevent timing attacks
        /// </summary>
        /// <param name="a">First byte array</param>
        /// <param name="b">Second byte array</param>
        /// <returns>True if arrays are equal, false otherwise</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            uint diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }

            return diff == 0;
        }

        /// <summary>
        /// Validates password strength (basic requirements)
        /// </summary>
        /// <param name="password">Password to validate</param>
        /// <returns>True if password meets minimum requirements</returns>
        public static bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            // Minimum requirements: at least 6 characters
            return password.Length >= 6;
        }

        /// <summary>
        /// Gets password strength requirements as a user-friendly string
        /// </summary>
        /// <returns>String describing password requirements</returns>
        public static string GetPasswordRequirements()
        {
            return "Password must be at least 6 characters long.";
        }
    }
}