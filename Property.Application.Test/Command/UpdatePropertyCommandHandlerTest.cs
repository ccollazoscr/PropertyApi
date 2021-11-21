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
    public class UpdatePropertyCommandHandlerTest
    {
        private Mock<IPropertyManagerPort> _mockIPropertyManagerPort;
        private Mock<IPropertyFinderPort> _mockIPropertyFinderPort;
        private Mock<IPropertyTraceManagerPort> _mockIPropertyTraceManagerPort;

        private UpdatePropertyCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockIPropertyManagerPort = new Mock<IPropertyManagerPort>();
            _mockIPropertyFinderPort = new Mock<IPropertyFinderPort>();
            _mockIPropertyTraceManagerPort = new Mock<IPropertyTraceManagerPort>();
            _handler = new UpdatePropertyCommandHandler(_mockIPropertyManagerPort.Object, _mockIPropertyFinderPort.Object, _mockIPropertyTraceManagerPort.Object);
        }

        [Test]
        public void UpdatePropertyCommandHandler_ImplementIRequestHandler_GetInterface()
        {
            bool IsIRequestInterface = _handler is IRequestHandler<UpdatePropertyCommand, ResponseDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void Handle_ExistPropertyWithCondition_ThrowCustomException()
        {
            _mockIPropertyFinderPort.Setup(m => m.ExistPropertyWithCondition(It.IsAny<string>(), It.IsAny<long>())).Returns(true);
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(new PropertyBuilding());
            Assert.That(() => _handler.Handle(oUpdatePropertyCommand, default), Throws.InstanceOf(typeof(CustomErrorException)));
        }

        [Test]
        public async Task Handle_GetById_ReturnSuccessFalse()
        {
            _mockIPropertyFinderPort.Setup(m => m.ExistPropertyWithCondition(It.IsAny<string>(), It.IsAny<long>())).Returns(false);
            _mockIPropertyFinderPort.Setup(m => m.GetById(It.IsAny<long>())).Returns((PropertyBuilding)null);
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(new PropertyBuilding());
            ResponseDto oResponseDto = await _handler.Handle(oUpdatePropertyCommand, default);
            Assert.That(oResponseDto, Is.Not.Null);
            Assert.That(oResponseDto.Success, Is.False);
        }

        
        [Test]
        public async Task Handle_UpdateProperty_ReturnSuccessTrue()
        {
            _mockIPropertyFinderPort.Setup(m => m.ExistPropertyWithCondition(It.IsAny<string>(), It.IsAny<long>())).Returns(false);
            _mockIPropertyFinderPort.Setup(m => m.GetById(It.IsAny<long>())).Returns(new PropertyBuilding() { Id = 1 });
            _mockIPropertyManagerPort.Setup(m => m.UpdateProperty(It.IsAny<PropertyBuilding>())).Returns(true);
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(new PropertyBuilding());
            ResponseDto oResponseDto = await _handler.Handle(oUpdatePropertyCommand, default);
            Assert.That(oResponseDto, Is.Not.Null);
            Assert.That(oResponseDto.Success, Is.True);
        }
        
        [Test]
        public async Task Handle_UpdateProperty_ReturnSuccessFalse()
        {
            _mockIPropertyFinderPort.Setup(m => m.ExistPropertyWithCondition(It.IsAny<string>(), It.IsAny<long>())).Returns(false);
            _mockIPropertyFinderPort.Setup(m => m.GetById(It.IsAny<long>())).Returns(new PropertyBuilding() { Id = 1 });
            _mockIPropertyManagerPort.Setup(m => m.UpdateProperty(It.IsAny<PropertyBuilding>())).Returns(false);
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(new PropertyBuilding());
            ResponseDto oResponseDto = await _handler.Handle(oUpdatePropertyCommand, default);
            Assert.That(oResponseDto, Is.Not.Null);
            Assert.That(oResponseDto.Success, Is.False);
        }

        [Test]
        public async Task Handle_CreatePropertyTrace_CallOneTime()
        {
            _mockIPropertyFinderPort.Setup(m => m.ExistPropertyWithCondition(It.IsAny<string>(), It.IsAny<long>())).Returns(false);
            _mockIPropertyFinderPort.Setup(m => m.GetById(It.IsAny<long>())).Returns(new PropertyBuilding() { Id = 1 });
            _mockIPropertyManagerPort.Setup(m => m.UpdateProperty(It.IsAny<PropertyBuilding>())).Returns(true);
            _mockIPropertyTraceManagerPort.Setup(m => m.CreatePropertyTrace(It.IsAny<PropertyTrace>())).Returns(1);
            UpdatePropertyCommand oUpdatePropertyCommand = new UpdatePropertyCommand(new PropertyBuilding());
            ResponseDto oResponseDto = await _handler.Handle(oUpdatePropertyCommand, default);
            _mockIPropertyTraceManagerPort.Verify(m => m.CreatePropertyTrace(It.IsAny<PropertyTrace>()), Times.Once);
            Assert.That(oResponseDto, Is.Not.Null);
            Assert.That(oResponseDto.Success, Is.True);
        }

    }
}
