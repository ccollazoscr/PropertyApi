namespace Property.Common.Configuration
{
    public class GeneralSettings : IGeneralSettings
    {
        private string RootFolder;
        private string OwnerFolder;
        private string PropertyFolder;
        private string Host;

        public GeneralSettings SetRootFolder(string rootFolder)
        {
            RootFolder = rootFolder;
            return this;
        }

        public GeneralSettings SetOwnerFolder(string ownerFolder)
        {
            OwnerFolder = ownerFolder;
            return this;
        }

        public GeneralSettings SetPropertyFolder(string propertyFolder)
        {
            PropertyFolder = propertyFolder;
            return this;
        }

        public GeneralSettings SetHost(string host)
        {
            Host = host;
            return this;
        }

        public string GetRootFolder()
        {
            return RootFolder;
        }

        public string GetOwnerFolder()
        {
            return OwnerFolder;
        }

        public string GetPropertyFolder()
        {
            return PropertyFolder;
        }

        public string GetHost()
        {
            return Host;
        }
    }
}
