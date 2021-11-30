using NUnit.Framework;
using Property.Common.Converter;
using Property.Infraestructure.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;

namespace Property.Infraestructure.Test.Converter
{
    public class PropertyConverterTest
    {
        private PropertyConverter oPropertyConverter;

        [SetUp]
        public void Setup()
        {
            oPropertyConverter = new PropertyConverter();
        }

        [Test]
        public void PropertyConverter_ImplementIRequest_GetInterface()
        {
            bool IsIRequestInterface = oPropertyConverter is IEntityConverter<PropertyBuilding, PropertyEntity>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void PropertyConverter_FromEntityToModel_GetNullValue()
        {
            PropertyBuilding oPropertyBuilding = oPropertyConverter.FromEntityToModel(null);
            Assert.IsNull(oPropertyBuilding);
        }

        [Test]
        public void PropertyConverter_FromEntityToModel_GetModel()
        {
            PropertyEntity oPropertyEntity = new PropertyEntity()
            {
                Address = "Street1",
                Name = "Name",
                CodeInternal = "Code",
                IdProperty = 1,
                IdOwner = 1,
                Price = 1000,
                Year = 2021
            };
            PropertyBuilding oPropertyBuilding = oPropertyConverter.FromEntityToModel(oPropertyEntity);
            Assert.IsNotNull(oPropertyBuilding);
            Assert.AreEqual(oPropertyEntity.Address, oPropertyBuilding.Address);
            Assert.AreEqual(oPropertyEntity.Name, oPropertyBuilding.Name);
            Assert.AreEqual(oPropertyEntity.IdOwner, oPropertyBuilding.Owner.Id);
            Assert.AreEqual(oPropertyEntity.Price, oPropertyBuilding.Price);
            Assert.AreEqual(oPropertyEntity.Year, oPropertyBuilding.Year);
        }

        [Test]
        public void PropertyConverter_FromModelToEntity_GetEntity()
        {
            PropertyBuilding oPropertyBuilding = new PropertyBuilding()
            {
                Address = "Street1",
                Name = "Name",
                Code = "Code",
                Id = 1,
                Owner = new Owner() { Id = 1 },
                Price = 1000,
                Year = 2021
            };
            PropertyEntity oPropertyEntity = oPropertyConverter.FromModelToEntity(oPropertyBuilding);
            Assert.IsNotNull(oPropertyEntity);
            Assert.AreEqual(oPropertyBuilding.Address, oPropertyEntity.Address);
            Assert.AreEqual(oPropertyBuilding.Name, oPropertyEntity.Name);
            Assert.AreEqual(oPropertyBuilding.Code, oPropertyEntity.CodeInternal);
            Assert.AreEqual(oPropertyBuilding.Id, oPropertyEntity.IdProperty);
            Assert.AreEqual(oPropertyBuilding.Owner.Id, oPropertyEntity.IdOwner);
            Assert.AreEqual(oPropertyBuilding.Price, oPropertyEntity.Price);
            Assert.AreEqual(oPropertyBuilding.Year, oPropertyEntity.Year);
        }
    }
}
