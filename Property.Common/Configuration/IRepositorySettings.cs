
namespace Property.Common.Configuration
{
    public interface IRepositorySettings
    {
        public string GetConnectionString();
        public string GetDatabaseName();
    }
}
