using System;
using System.Collections.Generic;
using System.Text;

namespace TianLeClass.Entity
{
    public class RetPagedData:Ret
    {
        public RetPagedData(object data,int page, int pageSize): base(data)
        {
            this.page = page;
            this.pageSize = pageSize;
        }

        public int page;
        public int pageSize;
    }
}
