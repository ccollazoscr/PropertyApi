using Property.Application.Port;
using Property.Common.Converter;
using Property.Infraestructure.Adapter.SQLServer.Repository;
using Property.Infraestructure.Entity;
using Property.Model.Model;

namespace Property.Infraestructure.Adapter.SQLServer.Adapter
{
    public class PropertyAdapter : IPropertyManagerPort, IPropertyFinderPort
    {
        private IPropertyRepository _propertyRepository;
        private IEntityConverter<PropertyBuilding, PropertyEntity> _converterEntity;
        public PropertyAdapter(IPropertyRepository propertyRepository, IEntityConverter<PropertyBuilding, PropertyEntity> converterEntity) {
            _propertyRepository = propertyRepository;
            _converterEntity = converterEntity;
        }

        public long CreateProperty(PropertyBuilding oPropertyBuilding)
        {
            PropertyEntity oPropertyEntity = _converterEntity.FromModelToEntity(oPropertyBuilding);
            return _propertyRepository.Insert(oPropertyEntity);
        }

        public bool ExistProperty(string code)
        {
            return _propertyRepository.ExistProperty(code);
        }
    }
}
