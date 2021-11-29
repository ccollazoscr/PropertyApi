using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Query;
using Property.Common.Converter;
using Property.Model.Dto;
using Property.Model.Model;
using PropertyApi.Controller.v1;
using PropertyApi.EntryModel;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Api.Test.Controller
{
    public class PropertyControllerTest
    {
        private Mock<IMediator> _mockIMediator;
        private Mock<IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding>> _mockConverterToModel;
        private Mock<IEntryModelConverter<UpdatePropertyEntryModel, PropertyBuilding>> _mockConverterUpdateToModel;
        private Mock<IEntryModelConverter<GetListPropertyEntryModel, PropertyBuilding>> _mockConverterGetListToModel;
        private PropertyController oPropertyController;

        [SetUp]
        public void Setup()
        {
            _mockIMediator = new Mock<IMediator>();
            _mockConverterToModel = new Mock<IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding>>();
            _mockConverterUpdateToModel = new Mock<IEntryModelConverter<UpdatePropertyEntryModel, PropertyBuilding>>();
            _mockConverterGetListToModel = new Mock<IEntryModelConverter<GetListPropertyEntryModel, PropertyBuilding>>();
            oPropertyController = new PropertyController(_mockIMediator.Object, _mockConverterToModel.Object, _mockConverterUpdateToModel.Object, _mockConverterGetListToModel.Object);
        }

        [Test]
        public async Task CreateProperty_SetNullParam_ReturnNullObject()
        {
            _mockIMediator.Setup(x => x.Send(It.IsAny<CreatePropertyCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((CreatePropertyDto)null)
                .Verifiable();
            var res = await oPropertyController.CreatePropertyAsync(null);
            var okResult = res as CreatedResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(201, okResult.StatusCode);
            Assert.IsNull(okResult.Value);
        }

        [Test]
        public async Task CreateProperty_SetValidParam_ReturnValidObject()
        {
            CreatePropertyDto oCreatePropertyDto = new CreatePropertyDto() { Id = 1 };
            _mockIMediator.Setup(x => x.Send(It.IsAny<CreatePropertyCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(oCreatePropertyDto)
                .Verifiable();
            var res = await oPropertyController.CreatePropertyAsync(new CreatePropertyEntryModel() { Address = "Street1", Code = "Code", IdOwner = 1, Name = "Name", Price = 1000, Year = 2021 });
            var okResult = res as CreatedResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(201, okResult.StatusCode);
            Assert.IsNotNull(okResult.Value);
        }

        [Test]
        public void UpdatePrice_SetNullParam_ThrowException()
        {
            Assert.That(() => oPropertyController.UpdatePrice(null), Throws.InstanceOf(typeof(NullReferenceException)));
        }

        [Test]
        public async Task UpdatePrice_SetValidParam_ReturnValidObject()
        {
            ResponseDto oResponseDto = new ResponseDto() { Success = true };
            _mockIMediator.Setup(x => x.Send(It.IsAny<UpdatePriceCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(oResponseDto)
                .Verifiable();
            var res = await oPropertyController.UpdatePrice(new UpdatePriceEntryModel() { Id = 1, Price = 1000 });
            var okResult = res as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(okResult.Value);
        }

        [Test]
        public async Task UpdateProperty_SetNullParam_ReturnNullObject()
        {
            _mockIMediator.Setup(x => x.Send(It.IsAny<UpdatePropertyCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ResponseDto)null)
                .Verifiable();
            var res = await oPropertyController.UpdatePropertyAsync(null);
            var okResult = res as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNull(okResult.Value);
        }

        [Test]
        public async Task UpdateProperty_SetValidParam_ReturnValidObject()
        {
            ResponseDto oResponseDto = new ResponseDto() { Success = true };
            _mockIMediator.Setup(x => x.Send(It.IsAny<UpdatePropertyCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(oResponseDto)
                .Verifiable();
            var res = await oPropertyController.UpdatePropertyAsync(new UpdatePropertyEntryModel()
            {
                Id = 1,
                Address = "Street1",
                Code = "Code",
                IdOwner = 1,
                Name = "Name",
                Price = 1000,
                Year = 2021
            });
            var okResult = res as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(okResult.Value);
        }

        [Test]
        public async Task GetListAsync_SetNullParam_ReturnNullObject()
        {
            _mockIMediator.Setup(x => x.Send(It.IsAny<GetListPropertyQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((List<GetListPropertyDto>)null)
                .Verifiable();
            var res = await oPropertyController.GetListAsync(null);
            var okResult = res as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNull(okResult.Value);
        }

        [Test]
        public async Task GetListAsync_SetValidParam_ReturnValidObject()
        {
            List<GetListPropertyDto> oListResponse = new List<GetListPropertyDto>();
            _mockIMediator.Setup(x => x.Send(It.IsAny<GetListPropertyQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(oListResponse)
                .Verifiable();
            var res = await oPropertyController.GetListAsync(new GetListPropertyEntryModel() { Id = 1, Address = "Street1", Code = "Code", IdOwner = 1, Name = "Name", Price = 1000, Year = 2021 });
            var okResult = res as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.IsNotNull(okResult.Value);
        }
    }
}
