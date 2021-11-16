using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Property.Application.Port;
using Property.Common.Configuration;
using Property.Common.Enum;
using Property.Common.Exception;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Adapter.FileStorage
{
    public class ImageAdapter : IImageManagerPort
    {
        private IGeneralSettings _imageSettings;
        private IHostingEnvironment _hostingEnvironment;
        public ImageAdapter(IGeneralSettings imageSettings, IHostingEnvironment hostingEnvironment) {
            _imageSettings = imageSettings;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> SaveImageAsync(IFormFile formFile, ImageType imageType)
        {
            try
            {
                string ext = Path.GetExtension(formFile.FileName);
                string fileName = $"{Guid.NewGuid()}{ext}";
                string filePath = GetPathSaveFile(imageType) + "\\" + fileName;
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
                return fileName;
            }
            catch
            {
                throw new CustomErrorException(EnumErrorCode.SaveImageFileStorage);
            }
        }

        public string GetHostImage(ImageType imageType, string name)
        {
            return $"{_imageSettings.GetHost()}/{_imageSettings.GetRootFolder()}/{GetFolderByType(imageType)}/{name}";
        }

        private string GetPathSaveFile(ImageType imageType) {
            string baseFolder = $"{_hostingEnvironment.ContentRootPath}\\{_imageSettings.GetRootFolder()}\\";
            baseFolder += GetFolderByType(imageType);
            return baseFolder;
        }

        private string GetFolderByType(ImageType imageType) {
            string folder="";
            switch (imageType)
            {
                case ImageType.Owner:
                    folder = _imageSettings.GetOwnerFolder();
                    break;
                case ImageType.Properties:
                    folder = _imageSettings.GetPropertyFolder();
                    break;
            }
            return folder;
        }

        
    }

}
