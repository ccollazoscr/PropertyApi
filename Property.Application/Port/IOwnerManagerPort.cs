using Property.Model.Model;

namespace Property.Application.Port
{
    public interface IOwnerManagerPort
    {
        long CreateOwner(Owner oOwner);
    }
}
