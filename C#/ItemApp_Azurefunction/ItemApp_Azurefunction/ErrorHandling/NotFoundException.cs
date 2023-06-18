using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.ErrorHandling
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException() : base("Not found") { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, System.Exception inner) : base(message, inner) { }

        protected NotFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        //public string? Id { get; set; }

        //public string? No { get; set; }

        //public string? ItemName { get; set; }

        //public string? Quantity { get; set; }

        //public decimal? Price { get; set; }
    }
}
