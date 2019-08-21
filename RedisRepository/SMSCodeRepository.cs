using CCLUtility;
using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisRepository
{
    public class SMSCodeRepository : Respository,IDisposable
    {
        static SMSCodeRepository instance;
        private SMSCodeRepository() : base( RedisConst.SMSCodeDB)
        {

        }

        public static SMSCodeRepository GetInstance()
        {
            lock (typeof(SMSCodeRepository))
            {
                if (instance == null)
                {
                    instance = new SMSCodeRepository();
                }
            }
            return instance;
        }
        /// <summary>
        /// 新增验证码
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="type"></param>
        /// <param name=""></param>
        public void AddAndUpdate(string phone, SMSTypeEnum type,string code)
        {
            var key = $"{EnumHelper.GetDes(type)}_{phone}";
            db.StringSet(key, code);

            var timeSpan = new TimeSpan(0, 0, 1, 0);
            db.KeyExpire(key, timeSpan);
        }
        public void RemoveCode(string phone,SMSTypeEnum type)
        {
            var key = $"{EnumHelper.GetDes(type)}_{phone}";
            if (!db.StringGet(key).IsNullOrEmpty)
            {
                db.KeyDelete(key);
            }
        }
        public string GetCode(string phone, SMSTypeEnum type)
        {
            var key = $"{EnumHelper.GetDes(type)}_{phone}";
            if(db.StringGet(key).IsNullOrEmpty)
            {
                Log.Err(EnumHelper.GetDes(RetCode.SmsCodeError));
                throw new RequestException(RetCode.SmsCodeError);
            }
            return db.StringGet(key);
        }
        public bool CheckCode(string phone,SMSTypeEnum type,string SMSCode)
        {
            var code = GetCode(phone, type);
            if (!string.IsNullOrEmpty(SMSCode) && !string.IsNullOrEmpty(code))
            {
                if (code.Trim() == SMSCode.Trim())
                {
                    return true;
                }
            }
            return false;
        }
    }
}