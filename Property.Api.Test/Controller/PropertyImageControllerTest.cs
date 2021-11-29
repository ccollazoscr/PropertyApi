using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Property.Application.Command;
using Property.Model.Dto;
using PropertyApi.Controller.v1;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Api.Test.Controller
{
    public class PropertyImageControllerTest
    {
        private Mock<IMediator> _mockIMediator;
        private PropertyImageController oPropertyImageController;

        [SetUp]
        public void Setup()
        {
            _mockIMediator = new Mock<IMediator>();
            oPropertyImageController = new PropertyImageController(_mockIMediator.Object);
        }

        [Test]
        public void CreatePropertyImage_SetNullParam_ThrowException()
        {
            Assert.That(() => oPropertyImageController.CreatePropertyImageAsync(null), Throws.InstanceOf(typeof(NullReferenceException)));
        }

        [Test]
        public async Task CreatePropertyImage_Send_ReturnCreatePropertyImageDto()
        {
            CreatePropertyImageDto oCreatePropertyImageDto = new CreatePropertyImageDto() { Id = 1, File = "http://localhost/test.png" };
            _mockIMediator.Setup(x => x.Send(It.IsAny<CreatePropertyImageCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(oCreatePropertyImageDto)
                .Verifiable();
            var res = await oPropertyImageController.CreatePropertyImageAsync(new PropertyApi.EntryModel.CreatePropertyImageEntryModel() { IdProperty=1, Enabled=true });
            var okResult = res as CreatedResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(201, okResult.StatusCode);
        }
    }
}
