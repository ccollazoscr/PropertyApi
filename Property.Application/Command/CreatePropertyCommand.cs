using MediatR;
using Property.Model.Model;


namespace Property.Application.Command
{
    public class CreatePropertyCommand : IRequest<PropertyBuilding>
    {
        public PropertyBuilding Property { get; }
    }
}
