using CCLUtility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NUnitTestProject1
{
    public class RegTest
    {
        [Test]
        public void phone()
        {
            var phone = "13812345678";
            Console.WriteLine(RegUtility.PhoneCheck(phone));
        }

        [Test]
        public void md5()
        {
            var input = "123456";
            var result = MD5Utility.Encryption(input);
            Console.WriteLine(result);
        }
    }
}
