using MediatR;
using Moq;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Port;
using Property.Common.Exception;
using Property.Model.Dto;
using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Test.Command
{
    public class CreatePropertyCommandHandlerTest
    {
        private Mock<IPropertyManagerPort> _mockIPropertyManagerPort;
        private Mock<IPropertyFinderPort> _mockIPropertyFinderPort;

        private CreatePropertyCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockIPropertyManagerPort = new Mock<IPropertyManagerPort>();
            _mockIPropertyFinderPort = new Mock<IPropertyFinderPort>();
            _handler = new CreatePropertyCommandHandler(_mockIPropertyManagerPort.Object, _mockIPropertyFinderPort.Object);
        }

        [Test]
        public void CreatePropertyCommandHandler_ImplementIRequestHandler_GetInterface()
        {
            bool IsIRequestInterface = _handler is IRequestHandler<CreatePropertyCommand, CreatePropertyDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void Handle_ExistProperty_ThrowCustomException()
        {
            _mockIPropertyFinderPort.Setup(m => m.ExistProperty(It.IsAny<string>())).Returns(true);
            CreatePropertyCommand oCreatePropertyCommand = new CreatePropertyCommand(new PropertyBuilding());
            Assert.That(() => _handler.Handle(oCreatePropertyCommand, default), Throws.InstanceOf(typeof(CustomErrorException)));
        }

        [Test]
        public async Task Handle_CreateProperty_GetIdProperty()
        {
            _mockIPropertyFinderPort.Setup(m => m.ExistProperty(It.IsAny<string>())).Returns(false);
            _mockIPropertyManagerPort.Setup(m => m.CreateProperty(It.IsAny<PropertyBuilding>())).Returns(1);
            CreatePropertyCommand oCreatePropertyCommand = new CreatePropertyCommand(new PropertyBuilding());
            CreatePropertyDto oCreatePropertyDto = await _handler.Handle(oCreatePropertyCommand, default);
            Assert.That(oCreatePropertyDto, Is.Not.Null);
            Assert.That(oCreatePropertyDto.Id, Is.EqualTo(1));
        }
    }
}