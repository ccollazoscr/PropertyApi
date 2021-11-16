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
using System.Data.SqlClient;
using Property.Common.Exception;

namespace Property.Infraestructure.Adapter.SQLServer.Repository
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
                try
                {
                    id = connection.QuerySingle<long>(sql, oPropertyEntity);
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    throw new CustomErrorException(EnumErrorCode.ConstraintViolated);
                }
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
