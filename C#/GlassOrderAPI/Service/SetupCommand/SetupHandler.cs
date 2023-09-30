using Domain.Mapping.Dto.SetupDto;
using MediatR;
using Model.Data.Repositries.Setup;
using Model.Data.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.SetupCommand
{
    public class SetupHandler : IRequestHandler<SetupRequestCommand,SetuRequestResponse>
    {
        private readonly ISetupRepository _repository;
        public SetupHandler(ISetupRepository setupRepository) 
        {
            _repository = setupRepository;
        }

        public async Task<SetuRequestResponse> Handle(SetupRequestCommand request, CancellationToken cancellationToken)
        {
            var setup = request.SetupData.ToModel();
            var res = await _repository.CreateSetupAsync(setup);
            var r = new SetuRequestResponse
            {
                IdAndLockTocken = res.IdAndLockTocken
            };

            return r;
        }
    }
}
