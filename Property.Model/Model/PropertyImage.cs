using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Model.Model
{
    public class PropertyImage
    {
        public long Id { get; set; }
        public PropertyBuilding PropertyBuilding { get; set; }
        public string File { get; set; }
        public bool Enabled { get; set; }
    }
}
