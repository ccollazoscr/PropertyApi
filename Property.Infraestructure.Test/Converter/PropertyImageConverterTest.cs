using NUnit.Framework;
using Property.Common.Converter;
using Property.Infraestructure.Converter;
using Property.Infraestructure.Entity;
using Property.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Test.Converter
{
    public class PropertyImageConverterTest
    {
        private PropertyImageConverter oPropertyImageConverter;

        [SetUp]
        public void Setup()
        {
            oPropertyImageConverter = new PropertyImageConverter();
        }

        [Test]
        public void PropertyImageConverter_ImplementIRequest_GetInterface()
        {
            bool IsIRequestInterface = oPropertyImageConverter is IEntityConverter<PropertyImage, PropertyImageEntity>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void PropertyImageConverter_FromEntityToModel_GetNullValue()
        {
            PropertyImage oPropertyImage = oPropertyImageConverter.FromEntityToModel(null);
            Assert.IsNull(oPropertyImage);
        }

        [Test]
        public void PropertyConverter_FromEntityToModel_GetModel()
        {
            PropertyImageEntity oPropertyImageEntity = new PropertyImageEntity()
            {
                Enabled = true,
                IdProperty = 1,
                IdPropertyImage = 2
            };
            PropertyImage oPropertyImage = oPropertyImageConverter.FromEntityToModel(oPropertyImageEntity);
            Assert.IsNotNull(oPropertyImage);
            Assert.AreEqual(oPropertyImageEntity.Enabled, oPropertyImage.Enabled);
            Assert.AreEqual(oPropertyImageEntity.IdProperty, oPropertyImage.PropertyBuilding.Id);
            Assert.AreEqual(oPropertyImageEntity.IdPropertyImage, oPropertyImage.Id);
        }

        [Test]
        public void PropertyConverter_FromModelToEntity_GetEntity()
        {
            PropertyImage oPropertyImage = new PropertyImage()
            {
                Enabled = true,
                Id = 1,
                PropertyBuilding = new PropertyBuilding() { Id = 2 }
            };
            PropertyImageEntity oPropertyImageEntity = oPropertyImageConverter.FromModelToEntity(oPropertyImage);
            Assert.IsNotNull(oPropertyImageEntity);
            Assert.AreEqual(oPropertyImage.Enabled, oPropertyImageEntity.Enabled);
            Assert.AreEqual(oPropertyImage.Id, oPropertyImageEntity.IdPropertyImage);
            Assert.AreEqual(oPropertyImage.PropertyBuilding.Id, oPropertyImageEntity.IdProperty);
        }
    }
}
