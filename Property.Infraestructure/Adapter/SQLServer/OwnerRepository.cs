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

namespace Property.Infraestructure.Adapter.SQLServer
{
    public class OwnerRepository : SQLServerBase, IOwnerRepository
    {
        public OwnerRepository(IRepositorySettings repositorySettings) : base(repositorySettings)
        {
        }

        public long Insert(OwnerEntity ownerEntity)
        {
            string sql = "INSERT INTO Owner (Name,Address,Photo,Birthday) Values (@Name,@Address,@Photo,@Birthday);" +
                         "SELECT CAST(SCOPE_IDENTITY() as bigint);";
            long id = 0;
            using (var connection = GetConnection())
            {
                try
                {
                    id = connection.QuerySingle<long>(sql, new {
                        Name = ownerEntity.Name,
                        Address = ownerEntity.Address,
                        Photo = ownerEntity.Photo,
                        Birthday = ownerEntity.Birthdaty
                    } );
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
