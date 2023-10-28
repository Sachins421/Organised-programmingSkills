﻿using MediatR;
using Domain.Mapping.GlassRequestDto;
using Model.Data.Repositries;
using Model.Data.Wrapper;
using Domain.Mapping.Dto;
using Model.Data.Repositries.Setup;

namespace Service.GlassRequestCommand
{
    public class GlassRequestCommandHandler : IRequestHandler<ProcessBatchGlassRequestCommand, GlassRequestCommandResponse>
    {
        private readonly IProductionLineRepository _productionLineRepository;
        private readonly ISetupRepository _setupRepository;

        public GlassRequestCommandHandler(IProductionLineRepository productionLineRepository, ISetupRepository setupRepository)
        {
            _productionLineRepository = productionLineRepository;
            _setupRepository = setupRepository;
        }

        public async Task<GlassRequestCommandResponse> Handle(ProcessBatchGlassRequestCommand request, CancellationToken cancellationToken)
        {
            var setupData = _setupRepository.ReadSetupAsync();
            
            var glassRequestSBMessage = request.GlassRequestSBMessage;
            var idandListToken = await ProcessBatchGlassRequest(glassRequestSBMessage.ToList());
            return new GlassRequestCommandResponse
            {
                IdAndLockTokenList = idandListToken,
            };
        }


        private async Task<List<IdAndLockTocken>> ProcessBatchGlassRequest(List<GlassRequestSBMessage> message)
        {
            var glassLineToProcess = message.Select(co => new GlassRequestMessageWrapper()
            {
                ProductionLine = co.Data.GlassRequest.ToModel(),
                Id = new Model.Data.Repositries.Id  
                {
                    id = co.Data.GlassRequest.SourceInformation.Id,
                    LineNo = co.Data.GlassRequest.SourceInformation.LineNo,
                    SalesChannel = co.Data.GlassRequest.SourceInformation.SalesChannel,
                    SalesCountryISO = co.Data.GlassRequest.SourceInformation.SalesCountryISO
                },
                IsDuplicate = co.IsDuplicate,
                MessageId = co.id,
                EventDeliveryCount = co.DeliveryCount,
                EventMessageLockToken = co.LockToken,
                EventType = co.eventType
            }).ToList();

            var response = await _productionLineRepository.ProcessUpsertProductionLineAsync(glassLineToProcess);

            //faking response for now
            var res = response.idAndLockTockens.ToList();

            return res;
        }
    }
}
