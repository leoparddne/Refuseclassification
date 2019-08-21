using CCLUtility;
using NUnit.Framework;
using RedisRepository;
using System;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Redis()
        {
            var token = TokenRepository.GetInstance();
            token.CheckToken("9A1409EDD7B00F99817D6EA5B2E6526B");
        }
        [Test]
        public void AddToken()
        {
            var token = TokenRepository.GetInstance();
            token.AndAndUpdateToken("13812071740");
        }
        [Test]
        public void TokenGen()
        {
            var data = TmpTokenUtility.GenToken("13812071740");
            System.Console.WriteLine(data);
        }

        [Test]
        public void GenCode()
        {
            System.Console.WriteLine(AliSMSUtility.GenCode());
        }
    }
}