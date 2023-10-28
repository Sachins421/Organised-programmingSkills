using MediatR;
using Model.Data.Repositries.ManufacturerSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ManufacturerCommand
{
    public class ManufacturerSetupHandler : IRequestHandler<ManufacturerSetupCommand, ManufacturerSetupResponse>
    {
        private readonly ManufacturerSetupRepository _manufacturerSetupRepository;

        public ManufacturerSetupHandler(ManufacturerSetupRepository manufacturerSetupRepository)
        {
            _manufacturerSetupRepository = manufacturerSetupRepository;
        }

        public Task<ManufacturerSetupResponse> Handle(ManufacturerSetupCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
