using CCLUtility;
using NUnit.Framework;
using RedisRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    public class SMSTest
    {
        string redisCon = "localhost:6379";
        string phone = "13812071740";
        /// <summary>
        /// 生成验证码
        /// </summary>
        [Test]
        public void GenSMSCode()
        {
            var guid = Guid.NewGuid().ToString();
            Console.WriteLine(guid);
            //验证码
            var code = AliSMSUtility.GenCode();
            Console.WriteLine(code);
            //发送验证码
            //AliSMSUtility.SendAcs(phone, EnumHelper.GetDes(SMSTypeEnum.ClassRegister), code, $"{guid}_{code}");

            var codeService = SMSCodeRepository.GetInstance();
            //保存验证码到redis
            codeService.AddAndUpdate(phone, SMSTypeEnum.ClassRegister, code);
        }
        [Test]
        public void CheckSMSCode()
        {
            var phone = "13812071740";
            var code = "6155";
            var codeService = SMSCodeRepository.GetInstance();
            var result = codeService.CheckCode(phone, SMSTypeEnum.ClassRegister, code);
            Console.WriteLine(result);
        }
    }
}
