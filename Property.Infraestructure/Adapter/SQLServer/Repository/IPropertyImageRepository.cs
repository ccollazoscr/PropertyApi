using Property.Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Adapter.SQLServer.Repository
{
    public interface IPropertyImageRepository
    {
        public long Insert(PropertyImageEntity propertyImageEntity);
    }
}
