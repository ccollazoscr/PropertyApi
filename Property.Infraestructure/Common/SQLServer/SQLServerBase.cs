using Property.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAbstractions.Dapper;
using System.Data.SqlClient;

namespace Property.Infraestructure.Common.SQLServer
{
    public class SQLServerBase
    {
        private IRepositorySettings _repositorySettings;
        public SQLServerBase(IRepositorySettings repositorySettings) {
            _repositorySettings = repositorySettings;
        }

        public IDataAccessor GetConnection()
        {
            return new DataAccessor(new SqlConnection(_repositorySettings.GetConnectionString()));
        }

    }
}
