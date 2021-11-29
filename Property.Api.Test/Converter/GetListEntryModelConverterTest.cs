using NUnit.Framework;
using Property.Common.Converter;
using Property.Model.Model;
using PropertyApi.Converter;
using PropertyApi.EntryModel;

namespace Property.Api.Test.Converter
{
    public class GetListEntryModelConverterTest
    {
        private GetListEntryModelConverter oGetListEntryModelConverter;

        [SetUp]
        public void Setup()
        {
            oGetListEntryModelConverter = new GetListEntryModelConverter();
        }

        [Test]
        public void GetListEntryModelConverter_IEntryModelConverter_GetInterface()
        {
            bool IsIRequestInterface = oGetListEntryModelConverter is IEntryModelConverter<GetListPropertyEntryModel, PropertyBuilding>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void GetListEntryModelConverter_FromEntryModeToModel_GetNullValue()
        {
            PropertyBuilding oPropertyBuilding = oGetListEntryModelConverter.FromEntryModelToModel(null);
            Assert.IsNull(oPropertyBuilding);
        }

        [Test]
        public void GetListEntryModelConverter_FromEntryModelToModel_GetModel()
        {
            GetListPropertyEntryModel oGetListPropertyEntryModel = new GetListPropertyEntryModel()
            {
                IdOwner = 1,
                Address = "Street 1",
                Code = "Code",
                Name = "Name",
                Price = 1000,
                Year = 2021,
                Id = 1
            };
            PropertyBuilding oPropertyBuilding = oGetListEntryModelConverter.FromEntryModelToModel(oGetListPropertyEntryModel);
            Assert.IsNotNull(oPropertyBuilding);
            Assert.AreEqual(oGetListPropertyEntryModel.IdOwner, oPropertyBuilding.Owner.Id);
            Assert.AreEqual(oGetListPropertyEntryModel.Address, oPropertyBuilding.Address);
            Assert.AreEqual(oGetListPropertyEntryModel.Code, oPropertyBuilding.Code);
            Assert.AreEqual(oGetListPropertyEntryModel.Name, oPropertyBuilding.Name);
            Assert.AreEqual(oGetListPropertyEntryModel.Price, oPropertyBuilding.Price);
            Assert.AreEqual(oGetListPropertyEntryModel.Year, oPropertyBuilding.Year);
            Assert.AreEqual(oGetListPropertyEntryModel.Id, oPropertyBuilding.Id);
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
            GetListPropertyEntryModel oGetListPropertyEntryModel = oGetListEntryModelConverter.FromModelToEntryModel(oPropertyBuilding);
            Assert.IsNotNull(oPropertyBuilding);
            Assert.AreEqual(oPropertyBuilding.Owner.Id, oGetListPropertyEntryModel.IdOwner);
            Assert.AreEqual(oPropertyBuilding.Address, oGetListPropertyEntryModel.Address);
            Assert.AreEqual(oPropertyBuilding.Code, oGetListPropertyEntryModel.Code);
            Assert.AreEqual(oPropertyBuilding.Name, oGetListPropertyEntryModel.Name);
            Assert.AreEqual(oPropertyBuilding.Price, oGetListPropertyEntryModel.Price);
            Assert.AreEqual(oPropertyBuilding.Year, oGetListPropertyEntryModel.Year);
        }
    }
}
