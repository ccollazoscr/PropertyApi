using AutoMapper;
using Property.Common.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;

namespace Property.Infraestructure.Converter
{
    public class OwnerConverter : IEntityConverter<Owner, OwnerEntity>
    {
        private readonly IMapper _Mapper;
        public OwnerConverter()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Owner, OwnerEntity>()
                 .ForMember(dest => dest.IdOwner, model => model.MapFrom(m => m.Id))
                .ReverseMap();
            });
            _Mapper = new Mapper(config);
        }

        public Owner FromEntityToModel(OwnerEntity source)
        {
            return _Mapper.Map<Owner>(source);
        }

        public OwnerEntity FromModelToEntity(Owner source)
        {
            return _Mapper.Map<OwnerEntity>(source);
        }
    }
}
