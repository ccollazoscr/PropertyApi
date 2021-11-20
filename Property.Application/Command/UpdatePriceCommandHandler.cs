using MediatR;
using Property.Application.Port;
using Property.Model.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Command
{
    public class UpdatePriceCommandHandler : IRequestHandler<UpdatePriceCommand, ResponseDto>
    {
        IPropertyManagerPort _propertyManagerPort;
        public UpdatePriceCommandHandler(IPropertyManagerPort propertyManagerPort) {
            _propertyManagerPort = propertyManagerPort;
        }
        public Task<ResponseDto> Handle(UpdatePriceCommand request, CancellationToken cancellationToken)
        {
            ResponseDto oResponseDto = new ResponseDto();
            oResponseDto.Success = _propertyManagerPort.UpdatePrice(request.Id, request.Price);
            return Task.Run(() =>
            {
                return oResponseDto;
            }); ;
        }
    }
}
