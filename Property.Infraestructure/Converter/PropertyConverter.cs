using AutoMapper;
using Property.Common.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;

namespace Property.Infraestructure.Converter
{
    public class PropertyConverter : IEntityConverter<PropertyBuilding, PropertyEntity>
    {
        private readonly IMapper _Mapper;
        public PropertyConverter() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyBuilding, PropertyEntity>()
                .ForPath(dest => dest.IdOwner, model => model.MapFrom(m => m.Owner.Id))
                .ForMember(dest => dest.CodeInternal, model => model.MapFrom(m=>m.Code))
                .ForMember(dest => dest.IdProperty, model => model.MapFrom(m => m.Id))
                .ReverseMap();
            });
            _Mapper = new Mapper(config);
        }

        public PropertyBuilding FromEntityToModel(PropertyEntity source)
        {
            return _Mapper.Map<PropertyBuilding>(source);
        }

        public PropertyEntity FromModelToEntity(PropertyBuilding source)
        {
            return _Mapper.Map<PropertyEntity>(source);
        }
    }
}
