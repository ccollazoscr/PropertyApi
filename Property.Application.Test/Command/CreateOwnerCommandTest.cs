using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NUnit.Framework;
using Property.Application.Command;
using Property.Model.Dto;
using System;
using System.IO;

namespace Property.Application.Test.Command
{
    public class CreateOwnerCommandTest
    {
        private CreateOwnerCommand oCreateOwnerCommand;

        [SetUp]
        public void Setup()
        {
            oCreateOwnerCommand = new CreateOwnerCommand();
        }

        [Test]
        public void CreateOwnerCommand_ImplementIRequest_GetInterface()
        {
            bool IsIRequestInterface = oCreateOwnerCommand is IRequest<CreateOwnerDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void SetName_SetString_GetStringValid()
        {
            var res = oCreateOwnerCommand.SetName("NameTest");
            Assert.That(oCreateOwnerCommand.Name, Is.EqualTo("NameTest"));
            Assert.That(res.GetType(), Is.EqualTo(typeof(CreateOwnerCommand)));
        }

        [Test]
        public void SetAddress_SetString_GetStringValid()
        {
            var res = oCreateOwnerCommand.SetAddress("Street 1");
            Assert.That(oCreateOwnerCommand.Address, Is.EqualTo("Street 1"));
            Assert.That(res.GetType(), Is.EqualTo(typeof(CreateOwnerCommand)));
        }

        [Test]
        public void SetPhoto_CreateMemoryImage_GetJPGImage()
        {
            var res = oCreateOwnerCommand.SetPhoto(null);
            
            var imageStream = new MemoryStream();
            var image = new FormFile(imageStream, 0, imageStream.Length, "UnitTest", "UnitTest.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };

            res.SetPhoto(image);

            Assert.That(oCreateOwnerCommand.Photo, Is.Not.Null);
            Assert.That(res.GetType(), Is.EqualTo(typeof(CreateOwnerCommand)));
            Assert.That(res.Photo.ContentType, Is.EqualTo("image/jpeg"));
        }

        [Test]
        public void SetBirthday_SetDate_GetValidDate()
        {
            var res = oCreateOwnerCommand.SetBirthday(new DateTime(2020,01,01));
            Assert.That(oCreateOwnerCommand.Birthday, Is.Not.Null);
            Assert.That(oCreateOwnerCommand.Birthday.Day, Is.EqualTo(1));
            Assert.That(oCreateOwnerCommand.Birthday.Month, Is.EqualTo(1));
            Assert.That(oCreateOwnerCommand.Birthday.Year, Is.EqualTo(2020));
            Assert.That(res.GetType(), Is.EqualTo(typeof(CreateOwnerCommand)));
        }
    }
}
