using Property.Common.Configuration;
using Property.Common.Exception;
using Property.Infraestructure.Common.SQLServer;
using Property.Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Adapter.SQLServer.Repository
{
    public class PropertyTraceRepository : SQLServerBase, IPropertyTraceRepository
    {
        public PropertyTraceRepository(IRepositorySettings repositorySettings) : base(repositorySettings)
        {
        }

        public long Insert(PropertyTraceEntity oPropertyTraceEntity)
        {
            string sql = "INSERT INTO PropertyTrace (DateSale,Name,Value,Tax,IdProperty,DateTrace) Values (@DateSale,@Name,@Value,@Tax,@IdProperty,@DateTrace);" +
                         "SELECT CAST(SCOPE_IDENTITY() as bigint);";
            long id = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    id = connection.QuerySingle<long>(sql, oPropertyTraceEntity);
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    throw new CustomErrorException(EnumErrorCode.ConstraintViolated);
                }
            }
            return id;
        }
    }
}
