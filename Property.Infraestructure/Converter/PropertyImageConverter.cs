using AutoMapper;
using Property.Common.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Converter
{
    public class PropertyImageConverter : IEntityConverter<PropertyImage, PropertyImageEntity>
    {
        private readonly IMapper _Mapper;
        public PropertyImageConverter()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyImage, PropertyImageEntity>()
                .ForMember(dest => dest.IdPropertyImage, model => model.MapFrom(m => m.Id))
                .ForMember(dest => dest.IdProperty, model => model.MapFrom(m => m.PropertyBuilding.Id))
                .ReverseMap();
            });
            _Mapper = new Mapper(config);
        }

        public PropertyImage FromEntityToModel(PropertyImageEntity source)
        {
            return _Mapper.Map<PropertyImage>(source);
        }

        public PropertyImageEntity FromModelToEntity(PropertyImage source)
        {
            return _Mapper.Map<PropertyImageEntity>(source);
        }
    }
}
