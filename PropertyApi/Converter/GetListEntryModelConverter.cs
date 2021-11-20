using AutoMapper;
using Property.Common.Converter;
using Property.Model.Model;
using PropertyApi.EntryModel;

namespace PropertyApi.Converter
{
    public class GetListEntryModelConverter : IEntryModelConverter<GetListPropertyEntryModel, PropertyBuilding>
    {
        private readonly IMapper _Mapper;
        public GetListEntryModelConverter()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GetListPropertyEntryModel, PropertyBuilding>()
                .ForPath(dest => dest.Owner.Id, entryModel => entryModel.MapFrom(em => em.IdOwner))
                .ReverseMap();
            });
            _Mapper = new Mapper(config);
        }

        public PropertyBuilding FromEntryModelToModel(GetListPropertyEntryModel source)
        {
            return _Mapper.Map<PropertyBuilding>(source);
        }

        public GetListPropertyEntryModel FromModelToEntryModel(PropertyBuilding source)
        {
            return _Mapper.Map<GetListPropertyEntryModel>(source);
        }
    }
}
