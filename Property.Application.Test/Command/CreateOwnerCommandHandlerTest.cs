using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Port;
using Property.Common.Enum;
using Property.Model.Dto;
using Property.Model.Model;
using System.IO;
using System.Threading.Tasks;

namespace Property.Application.Test.Command
{
    public class CreateOwnerCommandHandlerTest
    {
        private Mock<IImageManagerPort> _mockImageManagerPort;
        private Mock<IOwnerManagerPort> _mockIOwnerManagerPort;
        
        private CreateOwnerCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockImageManagerPort = new Mock<IImageManagerPort>();
            _mockIOwnerManagerPort = new Mock<IOwnerManagerPort>();
            _handler = new CreateOwnerCommandHandler(_mockImageManagerPort.Object, _mockIOwnerManagerPort.Object);
        }

        [Test]
        public void CreateOwnerCommandHandler_ImplementIRequestHandler_GetInterface()
        {
            bool IsIRequestInterface = _handler is IRequestHandler<CreateOwnerCommand, CreateOwnerDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public async Task Handle_NullPhoto_ReturnEmptyPathPhoto()
        {
            CreateOwnerCommand oCreateOwnerCommand = new CreateOwnerCommand().SetPhoto(null);
            _mockIOwnerManagerPort.Setup(m => m.CreateOwner(It.IsAny<Owner>())).Returns(1);
            CreateOwnerDto oResCreateOwnerDto = await _handler.Handle(oCreateOwnerCommand, default);
            Assert.That(oResCreateOwnerDto, Is.Not.Null);
            Assert.That(oResCreateOwnerDto.Id, Is.EqualTo(1));
            Assert.That(oResCreateOwnerDto.Photo, Is.Empty);
        }

        [Test]
        public async Task Handle_SetPhoto_ReturnPathPhoto()
        {
            var imageStream = new MemoryStream();
            var image = new FormFile(imageStream, 0, imageStream.Length, "UnitTest", "UnitTest.jpg")
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg"
            };
            CreateOwnerCommand oCreateOwnerCommand = new CreateOwnerCommand().SetPhoto(image);
            _mockIOwnerManagerPort.Setup(m => m.CreateOwner(It.IsAny<Owner>())).Returns(1);
            _mockImageManagerPort.Setup(m => m.SaveImageAsync(It.IsAny<IFormFile>(), ImageType.Owner)).Returns(Task.FromResult("/ImagesOwners/abc.jpeg"));
            _mockImageManagerPort.Setup(m => m.GetHostImage(ImageType.Owner, "/ImagesOwners/abc.jpeg")).Returns("http://host/abc.jpeg");

            CreateOwnerDto oResCreateOwnerDto = await _handler.Handle(oCreateOwnerCommand, default);
            Assert.That(oResCreateOwnerDto, Is.Not.Null);
            Assert.That(oResCreateOwnerDto.Id, Is.EqualTo(1));
            Assert.That(oResCreateOwnerDto.Photo, Is.EqualTo("http://host/abc.jpeg"));
        }
    }
}
