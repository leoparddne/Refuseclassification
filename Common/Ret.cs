using CCLUtility;
using Common;
using System;

namespace Common
{
    public class Ret
    {
        public Ret()
        {
            ret = (int)RetCode.SUCCESS;
            msg = EnumHelper.GetDes(RetCode.SUCCESS);
        }
        public Ret(object data)
        {
            this.data = data;
            ret = (int)RetCode.SUCCESS;
            msg = EnumHelper.GetDes(RetCode.SUCCESS);
        }
        public Ret(RetCode code)
        {
            ret = (int)code;
            msg = EnumHelper.GetDes(code);
        }
        public Ret(RetCode code, string msg, object data)
        {
            this.ret = (int)code;
            this.msg = msg;
            this.data = data;
        }
        public int ret;
        public string msg;
        public object data;
    }
}
