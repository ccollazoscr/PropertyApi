using MediatR;
using Property.Model.Dto;
using Property.Model.Model;

namespace Property.Application.Command
{
    public class UpdatePropertyCommand:IRequest<ResponseDto>
    {
        public PropertyBuilding Property { get; }
        public UpdatePropertyCommand(PropertyBuilding property)
        {
            Property = property;
        }
    }
}
