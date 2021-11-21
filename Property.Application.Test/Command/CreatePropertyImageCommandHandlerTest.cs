using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Port;
using Property.Common.Enum;
using Property.Model.Dto;
using Property.Model.Model;
using System.Threading.Tasks;

namespace Property.Application.Test.Command
{
    public class CreatePropertyImageCommandHandlerTest
    {
        private Mock<IImageManagerPort> _mockImageManagerPort;
        private Mock<IPropertyImageManagerPort> _mockIPropertyImageManagerPort;

        private CreatePropertyImageCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockImageManagerPort = new Mock<IImageManagerPort>();
            _mockIPropertyImageManagerPort = new Mock<IPropertyImageManagerPort>();
            _handler = new CreatePropertyImageCommandHandler(_mockImageManagerPort.Object, _mockIPropertyImageManagerPort.Object);
        }

        [Test]
        public void CreatePropertyImageCommandHandler_ImplementIRequestHandler_GetInterface()
        {
            bool IsIRequestInterface = _handler is IRequestHandler<CreatePropertyImageCommand, CreatePropertyImageDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public async Task Handle_CreatePropertyImage_ReturnValidId() {
            _mockImageManagerPort.Setup(m => m.SaveImageAsync(It.IsAny<IFormFile>(), It.IsAny<ImageType>())).Returns(Task.FromResult("/ImagesProperties/abc.jpeg"));
            _mockImageManagerPort.Setup(m => m.GetHostImage(ImageType.Properties, "/ImagesProperties/abc.jpeg")).Returns("http://host/abc.jpeg");
            _mockIPropertyImageManagerPort.Setup(m => m.CreatePropertyImage(It.IsAny<PropertyImage>())).Returns(1);
            CreatePropertyImageDto oResCreatePropertyImageDto = await _handler.Handle(new CreatePropertyImageCommand(), default);

            Assert.That(oResCreatePropertyImageDto, Is.Not.Null);
            Assert.That(oResCreatePropertyImageDto.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Handle_GetHostImage_ReturnValidFile()
        {
            _mockImageManagerPort.Setup(m => m.SaveImageAsync(It.IsAny<IFormFile>(), It.IsAny<ImageType>())).Returns(Task.FromResult("/ImagesProperties/abc.jpeg"));
            _mockImageManagerPort.Setup(m => m.GetHostImage(ImageType.Properties, "/ImagesProperties/abc.jpeg")).Returns("http://host/abc.jpeg");
            _mockIPropertyImageManagerPort.Setup(m => m.CreatePropertyImage(It.IsAny<PropertyImage>())).Returns(1);
            CreatePropertyImageDto oResCreatePropertyImageDto = await _handler.Handle(new CreatePropertyImageCommand(), default);

            Assert.That(oResCreatePropertyImageDto, Is.Not.Null);
            Assert.That(oResCreatePropertyImageDto.File, Is.EqualTo("http://host/abc.jpeg"));
        }
    }
}
