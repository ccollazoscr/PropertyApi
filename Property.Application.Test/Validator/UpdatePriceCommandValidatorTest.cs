using FluentValidation.TestHelper;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Test.Utils;
using Property.Application.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Test.Validator
{
    public class UpdatePriceCommandValidatorTest
    {
        private UpdatePriceCommandValidator oUpdatePriceCommandValidator;
        private UpdatePriceCommand oUpdatePriceCommand;

        [SetUp]
        public void Setup()
        {
            oUpdatePriceCommandValidator = new UpdatePriceCommandValidator();
            oUpdatePriceCommand = new UpdatePriceCommand().SetId(1).SetPrice(1000);
        }

        #region Validation General

        [Test]
        public void PropertyObject_AllValidation_WithoutException()
        {
            var result = oUpdatePriceCommandValidator.TestValidate(oUpdatePriceCommand);
            Assert.IsTrue(result.IsValid);
        }

        #endregion

        #region Validation property Id

        [Test]
        public void PropertyId_GreaterThan_WithoutException()
        {
            oUpdatePriceCommand.Id = -1;
            var result = oUpdatePriceCommandValidator.TestValidate(oUpdatePriceCommand);
            result.ShouldHaveValidationErrorFor(model => model.Id);

            oUpdatePriceCommand.Id = 0;
            result = oUpdatePriceCommandValidator.TestValidate(oUpdatePriceCommand);
            result.ShouldHaveValidationErrorFor(model => model.Id);

            oUpdatePriceCommand.Id = 1;
            result = oUpdatePriceCommandValidator.TestValidate(oUpdatePriceCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Id);
        }

        #endregion

        #region Validation property Price

        [Test]
        public void PropertyPrice_GreaterThan_WithoutException()
        {
            oUpdatePriceCommand.Price = -1;
            var result = oUpdatePriceCommandValidator.TestValidate(oUpdatePriceCommand);
            result.ShouldHaveValidationErrorFor(model => model.Price);

            oUpdatePriceCommand.Price = 0;
            result = oUpdatePriceCommandValidator.TestValidate(oUpdatePriceCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Price);

            oUpdatePriceCommand.Price = 1;
            result = oUpdatePriceCommandValidator.TestValidate(oUpdatePriceCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Price);
        }

        #endregion

    }
}
