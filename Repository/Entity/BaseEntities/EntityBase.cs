using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Entity
{
    public class EntityBase
    {
        [Key]
        public int id { get; set; }
        public int state { get; set; }
    }
}
