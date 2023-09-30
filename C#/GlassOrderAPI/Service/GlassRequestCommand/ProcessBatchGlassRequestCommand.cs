using Domain.Mapping.GlassRequestDto;
using MediatR;

namespace Service.GlassRequestCommand
{
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Is instantiated via ASP.NET WebAPI and governed with Validators
    public class ProcessBatchGlassRequestCommand : IRequest<GlassRequestCommandResponse>
    {
        public List<GlassRequestSBMessage> GlassRequestSBMessage { get; set; }
    }
}
