using MediatR;
using Property.Application.Port;
using Property.Model.Dto;
using Property.Model.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Command
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, CreateOwnerDto>
    {
        private IImageManagerPort _imageManagerPort;
        private IOwnerManagerPort _ownerManagerPort;
        public CreateOwnerCommandHandler(IImageManagerPort imageManagerPort, IOwnerManagerPort ownerManagerPort) {
            _imageManagerPort = imageManagerPort;
            _ownerManagerPort = ownerManagerPort;
        }

        public async Task<CreateOwnerDto> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            //Save Photo
            string namePhoto = "";
            string hostPhoto = "";
            if (request.Photo != null) {
                namePhoto = await _imageManagerPort.SaveImageAsync(request.Photo, Common.Enum.ImageType.Owner);
                hostPhoto = _imageManagerPort.GetHostImage(Common.Enum.ImageType.Owner, namePhoto);
            }
            Owner oOwner = new Owner() { Name = request.Name, Address = request.Address, Photo = namePhoto, Birthdaty = request.Birthday };
            //Save Owner
            long id = _ownerManagerPort.CreateOwner(oOwner);
            CreateOwnerDto oCreateOwnerDto = new CreateOwnerDto(){Id = id,Photo = hostPhoto};
            return oCreateOwnerDto;
        }

    }
}
