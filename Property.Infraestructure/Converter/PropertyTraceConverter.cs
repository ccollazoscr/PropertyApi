using AutoMapper;
using Property.Common.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;

namespace Property.Infraestructure.Converter
{
    public class PropertyTraceConverter : IEntityConverter<PropertyTrace, PropertyTraceEntity>
    {
        private readonly IMapper _Mapper;
        public PropertyTraceConverter()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyTrace, PropertyTraceEntity>()
                .ForMember(dest => dest.IdPropertyTrace, model => model.MapFrom(m => m.Id))
                .ForPath(dest => dest.IdProperty, model => model.MapFrom(m => m.PropertyBuilding.Id))
                .ReverseMap();
            });
            _Mapper = new Mapper(config);
        }

        public PropertyTrace FromEntityToModel(PropertyTraceEntity source)
        {
            return _Mapper.Map<PropertyTrace>(source);
        }

        public PropertyTraceEntity FromModelToEntity(PropertyTrace source)
        {
            return _Mapper.Map<PropertyTraceEntity>(source);
        }
    }
}
