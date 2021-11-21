using FluentValidation.TestHelper;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Validator;
using Property.Model.Model;

namespace Property.Application.Test.Validator
{
    public class UpdatePropertyCommandValidatorTest
    {
        private UpdatePropertyCommandValidator oUpdatePropertyCommandValidator;
        private UpdatePropertyCommand oUpdatePropertyCommand;

        [SetUp]
        public void Setup()
        {
            oUpdatePropertyCommandValidator = new UpdatePropertyCommandValidator();
            oUpdatePropertyCommand = new UpdatePropertyCommand(GetPropertyBuilding());
        }

        #region Utils
        private PropertyBuilding GetPropertyBuilding()
        {
            PropertyBuilding oPropertyBuilding = new PropertyBuilding()
            {
                Id = 1,
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
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void PropertyObject_NullValue_ThrowException()
        {
            var oUpdatePropertyCommand = new UpdatePropertyCommand(null);
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property);
        }
        #endregion

        #region Validation property Id

        [Test]
        public void PropertyId_GreaterThan_WithoutException()
        {
            oUpdatePropertyCommand.Property.Id = -1;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Id);

            oUpdatePropertyCommand.Property.Id = 0;
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Id);

            oUpdatePropertyCommand.Property.Id = 1;
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Id);
        }

        #endregion

        #region Validation property Name
        [Test]
        public void PropertyName_NotEmpty_ThrowException()
        {
            oUpdatePropertyCommand.Property.Name = null;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Name);

            oUpdatePropertyCommand.Property.Name = "";
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Name);
        }

        [Test]
        public void PropertyName_MaximumLength_ThrowException()
        {
            oUpdatePropertyCommand.Property.Name = new string('a', 256);
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Name);

            oUpdatePropertyCommand.Property.Name += "a";
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Name);
        }
        #endregion

        #region Validation property Address
        [Test]
        public void PropertyAddress_NotEmpty_ThrowException()
        {
            oUpdatePropertyCommand.Property.Address = null;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Address);

            oUpdatePropertyCommand.Property.Address = "";
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Address);
        }

        [Test]
        public void PropertyAddress_MaximumLength_ThrowException()
        {
            oUpdatePropertyCommand.Property.Address = new string('a', 256);
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Address);

            oUpdatePropertyCommand.Property.Address += "a";
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Address);
        }
        #endregion

        #region Validation property Price
        [Test]
        public void PropertyPrice_LessThan_ThrowException()
        {
            oUpdatePropertyCommand.Property.Price = -1;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Price);
        }

        [Test]
        public void PropertyPrice_GreaterThanOrEqualTo_ThrowException()
        {
            oUpdatePropertyCommand.Property.Price = 0;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Price);

            oUpdatePropertyCommand.Property.Price = 1;
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Price);
        }

        #endregion

        #region Validation property Code
        [Test]
        public void PropertyCode_NotEmpty_ThrowException()
        {
            oUpdatePropertyCommand.Property.Code = null;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Code);

            oUpdatePropertyCommand.Property.Code = "";
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Code);
        }

        [Test]
        public void PropertyCode_MaximumLength_ThrowException()
        {
            oUpdatePropertyCommand.Property.Code = new string('a', 32);
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Code);

            oUpdatePropertyCommand.Property.Code += "a";
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Code);
        }
        #endregion

        #region Validation property Year
        [Test]
        public void PropertyYear_LessThan_ThrowException()
        {
            oUpdatePropertyCommand.Property.Year = 1899;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Year);
        }

        [Test]
        public void PropertyYear_GreaterThanOrEqualTo_ThrowException()
        {
            oUpdatePropertyCommand.Property.Year = 1900;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Year);

            oUpdatePropertyCommand.Property.Year = 1901;
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Year);
        }

        #endregion

        #region Validation property Owner
        [Test]
        public void PropertyOwner_NotNull_ThrowException()
        {
            oUpdatePropertyCommand.Property.Owner = null;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Owner);
        }

        [Test]
        public void PropertyOwner_GreaterThan_WithoutException()
        {
            oUpdatePropertyCommand.Property.Owner.Id = -1;
            var result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Owner.Id);

            oUpdatePropertyCommand.Property.Owner.Id = 0;
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldHaveValidationErrorFor(model => model.Property.Owner.Id);

            oUpdatePropertyCommand.Property.Owner.Id = 1;
            result = oUpdatePropertyCommandValidator.TestValidate(oUpdatePropertyCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Property.Owner.Id);
        }

        #endregion
    }
}
