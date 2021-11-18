using MediatR;
using Property.Application.Dto;
using Property.Application.Port;
using Property.Common.Exception;
using Property.Model.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Command
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, CreatePropertyDto>
    {
        private IPropertyManagerPort _propertyManager;
        private IPropertyFinderPort _propertyFinder;
        public CreatePropertyCommandHandler(IPropertyManagerPort propertyManager, IPropertyFinderPort propertyFinder) {
            _propertyManager = propertyManager;
            _propertyFinder = propertyFinder;
        }

        public Task<CreatePropertyDto> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            PropertyBuilding oPropertyBuilding = request.Property;

            //Business validations
            if (_propertyFinder.ExistProperty(oPropertyBuilding.Code))
            {
                throw new CustomErrorException(EnumErrorCode.ExistCodeProperty);
            }
            CreatePropertyDto oCreatePropertyDto = new CreatePropertyDto();
            oCreatePropertyDto.Id = _propertyManager.CreateProperty(oPropertyBuilding);

            return Task.Run(() =>
            {
                return oCreatePropertyDto;
            }); 
        }
    }
}
