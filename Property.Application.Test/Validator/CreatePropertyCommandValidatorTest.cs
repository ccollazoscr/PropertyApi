using FluentValidation.TestHelper;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Validator;
using Property.Model.Model;

namespace Property.Application.Test.Validator
{
    public class CreatePropertyCommandValidatorTest
    {
        private CreatePropertyCommandValidator oCreatePropertyCommandValidator;
        private CreatePropertyCommand oCreatePropertyCommand;

        [SetUp]
        public void Setup()
        {
            oCreatePropertyCommandValidator = new CreatePropertyCommandValidator();
            oCreatePropertyCommand = new CreatePropertyCommand (GetPropertyBuilding());
        }

        #region Utils
        private PropertyBuilding GetPropertyBuilding()
        {
            PropertyBuilding oPropertyBuilding = new PropertyBuilding()
            {
                Name = "Name building",
                Address = "Address building",
                Price = 1000,
                Code = "Code building",
                Year = 2020,
                Owner = new Owner() { Id = 1, Name = "Name owner" }
            };
            return oPropertyBuilding;
        }
        #endregion

        #region Validation General

        [Test]
        public void PropertyObject_AllValidation_WithoutException()
        {
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void PropertyObject_NullValue_ThrowException()
        {
            var oCreatePropertyCommand = new CreatePropertyCommand(null);
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property);
        }
        #endregion

        #region Validation property Name
        [Test]
        public void PropertyName_NotEmpty_ThrowException()
        {
            oCreatePropertyCommand.Property.Name = null;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Name);

            oCreatePropertyCommand.Property.Name = "";
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Name);
        }

        [Test]
        public void PropertyName_MaximumLength_ThrowException()
        {
            oCreatePropertyCommand.Property.Name = new string('a', 256);
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Name);

            oCreatePropertyCommand.Property.Name += "a";
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Name);
        }
        #endregion

        #region Validation property Address
        [Test]
        public void PropertyAddress_NotEmpty_ThrowException()
        {
            oCreatePropertyCommand.Property.Address = null;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Address);

            oCreatePropertyCommand.Property.Address = "";
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Address);
        }

        [Test]
        public void PropertyAddress_MaximumLength_ThrowException()
        {
            oCreatePropertyCommand.Property.Address = new string('a', 256);
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Address);

            oCreatePropertyCommand.Property.Address += "a";
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Address);
        }
        #endregion

        #region Validation property Price
        [Test]
        public void PropertyPrice_LessThan_ThrowException()
        {
            oCreatePropertyCommand.Property.Price = -1;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Price);
        }

        [Test]
        public void PropertyPrice_GreaterThanOrEqualTo_ThrowException()
        {
            oCreatePropertyCommand.Property.Price = 0;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Price);

            oCreatePropertyCommand.Property.Price = 1;
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Price);
        }

        #endregion

        #region Validation property Code
        [Test]
        public void PropertyCode_NotEmpty_ThrowException()
        {
            oCreatePropertyCommand.Property.Code = null;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Code);

            oCreatePropertyCommand.Property.Code = "";
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Code);
        }

        [Test]
        public void PropertyCode_MaximumLength_ThrowException()
        {
            oCreatePropertyCommand.Property.Code = new string('a', 32);
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Code);

            oCreatePropertyCommand.Property.Code += "a";
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Code);
        }
        #endregion

        #region Validation property Year
        [Test]
        public void PropertyYear_LessThan_ThrowException()
        {
            oCreatePropertyCommand.Property.Year = 1899;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Year);
        }

        [Test]
        public void PropertyYear_GreaterThanOrEqualTo_ThrowException()
        {
            oCreatePropertyCommand.Property.Year = 1900;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Year);

            oCreatePropertyCommand.Property.Year = 1901;
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Year);
        }

        #endregion

        #region Validation property Owner
        [Test]
        public void PropertyOwner_NotNull_ThrowException()
        {
            oCreatePropertyCommand.Property.Owner = null;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Owner);
        }

        [Test]
        public void PropertyOwner_GreaterThan_WithoutException()
        {
            oCreatePropertyCommand.Property.Owner.Id = -1;
            var result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Owner.Id);

            oCreatePropertyCommand.Property.Owner.Id = 0;
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Owner.Id);

            oCreatePropertyCommand.Property.Owner.Id = 1;
            result = oCreatePropertyCommandValidator.TestValidate(oCreatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Owner.Id);
        }

        #endregion
    }
}
