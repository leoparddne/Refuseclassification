using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TianLeClass.Entity.Request
{
    public class RequestLogin
    {
        [Required(ErrorMessage = "用户名不能为空")]
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string psw { get; set; }
    }
}
