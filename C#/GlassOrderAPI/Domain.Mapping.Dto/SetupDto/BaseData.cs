using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class BaseData
    {
        public bool OutsourcedProductionEnabled { get; set; }
        public bool AutoGlassSelectionActivated { get; set; }
        public bool SkipOrdershavingWrshCmt { get; set; }
        public int FirstChoiceARCode { get; set; }
        public int SecondChoiceARCode { get; set; }
       
    }
}
