using MediatR;
using Microsoft.AspNetCore.Http;
using Property.Application.Dto;
using Property.Model.Model;
using System;

namespace Property.Application.Command
{
    public class CreateOwnerCommand : IRequest<CreateOwnerDto>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public IFormFile Photo { get; set; }
        public DateTime Birthday { get; set; }

        public CreateOwnerCommand SetName(string Name)
        {
            this.Name = Name;
            return this;
        }

        public CreateOwnerCommand SetAddress(string Address)
        {
            this.Address = Address;
            return this;
        }

        public CreateOwnerCommand SetPhoto(IFormFile Photo)
        {
            this.Photo = Photo;
            return this;
        }

        public CreateOwnerCommand SetBirthday(DateTime Birthday) {
            this.Birthday = Birthday;
            return this;
        }
    }
}
