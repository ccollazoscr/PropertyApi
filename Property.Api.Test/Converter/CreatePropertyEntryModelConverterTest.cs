using NUnit.Framework;
using Property.Common.Converter;
using Property.Model.Model;
using PropertyApi.Converter;
using PropertyApi.EntryModel;

namespace Property.Api.Test.Converter
{
    public class CreatePropertyEntryModelConverterTest
    {
        private CreatePropertyEntryModelConverter oCreatePropertyEntryModelConverter;

        [SetUp]
        public void Setup()
        {
            oCreatePropertyEntryModelConverter = new CreatePropertyEntryModelConverter();
        }

        [Test]
        public void CreatePropertyEntryModelConverter_ImplementIEntryModelConverter_GetInterface()
        {
            bool IsIRequestInterface = oCreatePropertyEntryModelConverter is IEntryModelConverter<CreatePropertyEntryModel, PropertyBuilding>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void CreatePropertyEntryModelConverter_FromEntryModeToModel_GetNullValue()
        {
            PropertyBuilding oPropertyBuilding = oCreatePropertyEntryModelConverter.FromEntryModelToModel(null);
            Assert.IsNull(oPropertyBuilding);
        }

        [Test]
        public void SecurityUserConverter_FromEntryModelToModel_GetModel()
        {
            CreatePropertyEntryModel oCreatePropertyEntryModel = new CreatePropertyEntryModel()
            {
                IdOwner = 1,
                Address = "Street 1",
                Code = "Code",
                Name = "Name",
                Price = 1000,
                Year = 2021
            };
            PropertyBuilding oPropertyBuilding = oCreatePropertyEntryModelConverter.FromEntryModelToModel(oCreatePropertyEntryModel);
            Assert.IsNotNull(oPropertyBuilding);
            Assert.AreEqual(oCreatePropertyEntryModel.IdOwner, oPropertyBuilding.Owner.Id);
            Assert.AreEqual(oCreatePropertyEntryModel.Address, oPropertyBuilding.Address);
            Assert.AreEqual(oCreatePropertyEntryModel.Code, oPropertyBuilding.Code);
            Assert.AreEqual(oCreatePropertyEntryModel.Name, oPropertyBuilding.Name);
            Assert.AreEqual(oCreatePropertyEntryModel.Price, oPropertyBuilding.Price);
            Assert.AreEqual(oCreatePropertyEntryModel.Year, oPropertyBuilding.Year);
        }

        [Test]
        public void SecurityUserConverter_FromModelToEntryModel_GetModel()
        {
            PropertyBuilding oPropertyBuilding = new PropertyBuilding()
            {
                Owner = new Owner() { Id = 1 },
                Address = "Street 1",
                Code = "Code",
                Name = "Name",
                Price = 1000,
                Year = 2021
            };
            CreatePropertyEntryModel oCreatePropertyEntryModel = oCreatePropertyEntryModelConverter.FromModelToEntryModel(oPropertyBuilding);
            Assert.IsNotNull(oPropertyBuilding);
            Assert.AreEqual(oPropertyBuilding.Owner.Id, oCreatePropertyEntryModel.IdOwner);
            Assert.AreEqual(oPropertyBuilding.Address, oCreatePropertyEntryModel.Address);
            Assert.AreEqual(oPropertyBuilding.Code, oCreatePropertyEntryModel.Code);
            Assert.AreEqual(oPropertyBuilding.Name, oCreatePropertyEntryModel.Name);
            Assert.AreEqual(oPropertyBuilding.Price, oCreatePropertyEntryModel.Price);
            Assert.AreEqual(oPropertyBuilding.Year, oCreatePropertyEntryModel.Year);
        }
    }
}
