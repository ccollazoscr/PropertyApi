using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Port
{
    public interface IPropertyFinderPort
    {
        bool ExistProperty(string code);
        bool ExistPropertyWithCondition(string code, long propertyId);

        PropertyBuilding GetById(long Id);
    }
}
