using NUnit.Framework;
using RedisRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    class TokenTest
    {
        [Test]
        public void removeToken()
        {
            var token = TokenRepository.GetInstance();
            token.RemoveToken("13812071740","13812071740_SMS_168106052");
        }
    }
}
