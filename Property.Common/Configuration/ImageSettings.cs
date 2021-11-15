namespace Property.Common.Configuration
{
    public class ImageSettings : IImageSettings
    {
        private string RootFolder;
        private string OwnerFolder;
        private string PropertyFolder;        

        public ImageSettings SetRootFolder(string rootFolder)
        {
            RootFolder = rootFolder;
            return this;
        }

        public ImageSettings SetOwnerFolder(string ownerFolder)
        {
            OwnerFolder = ownerFolder;
            return this;
        }

        public ImageSettings SetPropertyFolder(string propertyFolder)
        {
            PropertyFolder = propertyFolder;
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
    }
}
