using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.DatabaseSettings
{
    public class DBSettings 
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string Collection { get; set; }
    }
}
