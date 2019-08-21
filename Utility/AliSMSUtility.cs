using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCLUtility
{
    /// <summary>
    /// 阿里云短信验证码
    /// </summary>
    public class AliSMSUtility
    {
        public static string GenCode(int count=4)
        {
            return $"{RandomUtility.GetRandom(count)}";
        }
        /// <summary>
        /// 发送阿里云短信
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="templateCode"></param>
        /// <param name="json"></param>
        public static void SendAcs(string mobile, string templateCode, string code, string outid)
        {
#if DEBUG
            return;
#endif

            if (string.IsNullOrEmpty(mobile))
            {
                throw new Exception("mobile不能为空");
            }
            if (string.IsNullOrEmpty(templateCode))
            {
                throw new Exception("templateCode不能为空");
            }
            string product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
            string domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            string accessKeyId = "LTAIA41RPgmMHT8G";//你的accessKeyId，参考本文档步骤2
            string accessKeySecret = "3Vm4aupHfj8gwj0fMf0CLm9s8tQLMO";//你的accessKeySecret，参考本文档步骤2

            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);
            // SingleSendSmsRequest request = new SingleSendSmsRequest();
            //初始化ascClient,暂时不支持多region（请勿修改）
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式，发送国际/港澳台消息时，接收号码格式为00+国际区号+号码，如“0085200000000”
                request.PhoneNumbers = mobile;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "天乐教育";
                //必填:短信模板-可在短信控制台中找到，发送国际/港澳台消息时，请使用国际/港澳台短信模版
                request.TemplateCode = templateCode;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                var codeData = new SMSCode(code);
                request.TemplateParam = JsonConvert.SerializeObject(codeData);// "{\"name\":\"Tom\",\"code\":\"123\"}";
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = outid;// "yourOutId";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                if (sendSmsResponse.BizId == null)
                    throw new ApplicationException(sendSmsResponse.Message);
                System.Console.WriteLine(sendSmsResponse.Message);
            }
            catch (ServerException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (ClientException ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
    public class SMSCode
    {

        public string code;

        public SMSCode(string code)
        {
            this.code = code;
        }
    }
}
