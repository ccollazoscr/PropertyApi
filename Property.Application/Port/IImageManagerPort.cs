using Microsoft.AspNetCore.Http;
using Property.Common.Enum;
using System.Threading.Tasks;

namespace Property.Application.Port
{
    public interface IImageManagerPort
    {
        public Task<string> SaveImageAsync(IFormFile formFile, ImageType imageType);
        public string GetHostImage(ImageType imageType,string name);
    }
}
