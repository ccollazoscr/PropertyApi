using Property.Model.Dto;
using Property.Model.Model;
using System.Collections.Generic;

namespace Property.Application.Port
{
    public interface IPropertyFinderPort
    {
        bool ExistProperty(string code);
        bool ExistPropertyWithCondition(string code, long propertyId);
        PropertyBuilding GetById(long Id);
        List<GetListPropertyDto> GetListProperty(PropertyBuilding oPropertyBuilding);
    }
}
