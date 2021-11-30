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
    public class PropertyTraceConverterTest
    {
        private PropertyTraceConverter oPropertyTraceConverter;

        [SetUp]
        public void Setup()
        {
            oPropertyTraceConverter = new PropertyTraceConverter();
        }

        [Test]
        public void PropertyTraceConverter_ImplementIRequest_GetInterface()
        {
            bool IsIRequestInterface = oPropertyTraceConverter is IEntityConverter<PropertyTrace, PropertyTraceEntity>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void PropertyTraceConverter_FromEntityToModel_GetNullValue()
        {
            PropertyTrace oPropertyTrace = oPropertyTraceConverter.FromEntityToModel(null);
            Assert.IsNull(oPropertyTrace);
        }

        [Test]
        public void PropertyTraceConverter_FromEntityToModel_GetModel()
        {
            PropertyTraceEntity oPropertyTraceEntity = new PropertyTraceEntity()
            {
                DateSale = DateTime.Now,
                DateTrace = DateTime.Now,
                IdProperty = 1,
                IdPropertyTrace = 2,
                Name = "Name",
                Tax = 2000,
                Value = 100
            };
            PropertyTrace oPropertyTrace = oPropertyTraceConverter.FromEntityToModel(oPropertyTraceEntity);
            Assert.IsNotNull(oPropertyTrace);
            Assert.AreEqual(oPropertyTraceEntity.DateSale, oPropertyTrace.DateSale);
            Assert.AreEqual(oPropertyTraceEntity.DateTrace, oPropertyTrace.DateTrace);
            Assert.AreEqual(oPropertyTraceEntity.IdProperty, oPropertyTrace.PropertyBuilding.Id);
            Assert.AreEqual(oPropertyTraceEntity.IdPropertyTrace, oPropertyTrace.Id);
            Assert.AreEqual(oPropertyTraceEntity.Name, oPropertyTrace.Name);
            Assert.AreEqual(oPropertyTraceEntity.Tax, oPropertyTrace.Tax);
            Assert.AreEqual(oPropertyTraceEntity.Value, oPropertyTrace.Value);
        }

        [Test]
        public void PropertyTraceConverter_FromModelToEntity_GetEntity()
        {
            PropertyTrace oPropertyTrace = new PropertyTrace()
            {
                DateSale = DateTime.Now,
                DateTrace = DateTime.Now,
                PropertyBuilding = new PropertyBuilding() { Id  = 1 },
                Id = 2,
                Name = "Name",
                Tax = 2000,
                Value = 100
            };
            PropertyTraceEntity oPropertyTraceEntity = oPropertyTraceConverter.FromModelToEntity(oPropertyTrace);
            Assert.IsNotNull(oPropertyTraceEntity);
            Assert.AreEqual(oPropertyTrace.DateSale, oPropertyTraceEntity.DateSale);
            Assert.AreEqual(oPropertyTrace.DateTrace, oPropertyTraceEntity.DateTrace);
            Assert.AreEqual(oPropertyTrace.PropertyBuilding.Id, oPropertyTraceEntity.IdProperty);
            Assert.AreEqual(oPropertyTrace.Id, oPropertyTraceEntity.IdPropertyTrace);
            Assert.AreEqual(oPropertyTrace.Name, oPropertyTraceEntity.Name);
            Assert.AreEqual(oPropertyTrace.Tax, oPropertyTraceEntity.Tax);
            Assert.AreEqual(oPropertyTrace.Value, oPropertyTraceEntity.Value);
        }
    }
}
