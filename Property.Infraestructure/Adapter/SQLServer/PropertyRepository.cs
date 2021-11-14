using Property.Common.Configuration;
using Property.Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAbstractions.Dapper;
using Property.Infraestructure.Common.SQLServer;

namespace Property.Infraestructure.Adapter.SQLServer
{
    public class PropertyRepository : SQLServerBase, IPropertyRepository
    {
        public PropertyRepository(IRepositorySettings repositorySettings):base(repositorySettings) {
        }

        
        public long Insert(PropertyEntity oPropertyEntity)
        {
            string sql = "INSERT INTO Property (Name,Address,Price,CodeInternal,Year,IdOwner) Values (@Name,@Address,@Price,@CodeInternal,@Year,@IdOwner);" +
                         "SELECT CAST(SCOPE_IDENTITY() as bigint);";
            long id = 0;
            using (var connection = GetConnection())
            {
                id = connection.QuerySingle<long>(sql, oPropertyEntity);
            }
            return id;
        }

        public bool ExistProperty(string code)
        {
            string sql = "SELECT COUNT(1) FROM Property WHERE CodeInternal=@code";
            using (var connection = GetConnection())
            {
                return connection.ExecuteScalar<bool>(sql, new { code });
            }
        }
    }
}
