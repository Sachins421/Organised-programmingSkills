using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DatabaseSettings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string collection { get; set; }
    }
}
