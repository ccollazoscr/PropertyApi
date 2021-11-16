using Property.Application.Port;
using Property.Common.Converter;
using Property.Infraestructure.Adapter.SQLServer.Repository;
using Property.Infraestructure.Entity;
using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Adapter.SQLServer.Adapter
{
    public class PropertyImageAdapter : IPropertyImageManagerPort
    {
        IPropertyImageRepository _iPropertyImageRepository;
        IEntityConverter<PropertyImage, PropertyImageEntity> _converterEntity;
        public PropertyImageAdapter(IPropertyImageRepository iIPropertyImageRepository, IEntityConverter<PropertyImage, PropertyImageEntity> converterEntity) {
            _iPropertyImageRepository = iIPropertyImageRepository;
            _converterEntity = converterEntity;
        }

        public long CreatePropertyImage(PropertyImage propertyImage)
        {
            PropertyImageEntity oPropertyImageEntity = _converterEntity.FromModelToEntity(propertyImage);
            return _iPropertyImageRepository.Insert(oPropertyImageEntity);
        }
    }
}
