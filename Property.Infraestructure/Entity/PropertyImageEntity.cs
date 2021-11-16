using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Entity
{
    public class PropertyImageEntity
    {
        public long IdPropertyImage { get; set; }
        public long IdProperty { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
