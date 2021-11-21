using MediatR;
using NUnit.Framework;
using Property.Application.Command;
using Property.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Test.Command
{
    public class UpdatePriceCommandTest
    {

        private UpdatePriceCommand oUpdatePriceCommand;
        [SetUp]
        public void Setup()
        {
            oUpdatePriceCommand = new UpdatePriceCommand();
        }

        [Test]
        public void UpdatePriceCommandTest_ImplementIRequest_GetInterface()
        {
            UpdatePriceCommand oUpdatePriceCommand = new UpdatePriceCommand();
            bool IsIRequestInterface = oUpdatePriceCommand is IRequest<ResponseDto>;
            Assert.IsTrue(IsIRequestInterface);
        }

        [Test]
        public void SetId_SetLong_GetLongValid()
        {
            var res = oUpdatePriceCommand.SetId(1);
            Assert.That(oUpdatePriceCommand.Id, Is.EqualTo(1));
            Assert.That(res.GetType(), Is.EqualTo(typeof(UpdatePriceCommand)));
        }

        [Test]
        public void SetPrice_SetDecimal_GetDecimalValid()
        {
            var res = oUpdatePriceCommand.SetPrice(1000);
            Assert.That(oUpdatePriceCommand.Price, Is.EqualTo(1000));
            Assert.That(res.GetType(), Is.EqualTo(typeof(UpdatePriceCommand)));
        }
    }
}
