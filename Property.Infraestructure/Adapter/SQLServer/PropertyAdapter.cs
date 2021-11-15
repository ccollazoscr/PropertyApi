using Property.Application.Port;
using Property.Common.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Adapter.SQLServer
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
