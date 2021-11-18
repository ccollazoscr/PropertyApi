using Property.Model.Model;

namespace Property.Application.Port
{
    public interface IPropertyTraceManagerPort
    {
        public long CreatePropertyTrace(PropertyTrace oPropertyTrace);
    }
}
