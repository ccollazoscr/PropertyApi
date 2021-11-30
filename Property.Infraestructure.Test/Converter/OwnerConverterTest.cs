using NUnit.Framework;
using Property.Common.Converter;
using Property.Infraestructure.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;
using System;

namespace Property.Infraestructure.Test.Converter
{
    public class OwnerConverterTest
    {
        private OwnerConverter oOwnerConverter;

        [SetUp]
        public void Setup()
        {
            oOwnerConverter = new OwnerConverter();
        }

        [Test]
        public void OwnerConverter_ImplementIRequest_GetInterface()
        {
            bool IsIRequestInterface = oOwnerConverter is IEntityConverter<Owner, OwnerEntity>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void OwnerConverter_FromEntityToModel_GetNullValue()
        {
            Owner oOwner = oOwnerConverter.FromEntityToModel(null);
            Assert.IsNull(oOwner);
        }

        [Test]
        public void OwnerConverter_FromEntityToModel_GetModel()
        {
            OwnerEntity oOwnerEntity = new OwnerEntity()
            {
                Address = "Street1", Birthdaty = DateTime.Now, IdOwner=1, Name="Name"
            };
            Owner oOwner = oOwnerConverter.FromEntityToModel(oOwnerEntity);
            Assert.IsNotNull(oOwner);
            Assert.AreEqual(oOwnerEntity.Address, oOwner.Address);
            Assert.AreEqual(oOwnerEntity.Birthdaty, oOwner.Birthdaty);
            Assert.AreEqual(oOwnerEntity.IdOwner, oOwner.Id);
            Assert.AreEqual(oOwnerEntity.Name, oOwner.Name);
        }

        [Test]
        public void OwnerConverter_FromModelToEntity_GetEntity()
        {
            Owner oOwner = new Owner()
            {
                Address = "Street1",
                Birthdaty = DateTime.Now,
                Id = 1,
                Name = "Name"
            };
            OwnerEntity oOwnerEntity = oOwnerConverter.FromModelToEntity(oOwner);
            Assert.IsNotNull(oOwnerEntity);
            Assert.AreEqual(oOwner.Address, oOwnerEntity.Address);
            Assert.AreEqual(oOwner.Birthdaty, oOwnerEntity.Birthdaty);
            Assert.AreEqual(oOwner.Id, oOwnerEntity.IdOwner);
            Assert.AreEqual(oOwner.Name, oOwnerEntity.Name);
        }
    }
}
