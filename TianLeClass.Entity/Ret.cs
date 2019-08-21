using CCLUtility;
using Common;
using System;

namespace TianLeClass.Entity
{
    public class Ret
    {
        public Ret(object data)
        {
            this.data = data;
            ret = (int)RetCode.SUCCESS;
            msg = EnumHelper.GetDes(RetCode.SUCCESS);
        }

        public int ret;
        public string msg;
        public object data;
    }
}
