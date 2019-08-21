using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CCLUtility
{
    //TODO 使用ID4重写
    public class TmpTokenUtility
    {
        public static string GenToken(string phone,string prefix="")
        {
            var str = $"{prefix}{phone}{TimeUtility.GetCurrentMillUTC()}";
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(str));
                var strResult = BitConverter.ToString(result);
                return strResult.Replace("-", "");
            }
        }
    }
}
