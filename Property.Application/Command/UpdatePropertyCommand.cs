using MediatR;
using Property.Application.Dto;
using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
