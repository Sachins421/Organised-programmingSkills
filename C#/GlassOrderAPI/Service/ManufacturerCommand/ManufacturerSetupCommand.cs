using Domain.Mapping.Dto.ManfacturerDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ManufacturerCommand
{
    public class ManufacturerSetupCommand : IRequest<ManufacturerSetupResponse>
    {
        public List<ManufacturerRequestSBMessage> manufacturerRequestSBMessage { get; set; }
    }
}
