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
        private IPropertyManager _propertyManager;
        private IPropertyFinder _propertyFinder;
        public CreatePropertyCommandHandler(IPropertyManager propertyManager, IPropertyFinder propertyFinder) {
            _propertyManager = propertyManager;
            _propertyFinder = propertyFinder;
        }

        public Task<PropertyBuilding> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            PropertyBuilding oPropertyBuilding = request.Property;

            //Validamos si la propiedad existe por el código
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
