using System;
using System.Collections.Generic;
using System.Text;

namespace CCLUtility
{
    public static class RandomUtility
    {
        public static char GetRandom()
        {
            return (char)(new Random().Next()%10+'0');
        }
        /// <summary>
        /// 获取数量的随机验证码
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetRandom(int count)
        {
            var result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(GetRandom());
            }
            return result.ToString();
        }
    }
}
