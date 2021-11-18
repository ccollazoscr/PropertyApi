using Property.Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Adapter.SQLServer.Repository
{
    public interface IPropertyRepository
    {
        public long Insert(PropertyEntity oPropertyEntity);

        public bool ExistProperty(string code);
        public bool ExistPropertyWithCondition(string code, long propertyId);

        public bool UpdatePrice(long propertyId, decimal price);       

        public bool UpdateProperty(PropertyEntity oPropertyEntity);

        public PropertyEntity GetById(long propertyId);
    }
}
