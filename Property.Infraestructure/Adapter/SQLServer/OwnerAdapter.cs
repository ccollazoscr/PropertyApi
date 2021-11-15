using Property.Application.Port;
using Property.Common.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;

namespace Property.Infraestructure.Adapter.SQLServer
{
    public class OwnerAdapter : IOwnerManagerPort
    {
        IOwnerRepository _ownerRepository;
        IEntityConverter<Owner, OwnerEntity> _converterEntity;
        public OwnerAdapter(IOwnerRepository ownerRepository, IEntityConverter<Owner, OwnerEntity> converterEntity) {
            _ownerRepository = ownerRepository;
            _converterEntity = converterEntity;
        }

        public long CreateOwner(Owner oOwner)
        {
            OwnerEntity oOwnerEntity = _converterEntity.FromModelToEntity(oOwner);
            return _ownerRepository.Insert(oOwnerEntity);
        }
    }
}
