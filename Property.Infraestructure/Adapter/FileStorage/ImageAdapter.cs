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
        private IImageSettings _imageSettings;
        public ImageAdapter(IImageSettings imageSettings) {
            _imageSettings = imageSettings;
        }

        public async Task<string> SaveImageAsync(IFormFile formFile, ImageType imageType)
        {
            try
            {
                string ext = Path.GetExtension(formFile.FileName);
                string fileName = $"{Guid.NewGuid()}{ext}";
                string filePath = GetPathSaveFile(imageType) + "/" + fileName;
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

        private string GetPathSaveFile(ImageType imageType) {
            string baseFolder = $"{AppContext.BaseDirectory}{_imageSettings.GetRootFolder()}/";
            switch (imageType)
            {
                case ImageType.Owner:
                    baseFolder += _imageSettings.GetOwnerFolder();
                    break;
                case ImageType.Properties:
                    baseFolder += _imageSettings.GetPropertyFolder();
                    break;
            }

            return baseFolder;
        }

        
    }

}
