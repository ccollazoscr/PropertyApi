using Property.Common.Configuration;
using Property.Common.Exception;
using Property.Infraestructure.Common.SQLServer;
using Property.Infraestructure.Entity;
using System.Data.SqlClient;

namespace Property.Infraestructure.Adapter.SQLServer.Repository
{
    public class PropertyImageRepository : SQLServerBase, IPropertyImageRepository
    {
        public PropertyImageRepository(IRepositorySettings repositorySettings) : base(repositorySettings)
        {
        }

        public long Insert(PropertyImageEntity propertyImageEntity)
        {
            string sql = "INSERT INTO PropertyImage (IdProperty,[File],Enabled) Values (@IdProperty,@File,@Enabled);" +
                        "SELECT CAST(SCOPE_IDENTITY() as bigint);";
            long id = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    id = connection.QuerySingle<long>(sql,new {
                        IdProperty = propertyImageEntity.IdProperty,
                        File= propertyImageEntity.File,
                        Enabled = propertyImageEntity.Enabled
                    });
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
