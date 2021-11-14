using AutoMapper;
using Property.Common.Converter;
using Property.Model.Model;
using PropertyApi.EntryModel;

namespace PropertyApi.Converter
{
    public class CreatePropertyEntryModelConverter : IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding>
    {
        private readonly IMapper _Mapper;
        public CreatePropertyEntryModelConverter()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatePropertyEntryModel, PropertyBuilding>()
                .ForPath(dest => dest.Owner.IdOwner, entryModel => entryModel.MapFrom(em => em.IdOwner))
                .ReverseMap();
            });
            _Mapper = new Mapper(config);
        }

        public PropertyBuilding FromEntryModelToModel(CreatePropertyEntryModel source)
        {
            return _Mapper.Map<PropertyBuilding>(source);
        }

        public CreatePropertyEntryModel FromModelToEntryModel(PropertyBuilding source)
        {
            return _Mapper.Map<CreatePropertyEntryModel>(source);
        }
    }
}
