using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto
{
    public class SourceInformation
    {
        public string Id { get; set; }

        public string SalesChannel { get; set; }

        public string SalesCountryISO { get; set; }

        public string SalesLanguage { get; set; }
        public string SalesChannelERP { get; set; }

        public string LineNo { get; set; }

        public string Company { get; set; }
    }
}
