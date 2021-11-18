using MediatR;
using Property.Application.Dto;
using Property.Application.Port;
using Property.Common.Exception;
using Property.Model.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Command
{
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, ResponseDto>
    {
        private IPropertyManagerPort _propertyManager;
        private IPropertyFinderPort _propertyFinder;
        private IPropertyTraceManagerPort _propertyTraceManagerPort;
        public UpdatePropertyCommandHandler(IPropertyManagerPort propertyManager, IPropertyFinderPort propertyFinder, IPropertyTraceManagerPort propertyTraceManagerPort)
        {
            _propertyManager = propertyManager;
            _propertyFinder = propertyFinder;
            _propertyTraceManagerPort = propertyTraceManagerPort;
        }

        public Task<ResponseDto> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            ResponseDto oResponseDto = new ResponseDto() { Success = false };
            PropertyBuilding oPropertyBuilding = request.Property;

            //Business validations
            if (_propertyFinder.ExistPropertyWithCondition(oPropertyBuilding.Code, oPropertyBuilding.Id))
            {
                throw new CustomErrorException(EnumErrorCode.ExistCodeProperty);
            }

            PropertyBuilding oldPropertyBuilding = _propertyFinder.GetById(oPropertyBuilding.Id);
            if (oldPropertyBuilding != null)
            {
                oResponseDto.Success = _propertyManager.UpdateProperty(oPropertyBuilding);
                if (oResponseDto.Success)
                {
                    PropertyTrace oPropertyTrace = new PropertyTrace() { 
                        Name = oldPropertyBuilding.Name, 
                        Value = oldPropertyBuilding.Price, 
                        PropertyBuilding = 
                        new PropertyBuilding() { Id = oldPropertyBuilding.Id }, 
                        DateTrace = DateTime.Now 
                    };
                    _propertyTraceManagerPort.CreatePropertyTrace(oPropertyTrace);
                }
            }
            return Task.Run(() =>
            {
                return oResponseDto;
            });
        }
    }
}
