using MediatR;
using Property.Application.Port;
using Property.Model.Dto;
using Property.Model.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Command
{
    public class CreatePropertyImageCommandHandler : IRequestHandler<CreatePropertyImageCommand, CreatePropertyImageDto>
    {
        private IImageManagerPort _imageManagerPort;
        private IPropertyImageManagerPort _propertyImageManagerPort;
        public CreatePropertyImageCommandHandler(IImageManagerPort imageManagerPort, IPropertyImageManagerPort propertyImageManagerPort ) {
            _imageManagerPort = imageManagerPort;
            _propertyImageManagerPort = propertyImageManagerPort;
        }
        public async Task<CreatePropertyImageDto> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
        {
            //Save Photo
            string namePhoto = await _imageManagerPort.SaveImageAsync(request.File, Common.Enum.ImageType.Properties);
            string hostImage = _imageManagerPort.GetHostImage(Common.Enum.ImageType.Properties, namePhoto);

            PropertyImage oPropertyImage = new PropertyImage() { PropertyBuilding=new PropertyBuilding() { Id = request.IdProperty}, File = namePhoto, Enabled = request.Enabled  };
            //Save Owner
            oPropertyImage.Id = _propertyImageManagerPort.CreatePropertyImage(oPropertyImage);

            CreatePropertyImageDto oCreatePropertyImageDto = new CreatePropertyImageDto() { Id = oPropertyImage.Id, File = hostImage };
            return oCreatePropertyImageDto;
        }
    }
}
