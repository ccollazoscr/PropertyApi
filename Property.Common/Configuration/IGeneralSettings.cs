namespace Property.Common.Configuration
{
    public interface IGeneralSettings
    {
        string GetRootFolder();
        string GetOwnerFolder();
        string GetPropertyFolder();
        string GetHost();
        string GetSecurityServiceUrl();
        bool GetEnabledSecurity();
    }
}
