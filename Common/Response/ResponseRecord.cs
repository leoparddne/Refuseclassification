using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Response
{
    public class ResponseRecord
    {
        public int id { get; set; }
        /// <summary>
        /// 类型id
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string name { get; set; }
        public string typeName { get; set; }
    }
}
