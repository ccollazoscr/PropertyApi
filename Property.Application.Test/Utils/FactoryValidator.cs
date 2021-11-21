using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Property.Application.Command;
using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Test.Utils
{
    public static class FactoryValidator
    {
        public static  FormFile GetImageTest(string contenType = "image/jpeg")
        {
            var imageStream = new MemoryStream();
            var image = new FormFile(imageStream, 0, imageStream.Length, "UnitTest", "UnitTest.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = contenType
            };
            return image;
        }
    }
}
