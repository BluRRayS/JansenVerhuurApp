using System;
using System.Security.Cryptography;
using System.Text;

namespace Services.Helpers
{
    internal class Encryption
    {

        //Hashes data with the SHA512 encryption method.
        public string Hash(string rawData)
        {
            if (string.IsNullOrEmpty(rawData)) return null;
            using var sha512Hash = SHA512.Create();
            var bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            var builder = new StringBuilder();
            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }

        //Generates salt to be put in the password hash to create unique passwords.
        public string GenerateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            const int maxLength = 32;
            var salt = new byte[maxLength];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@";
            var res = new StringBuilder();
            var rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }
    }
}