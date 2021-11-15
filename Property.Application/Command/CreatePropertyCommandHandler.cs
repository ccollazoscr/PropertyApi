using MediatR;
using Property.Application.Port;
using Property.Common.Exception;
using Property.Model.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Command
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, PropertyBuilding>
    {
        private IPropertyManagerPort _propertyManager;
        private IPropertyFinderPort _propertyFinder;
        public CreatePropertyCommandHandler(IPropertyManagerPort propertyManager, IPropertyFinderPort propertyFinder) {
            _propertyManager = propertyManager;
            _propertyFinder = propertyFinder;
        }

        public Task<PropertyBuilding> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            PropertyBuilding oPropertyBuilding = request.Property;

            //Business validations
            if (_propertyFinder.ExistProperty(oPropertyBuilding.Code))
            {
                throw new CustomErrorException(EnumErrorCode.ExistCodeProperty);
            }

            long idProperty = _propertyManager.CreateProperty(oPropertyBuilding);
            oPropertyBuilding.Id = idProperty;

            return Task.Run(() =>
            {
                return oPropertyBuilding;
            }); 
        }
    }
}
