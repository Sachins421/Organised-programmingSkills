using Model.Data.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ManufacturerCommand
{
    public class ManufacturerSetupResponse
    {
        public IdAndLockTocken idAndLockTocken { get; set; }

        public ManufacturerSetupResponse() { }
    }
}
