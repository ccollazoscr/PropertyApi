using MediatR;
using Property.Model.Dto;
using Property.Model.Model;
using System.Collections.Generic;

namespace Property.Application.Query
{
    public class GetListPropertyQuery : IRequest<List<GetListPropertyDto>>
    {
        public PropertyBuilding Property { get; }
        public GetListPropertyQuery(PropertyBuilding property)
        {
            Property = property;
        }
    }
}
