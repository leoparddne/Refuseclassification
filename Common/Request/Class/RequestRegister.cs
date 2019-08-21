using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Request.Class
{
    public class RequestRegister
    {
        [Required(ErrorMessage = "UserNameNotNull")]
        public string username { get; set; }
        [Required(ErrorMessage = "PSWNotNull")]
        public string psw { get; set; }
        [Required(ErrorMessage = "PhoneNotNull")]
        public string phone { get; set; }
        [Required(ErrorMessage = "CodeNotNull")]
        public string code { get; set; }
    }
}
