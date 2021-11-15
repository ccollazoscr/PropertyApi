using MediatR;
using Property.Application.Port;
using Property.Model.Model;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Command
{
    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, long>
    {
        private IImageManagerPort _imageManagerPort;
        private IOwnerManagerPort _ownerManagerPort;
        public CreateOwnerCommandHandler(IImageManagerPort imageManagerPort, IOwnerManagerPort ownerManagerPort) {
            _imageManagerPort = imageManagerPort;
            _ownerManagerPort = ownerManagerPort;
        }

        public async Task<long> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            //Save Photo
            string pathPhoto = "";
            if (request.Photo != null) {
                pathPhoto = await _imageManagerPort.SaveImageAsync(request.Photo, Common.Enum.ImageType.Owner);
            }
            Owner oOwner = new Owner() { Name = request.Name, Address = request.Address, Photo = pathPhoto, Birthdaty = request.Birthday };
            //Save Owner
            return _ownerManagerPort.CreateOwner(oOwner);
        }
    }
}
