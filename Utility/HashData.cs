using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain.Utility
{
    public class HashData
    {
        public static byte [] ComputeHashSha256(byte[] toBeHashed)
        {
            using(var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(toBeHashed);
            }
        }

        public static string GetHash(string toBeHashed,string key)
        {
            var keyToUse = Encoding.UTF8.GetBytes(key);
            var message = Encoding.UTF8.GetBytes(toBeHashed);

            using (var hmac = new HMACSHA256(keyToUse))
            {
                return Convert.ToBase64String(hmac.ComputeHash(message));
            }
            
        }


    }
}
