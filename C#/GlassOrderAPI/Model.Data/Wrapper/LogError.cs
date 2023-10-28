using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Wrapper
{
    public class LogError
    {
        public string ErrorCode;
        public string ErrorDescription;
        public LogError() { }

        public LogError(string errorCode, string errorDescription)
        {
            ErrorCode = errorCode;
            ErrorDescription = errorDescription;
        }
    }
}
