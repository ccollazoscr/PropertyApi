using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NUnit.Framework;
using Property.Application.Command;
using Property.Model.Dto;
using System.IO;

namespace Property.Application.Test.Command
{
    public class CreatePropertyImageCommandTest
    {
        private CreatePropertyImageCommand oCreatePropertyImageCommand;
        [SetUp]
        public void Setup()
        {
            oCreatePropertyImageCommand = new CreatePropertyImageCommand();
        }

        [Test]
        public void CreatePropertyImageCommand_ImplementIRequest_GetInterface()
        {
            bool IsIRequestInterface = oCreatePropertyImageCommand is IRequest<CreatePropertyImageDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void SetIdProperty_SetLong_GetLongValid()
        {
            var res = oCreatePropertyImageCommand.SetIdProperty(1);
            Assert.That(oCreatePropertyImageCommand.IdProperty, Is.EqualTo(1));
            Assert.That(res.GetType(), Is.EqualTo(typeof(CreatePropertyImageCommand)));
        }

        [Test]
        public void SetFile_SetNullFile_GetNullFile()
        {
            var res = oCreatePropertyImageCommand.SetFile(null);
            Assert.That(oCreatePropertyImageCommand.File, Is.Null);
            Assert.That(res.GetType(), Is.EqualTo(typeof(CreatePropertyImageCommand)));
        }

        [Test]
        public void SetFile_CreateMemoryImage_GetJPGImage()
        {
            var res = oCreatePropertyImageCommand.SetFile(null);

            var imageStream = new MemoryStream();
            var image = new FormFile(imageStream, 0, imageStream.Length, "UnitTest", "UnitTest.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            res.SetFile(image);

            Assert.That(res.GetType(), Is.EqualTo(typeof(CreatePropertyImageCommand)));
            Assert.That(res.File, Is.Not.Null);            
            Assert.That(res.File.ContentType, Is.EqualTo("image/jpeg"));
        }

        [Test]
        public void SetEnabled_SetBool_GetBoolValid()
        {
            var res = oCreatePropertyImageCommand.SetEnabled(true);
            Assert.That(res.GetType(), Is.EqualTo(typeof(CreatePropertyImageCommand)));
            Assert.IsTrue(res.Enabled);

            oCreatePropertyImageCommand.SetEnabled(false);

            Assert.IsFalse(res.Enabled);
        }
    }
}
