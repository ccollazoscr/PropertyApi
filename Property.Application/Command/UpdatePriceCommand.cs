using MediatR;
using Property.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Command
{
    public class UpdatePriceCommand : IRequest<ResponseDto>
    {
        public long Id { get; set; }
        public decimal Price { get; set; }

        public UpdatePriceCommand SetId(long Id)
        {
            this.Id = Id;
            return this;
        }

        public UpdatePriceCommand SetPrice(decimal Price)
        {
            this.Price = Price;
            return this;
        }

    }
}
