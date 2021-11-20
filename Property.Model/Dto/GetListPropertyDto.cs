using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Model.Dto
{
    public class GetListPropertyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public int Year { get; set; }
        public long OwnerId { get; set; }
    }
}
