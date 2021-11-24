namespace Property.Common.Configuration
{
    public class GeneralSettings : IGeneralSettings
    {
        private string RootFolder;
        private string OwnerFolder;
        private string PropertyFolder;
        private string Host;
        private string SecurityServiceUrl;
        private bool EnabledSecurity;

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

        public GeneralSettings SetSecurityServiceUrl(string securityServiceUrl) {
            SecurityServiceUrl = securityServiceUrl;
            return this;
        }

        public GeneralSettings SetEnabledSecurity(bool enabledSecurity)
        {
            EnabledSecurity = enabledSecurity;
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

        public string GetSecurityServiceUrl()
        {
            return SecurityServiceUrl;
        }

        public bool GetEnabledSecurity()
        {
            return EnabledSecurity;
        }
    }
}
