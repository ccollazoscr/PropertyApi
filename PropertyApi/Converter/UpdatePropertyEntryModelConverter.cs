using AutoMapper;
using Property.Common.Converter;
using Property.Model.Model;
using PropertyApi.EntryModel;

namespace PropertyApi.Converter
{
    public class UpdatePropertyEntryModelConverter : IEntryModelConverter<UpdatePropertyEntryModel, PropertyBuilding>
    {
        private readonly IMapper _Mapper;
        public UpdatePropertyEntryModelConverter()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UpdatePropertyEntryModel, PropertyBuilding>()
                .ForPath(dest => dest.Owner.Id, entryModel => entryModel.MapFrom(em => em.IdOwner))
                .ReverseMap();
            });
            _Mapper = new Mapper(config);
        }

        public PropertyBuilding FromEntryModelToModel(UpdatePropertyEntryModel source)
        {
            return _Mapper.Map<PropertyBuilding>(source);
        }

        public UpdatePropertyEntryModel FromModelToEntryModel(PropertyBuilding source)
        {
            return _Mapper.Map<UpdatePropertyEntryModel>(source);
        }
    }
}
