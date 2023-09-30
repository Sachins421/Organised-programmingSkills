using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping.Dto.SetupDto
{
    public class Combinations
    {
        public bool Disabled { get; set; }
        public string GlassGroupCode { get; set; }
        public int ParameterNo { get; set; }
        public GlassType GlassType { get; set; }
        public bool Tinged { get; set; }
        public bool PhotoTropic { get; set; }
        public bool Polarized { get; set; }
        public bool SingleVision { get; set; }
        public bool OfficeGlass { get; set; }
        public bool BlueFilter { get; set; }
        public bool MultiFocal { get; set; }
        public bool StandardTinge { get; set; }
        public bool Gradient { get; set; }
        public bool Filter { get; set; }

        public bool Mirrored { get; set; }
        public FieldofVision fieldofVision { get; set; }
        public bool AutoSelectionEnabled { get; set; }
        public List<Priorities> Priorities { get; set; }
    }
}
