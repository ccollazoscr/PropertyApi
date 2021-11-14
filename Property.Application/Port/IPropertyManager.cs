using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Port
{
    public interface IPropertyManager
    {
        long CreateProperty(PropertyBuilding oPropertyBuilding);
    }
}
