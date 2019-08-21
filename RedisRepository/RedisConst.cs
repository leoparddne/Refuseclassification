using CCLUtility;
using DI;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisRepository
{
    public static class RedisConst
    {
        public static readonly string constr;
        static RedisConst()
        {
            var setting = DI.SettingUtility.Get<CommonSetting>("CommonSetting.json");
            constr = setting.Redis;
        }
        //public const string constr = "localhost:6379";
        /// <summary>
        /// 保存配置信息
        /// </summary>
        public const int ConfigDB = 0;
        /// <summary>
        /// 保存token
        /// </summary>
        public const int TokenDB = 1;

        /// <summary>
        /// 保存验证码
        /// </summary>
        public const int SMSCodeDB = 2;
    }
}
