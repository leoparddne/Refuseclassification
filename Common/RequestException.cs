using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class RequestException:Exception
    {
        public Enum e;
        public RequestException(Enum e)
        {
            this.e = e;
        }
    }
}
