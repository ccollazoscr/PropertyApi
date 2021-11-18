using Property.Application.Port;
using Property.Common.Converter;
using Property.Infraestructure.Adapter.SQLServer.Repository;
using Property.Infraestructure.Entity;
using Property.Model.Model;

namespace Property.Infraestructure.Adapter.SQLServer.Adapter
{
    public class PropertyTraceAdapter : IPropertyTraceManagerPort
    {
        IPropertyTraceRepository _iPropertyTraceRepository;
        IEntityConverter<PropertyTrace, PropertyTraceEntity> _converterEntity;
        public PropertyTraceAdapter(IPropertyTraceRepository iPropertyTraceRepository, IEntityConverter<PropertyTrace, PropertyTraceEntity> converterEntity)
        {
            _iPropertyTraceRepository = iPropertyTraceRepository;
            _converterEntity = converterEntity;
        }
        public long CreatePropertyTrace(PropertyTrace oPropertyTrace)
        {
            PropertyTraceEntity oPropertyTraceEntity = _converterEntity.FromModelToEntity(oPropertyTrace);
            return _iPropertyTraceRepository.Insert(oPropertyTraceEntity);
        }
    }
}
