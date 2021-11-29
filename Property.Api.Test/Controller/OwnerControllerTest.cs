using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Property.Application.Command;
using Property.Model.Dto;
using PropertyApi.Controller.v1;
using PropertyApi.EntryModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Api.Test.Controller
{
    public class OwnerControllerTest
    {
        private Mock<IMediator> _mockIMediator;
        private OwnerController oOwnerController;

        [SetUp]
        public void Setup()
        {
            _mockIMediator = new Mock<IMediator>();
            oOwnerController = new OwnerController(_mockIMediator.Object);
        }

        [Test]
        public void CreateOwner_SetNullParam_ThrowException()
        {
            Assert.That(() => oOwnerController.CreateOwnerAsync(null), Throws.InstanceOf(typeof(NullReferenceException)));
        }

        [Test]
        public async Task Authenticate_Send_ReturnAuthenticateToken()
        {
            CreateOwnerDto oCreateOwnerDto = new CreateOwnerDto() { Id=1, Photo="http://localhost/test.png"};
            _mockIMediator.Setup(x => x.Send(It.IsAny<CreateOwnerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(oCreateOwnerDto)
                .Verifiable();
            var res = await oOwnerController.CreateOwnerAsync(new CreateOwnerEntryModel() { Id=0, Name = "Name", Address="Street1", Birthday=new DateTime(1986,11,29)});
            var okResult = res as CreatedResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(201, okResult.StatusCode);
        }

    }
}
