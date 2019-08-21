using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class RetPagedData:Ret
    {
        public RetPagedData(object data,int page, int pageSize,int total): base(data)
        {
            this.data = data;
            this.page = page;
            this.pageSize = pageSize;
            this.total = total;
        }
        public int page;
        public int pageSize;
        public int total;
    }
}
