using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class CommonUtility
    {
        public static void CheckPage(int page, int pageSize)
        {
            if (page < 0 || pageSize < 0)
            {
                throw new RequestException(RetCode.ErrorPage);
            }
        }
    }
}
