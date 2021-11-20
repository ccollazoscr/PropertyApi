using MediatR;
using Property.Model.Dto;
using Property.Model.Model;


namespace Property.Application.Command
{
    public class CreatePropertyCommand : IRequest<CreatePropertyDto>
    {
        public PropertyBuilding Property { get; }
        public CreatePropertyCommand(PropertyBuilding property) {
            Property = property;
        }
    }
}
