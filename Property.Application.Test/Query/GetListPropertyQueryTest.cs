using MediatR;
using NUnit.Framework;
using Property.Application.Query;
using Property.Model.Dto;
using Property.Model.Model;
using System.Collections.Generic;

namespace Property.Application.Test.Query
{
    public class GetListPropertyQueryTest
    {
        [Test]
        public void GetListPropertyQuery_ImplementIRequest_GetInterface()
        {
            GetListPropertyQuery oGetListPropertyQuery = new GetListPropertyQuery(null);
            bool IsIRequestInterface = oGetListPropertyQuery is IRequest<List<GetListPropertyDto>>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void GetListPropertyQuery_SetNullProperty_GetNullProperty()
        {
            GetListPropertyQuery oGetListPropertyQuery = new GetListPropertyQuery(null);
            Assert.That(oGetListPropertyQuery.Property, Is.EqualTo(null));
        }

        [Test]
        public void GetListPropertyQuery_SetProperty_GetValidIdProperty()
        {
            PropertyBuilding oPropertyBuilding = new PropertyBuilding() { Id = 1 };
            GetListPropertyQuery oGetListPropertyQuery = new GetListPropertyQuery(oPropertyBuilding);
            Assert.That(oGetListPropertyQuery.Property.Id, Is.EqualTo(1));
        }
    }
}
