using Repository.Entity.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entity
{
    public class record: tianleClassEntityBase
    {
        /// <summary>
        /// 类型id
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string name { get; set; }
        public long count { get; set; }
    }
}
