using System;
using System.ComponentModel;

namespace Common
{
    public enum RetCode
    {
        [Description("操作失败")]
        ERROR=0,

        [Description("操作成功")]
        SUCCESS=1,

        [Description("Token无效")]
        TokenError,

        [Description("验证码无效")]
        SmsCodeError,

        [Description("手机号码无效")]
        ErrorPhone,

        [Description("姓名不能为空")]
        NameNotNull,

        [Description("课程不能为空")]
        SubjectNotNull,

        [Description("年纪输入错误")]
        GradeError,

        [Description("记录已存在")]
        DataExist,

        [Description("页码传递错误")]
        ErrorPage,

        [Description("无数据")]
        NOData,

        [Description("用户不存在")]
        UserNotExist,

        [Description("角色不存在")]
        RoleNotExist,

        [Description("用户已存在")]
        UserExist,

        [Description("用户名密码不匹配")]
        PSWError,

        [Description("验证码类型无效")]
        SmsCodeTypeError,
    }
}
