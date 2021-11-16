using Property.Model.Model;

namespace Property.Application.Port
{
    public interface IPropertyImageManagerPort
    {
        long CreatePropertyImage(PropertyImage propertyImage);
    }
}
