using Microsoft.AspNetCore.Mvc;
using Service.Repositries;
using System.ComponentModel.DataAnnotations;
using Domain.Mapping.Dto.Dto;
using MediatR;
using Service.GlassRequestCommand;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GlassOrderAPI : ControllerBase
    {
        //private readonly ProductionLineRepository _productionLineRepository;
        private readonly IMediator _mediator;

        public GlassOrderAPI(IMediator mediator)
        {
            _mediator = mediator;
        }
        // POST: GlassOrderAPI/Create
        [HttpPost("CreateProductionLine")]
        public async Task<ActionResult> CreateProductionLineWithEvent([Required, FromBody] GlassRequestSBMessage glassRequestSBMessage, CancellationToken cancellationToken)
        {
            ProcessBatchGlassRequestCommand glassRequestCommandHandler = new ProcessBatchGlassRequestCommand
            {

                GlassRequestSBMessage = new List<GlassRequestSBMessage> //GlassRequestMessage is the defined in the ProcessBatchGlassRequestCommand class
                {
                    glassRequestSBMessage
                }
            };

            await _mediator.Send(glassRequestCommandHandler);   

            return Ok(glassRequestCommandHandler);
        }

    }
}
