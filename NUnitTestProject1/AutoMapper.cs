
using CCLUtility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    class A
    {
        public string na;
    }
    public class AutoMapper
    {
        [Test]
        public void TestAutoMapper()
        {
            var aa = new A
            {
                na = "aafa"
            };
            var b = aa.AutoMapping<A>();
            Console.WriteLine(b.na);
        }
    }
}
