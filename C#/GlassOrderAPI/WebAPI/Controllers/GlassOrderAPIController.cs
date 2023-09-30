using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Domain.Mapping.GlassRequestDto;
using MediatR;
using Service.GlassRequestCommand;
using Service.Utilities.Helper;
using Service.Utilities.Response;
using Service.SetupCommand;
using Model.Data.Wrapper;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class GlassOrderAPIController : ControllerBase
    {
        //private readonly ProductionLineRepository _productionLineRepository;
        private readonly IMediator _mediator;

        public GlassOrderAPIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: GlassOrderAPI/Create
        [HttpPost("CreateProductionLine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<EventResponse>> CreateProductionLineWithEvent([Required, FromBody] GlassRequestSBMessage glassRequestSBMessage, CancellationToken cancellationToken)
        {
            ProcessBatchGlassRequestCommand glassRequestCommandHandler = new ProcessBatchGlassRequestCommand
            {

                GlassRequestSBMessage = new List<GlassRequestSBMessage> //GlassRequestMessage is the defined in the ProcessBatchGlassRequestCommand class
                {
                    glassRequestSBMessage   
                }
            };

            var response = await _mediator.Send(glassRequestCommandHandler);   

            return Ok(PrepareEventResponse.CreateEventResponse(response.IdAndLockTokenList));
        }

        // POST: GlassOrderAPI/Create
        [HttpPost("CreateSetupData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<EventResponse>> CreateSetupData([Required, FromBody] SetupRequestCommand setupRequestCommand, CancellationToken cancellationToken)
        {
      
            var response = await _mediator.Send(setupRequestCommand);

            var responseList = new List<IdAndLockTocken>();
            responseList.Add(response.IdAndLockTocken);

            return Ok(PrepareEventResponse.CreateEventResponse(responseList));
        }

    }
}
