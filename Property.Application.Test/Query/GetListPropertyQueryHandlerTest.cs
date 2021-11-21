using MediatR;
using Moq;
using NUnit.Framework;
using Property.Application.Port;
using Property.Application.Query;
using Property.Model.Dto;
using Property.Model.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Property.Application.Test.Query
{
    public class GetListPropertyQueryHandlerTest
    {
        private Mock<IPropertyFinderPort> _mockPropertyFinderPort;
        private GetListPropertyQueryHandler _handler;
        [SetUp]
        public void Setup()
        {
            _mockPropertyFinderPort = new Mock<IPropertyFinderPort>();
            _handler = new GetListPropertyQueryHandler(_mockPropertyFinderPort.Object);
        }

        [Test]
        public void GetListPropertyQueryHandler_ImplementIRequestHandler_GetInterface()
        {
            bool IsIRequestInterface = _handler is IRequestHandler<GetListPropertyQuery, List<GetListPropertyDto>>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public async Task Handle_EmptyList_ReturnEmptyListAsync()
        {
            GetListPropertyQuery oGetListPropertyQuery = new GetListPropertyQuery(new PropertyBuilding() { Id = 1 });
            _mockPropertyFinderPort.Setup(m => m.GetListProperty(It.IsAny<PropertyBuilding>()))
                                               .Returns(new List<GetListPropertyDto>());
            var result = await _handler.Handle(oGetListPropertyQuery, default);
            Assert.That(result.Count,Is.EqualTo(0));
        }

        [Test]
        public async Task Handle_ListWithValues_ReturnListAsync()
        {
            GetListPropertyQuery oGetListPropertyQuery = new GetListPropertyQuery(new PropertyBuilding() { Id = 1 });
            List<GetListPropertyDto> lstPropertyDto = new List<GetListPropertyDto>() { 
                 new GetListPropertyDto(){ Id=1 },new GetListPropertyDto(){ Id=2 }, new GetListPropertyDto(){ Id=3 }
            };
            _mockPropertyFinderPort.Setup(m => m.GetListProperty(It.IsAny<PropertyBuilding>()))
                                               .Returns(lstPropertyDto);
            var result = await _handler.Handle(oGetListPropertyQuery, default);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.FirstOrDefault(), Is.EqualTo(lstPropertyDto[0]));
        }
    }
}
