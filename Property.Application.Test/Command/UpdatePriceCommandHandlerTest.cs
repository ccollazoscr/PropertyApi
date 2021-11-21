using MediatR;
using Moq;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Port;
using Property.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Test.Command
{
    public class UpdatePriceCommandHandlerTest
    {
        private Mock<IPropertyManagerPort> _mockIPropertyManagerPort;

        private UpdatePriceCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockIPropertyManagerPort = new Mock<IPropertyManagerPort>();
            _handler = new UpdatePriceCommandHandler(_mockIPropertyManagerPort.Object);
        }

        [Test]
        public void UpdatePriceCommandHandler_ImplementIRequestHandler_GetInterface()
        {
            bool IsIRequestInterface = _handler is IRequestHandler<UpdatePriceCommand, ResponseDto>;
            Assert.IsTrue(IsIRequestInterface);
        }
        [Test]
        public async Task Handle_UpdatePrice_ReturnSuccessFalse() {
            _mockIPropertyManagerPort.Setup(m => m.UpdatePrice(It.IsAny<long>(), It.IsAny<decimal>())).Returns(false);
            ResponseDto oResponseDto = await _handler.Handle(new UpdatePriceCommand(), default);
            Assert.IsNotNull(oResponseDto);
            Assert.That(oResponseDto.Success, Is.False);
        }
        [Test]
        public async Task Handle_UpdatePrice_ReturnSuccessTrue()
        {
            _mockIPropertyManagerPort.Setup(m => m.UpdatePrice(It.IsAny<long>(), It.IsAny<decimal>())).Returns(true);
            ResponseDto oResponseDto = await _handler.Handle(new UpdatePriceCommand(), default);
            Assert.IsNotNull(oResponseDto);
            Assert.That(oResponseDto.Success, Is.True);
        }
    }
}
