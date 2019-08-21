using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CCLUtility
{
    public static class MD5Utility
    {
        public static string Encryption(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var fromData = Encoding.UTF8.GetBytes(input);
            var targetData = md5.ComputeHash(fromData);
            StringBuilder result = new StringBuilder();
            foreach (var item in targetData)
            {
                result.Append(item.ToString("x2"));
            }
            return result.ToString();
        }
    }
}
