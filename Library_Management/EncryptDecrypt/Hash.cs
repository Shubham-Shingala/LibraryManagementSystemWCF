using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Library_Management.EncryptDecrypt
{
    public class Hash
    {
        public static Encoding DefaultEncoding = Encoding.UTF8;
        public const HashType DefaultHashType = HashType.SHA256;

        public static string Get(string text, HashType hashType = DefaultHashType, Encoding encoding = null)
        {
            switch (hashType)
            {
                case HashType.MD5:
                    return Get(text, new MD5CryptoServiceProvider(), encoding);
                case HashType.SHA1:
                    return Get(text, new SHA1Managed(), encoding);
                case HashType.SHA256:
                    return Get(text, new SHA256Managed(), encoding);
                case HashType.SHA512:
                    return Get(text, new SHA512Managed(), encoding);
                default:
                    throw new ArgumentOutOfRangeException($"HASH Algorithm not found this method: {nameof(Get)}");
            }
        }

        public static string Get(string text, HashAlgorithm algorithm, Encoding encoding = null)
        {
            byte[] message = encoding == null ? DefaultEncoding.GetBytes(text) : encoding.GetBytes(text);
            byte[] hashValue = algorithm.ComputeHash(message);

            return hashValue.Aggregate(string.Empty, (current, x) => current + $"{x:x2}");
        }

        public static bool Compare(string original, string hashString, HashType hashType = DefaultHashType, Encoding encoding = null)
        {
            string originalHash = Get(original, hashType, encoding);

            return originalHash == hashString;
        }
        public static bool Compare(string original, string salt, string hashString, HashType hashType = DefaultHashType, Encoding encoding = null)
        {
            return Compare(original + salt, hashString, hashType, encoding);
        }
    }
}