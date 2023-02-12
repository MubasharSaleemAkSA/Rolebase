using System.Security.Cryptography;

namespace User.Helpers
{
    public class PasswordHasher
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static readonly int SaltSize = 16;
        private static readonly int hashSize = 20;
        private static readonly int Iterations = 1000;
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            rng.GetBytes(salt);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = key.GetBytes(hashSize);
            var hasBytes = new byte[SaltSize + hashSize];
            Array.Copy(salt, 0, hasBytes, 0, SaltSize);
            Array.Copy(hash, 0, hasBytes, SaltSize, hashSize);
            var base64Hash = Convert.ToBase64String(hasBytes);

            return base64Hash;
        }
        public static bool VerifyPassword(string password, string base64Hash)
        {
            var hashBytes = Convert.FromBase64String(base64Hash);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = key.GetBytes(hashSize);
            for (var i = 0; i < hashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])

                    return false;

            }

            return true;
        }
    }
}
