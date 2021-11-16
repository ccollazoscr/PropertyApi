using MediatR;
using Microsoft.AspNetCore.Http;
using Property.Application.Dto;

namespace Property.Application.Command
{
    public class CreatePropertyImageCommand : IRequest<CreatePropertyImageDto>
    {
        public long IdProperty { get; set; }
        public IFormFile File { get; set; }
        public bool Enabled { get; set; }

        public CreatePropertyImageCommand SetIdProperty(long IdProperty)
        {
            this.IdProperty = IdProperty;
            return this;
        }

        public CreatePropertyImageCommand SetFile(IFormFile File)
        {
            this.File = File;
            return this;
        }

        public CreatePropertyImageCommand SetEnabled(bool Enabled)
        {
            this.Enabled = Enabled;
            return this;
        }

    }
}
