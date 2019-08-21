using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CCLUtility
{
    public static class RegUtility
    {
        /// <summary>
        /// 手机号码验证
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool PhoneCheck(string phone)
        {
            var pattern = "^1[3-9][0-9]{9}$";
            return Regex.IsMatch(phone, pattern);
        }
        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="psw"></param>
        /// <returns></returns>
        public static bool PSWCheck(string psw)
        {
            if (string.IsNullOrEmpty(psw))
                return false;
            if (psw.Trim().Length < 6&&psw.Trim().Length>16)
                return false;
            return true;
        }
    }
}