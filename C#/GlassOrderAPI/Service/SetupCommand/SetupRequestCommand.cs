using Domain.Mapping.Dto.SetupDto;
using MediatR;

namespace Service.SetupCommand
{
    public class SetupRequestCommand : IRequest<SetuRequestResponse>
    {
        public SetupData SetupData { get; set; }
    }
}
