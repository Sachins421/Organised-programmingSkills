using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Wrapper
{
    public class SetupResponseWrapper : MessageResponseWrapper
    {
        public IdAndLockTocken IdAndLockTocken { get; set; }
    }
}
