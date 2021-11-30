using DataAbstractions.Dapper;
using Moq;
using NUnit.Framework;
using Property.Common.Configuration;
using Property.Infraestructure.Common.SQLServer;

namespace Property.Infraestructure.Test.Common.SQLServer
{
    public class SQLServerBaseTest
    {
        private Mock<IRepositorySettings> _mockIRepositorySettings;
        private SQLServerBase oSQLServerBase;

        [SetUp]
        public void Setup()
        {
            _mockIRepositorySettings = new Mock<IRepositorySettings>();
            oSQLServerBase = new SQLServerBase(_mockIRepositorySettings.Object);
        }

        [Test]
        public void GetConnection_GetConnectionString_GetEmptyValueConnectionString()
        {
            _mockIRepositorySettings.Setup(m => m.GetConnectionString()).Returns((string)null);
            IDataAccessor oIDataAccessor = oSQLServerBase.GetConnection();
            Assert.IsNotNull(oIDataAccessor);
            Assert.IsEmpty(oIDataAccessor.ConnectionString);
        }

        [Test]
        public void GetConnection_GetConnectionString_GetValueConnectionString()
        {
            _mockIRepositorySettings.Setup(m => m.GetConnectionString()).Returns("data source=.;Initial Catalog=PropertyUsers;Integrated Security=True;");
            IDataAccessor oIDataAccessor = oSQLServerBase.GetConnection();
            Assert.IsNotNull(oIDataAccessor);
            Assert.IsNotEmpty(oIDataAccessor.ConnectionString);
        }

    }
}
