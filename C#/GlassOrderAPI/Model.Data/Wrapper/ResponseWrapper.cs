using Model.Data.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Wrapper
{
    public class ResponseWrapper
    {
       public List<IdAndLockTocken> idAndLockTockens { get; set; }

       // can be in a different class called MessageWrapper
      /* public Id Id { get; set; }

       public string MessageId { get; set; }

       public string EventMessageLockToken { get; set; }

       public bool IsDuplicate { get; set; }

       public int EventDeliveryCount { get; set; }*/

    }
}
