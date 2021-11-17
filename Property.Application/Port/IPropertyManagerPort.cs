using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Port
{
    public interface IPropertyManagerPort
    {
        long CreateProperty(PropertyBuilding oPropertyBuilding);
        bool UpdatePrice(long idProperty, decimal price);
    }
}
