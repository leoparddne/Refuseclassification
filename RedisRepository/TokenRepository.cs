using CCLUtility;
using Common;
using StackExchange.Redis;
using System;

namespace RedisRepository
{
    public class TokenRepository : Respository, IDisposable
    {
        static TokenRepository instance;

        private TokenRepository():base(RedisConst.TokenDB)
        {
        }

        public static TokenRepository GetInstance()
        {
            lock(typeof(TokenRepository))
            {
                if (instance == null)
                {
                    instance = new TokenRepository();
                }
            }
            return instance;
        }
        /// <summary>
        /// 获取用户token
        /// </summary>
        /// <param name="phone">手机号码</param>
        /// <param name="prefix">手机号前缀</param>
        /// <returns></returns>
        public string AndAndUpdateToken(string phone)
        {
            var token = TmpTokenUtility.GenToken(phone);
            try
            {
                //过期删除
                TimeSpan span = new TimeSpan(0, 0, 0, 20);
                db.StringSet(token, phone);
                db.KeyExpire(token, span);
            }
            catch (Exception)
            {
                Log.Err(EnumHelper.GetDes(RetCode.TokenError));
                throw new RequestException(RetCode.TokenError);
            }
            return token;
        }
        public void RemoveToken(string phone,string token)
        {
            var data = db.StringGet(token);
            if (!data.IsNullOrEmpty)
            {
                if (data == phone)
                {
                    db.KeyDelete(token);
                }
                else
                {
                    throw new RequestException(RetCode.TokenError);
                }
            }
            else
            {
                throw new RequestException(RetCode.TokenError);
            }
        }
        public void CheckToken(string token)
        {
            if(db.StringGet(token).IsNullOrEmpty)
            {
                Log.Err(EnumHelper.GetDes(RetCode.TokenError));
                throw new RequestException(RetCode.TokenError);
            }
        }
    }
}
