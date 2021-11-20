using MediatR;
using Property.Application.Port;
using Property.Model.Dto;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Query
{
    public class GetListPropertyQueryHandler : IRequestHandler<GetListPropertyQuery, List<GetListPropertyDto>>
    {
        private IPropertyFinderPort _propertyFinderPort;
        public GetListPropertyQueryHandler(IPropertyFinderPort propertyFinderPort) {
            _propertyFinderPort = propertyFinderPort;
        }
        public Task<List<GetListPropertyDto>> Handle(GetListPropertyQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult( _propertyFinderPort.GetListProperty(request.Property));
        }
    }
}
