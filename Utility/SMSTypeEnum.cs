using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace CCLUtility
{
    public enum SMSTypeEnum
    {
        /// <summary>
        /// 注册
        /// </summary>
        [Description("SMS_168106052")]
        ClassRegister,
        /// <summary>
        /// 登录
        /// </summary>
        [Description("SMS_168106054")]
        ClassLogin,
        /// <summary>
        /// 修改密码
        /// </summary>
        [Description("SMS_168106051")]
        FrogetPSW,
    }
}
