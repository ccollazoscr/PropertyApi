using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Test.Utils;
using Property.Application.Validator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Test.Validator
{
    public class CreateOwnerCommandValidatorTest
    {
        private CreateOwnerCommandValidator oCreateOwnerCommandValidator;
        private CreateOwnerCommand oCreateOwnerCommand;

        [SetUp]
        public void Setup()
        {
            oCreateOwnerCommandValidator = new CreateOwnerCommandValidator();
            oCreateOwnerCommand = new CreateOwnerCommand { Name = "Name valid", Address="Street 1", Birthday=new DateTime(1986,11,29), Photo = FactoryValidator.GetImageTest() };
        }

        

        #region Validation General

        [Test]
        public void PropertyObject_AllValidation_WithoutException()
        {
            var result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            Assert.IsTrue(result.IsValid);
        }

        #endregion

        #region Validation property Name
        [Test]
        public void PropertyName_NotEmpty_ThrowException()
        {
            oCreateOwnerCommand.Name = null;
            var result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldHaveValidationErrorFor(model => model.Name);

            oCreateOwnerCommand.Name = "";
            result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldHaveValidationErrorFor(model => model.Name);
        }

        [Test]
        public void PropertyName_MaximumLength_ThrowException()
        {
            oCreateOwnerCommand.Name = new string('a', 128);
            var result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Name);

            oCreateOwnerCommand.Name += "a";
            result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldHaveValidationErrorFor(model => model.Name);
        }
        #endregion

        #region Validation property Address
        
        [Test]
        public void PropertyAddress_NotEmpty_ThrowException()
        {
            oCreateOwnerCommand.Address = null;
            var result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldHaveValidationErrorFor(model => model.Address);

            oCreateOwnerCommand.Address = "";
            result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldHaveValidationErrorFor(model => model.Address);
        }
        [Test]
        public void PropertyAddres_MaximumLength_ThrowException()
        {
            oCreateOwnerCommand.Address = new string('a', 256);
            var result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Address);

            oCreateOwnerCommand.Address += "a";
            result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldHaveValidationErrorFor(model => model.Address);
        }
        #endregion

        #region Validation property Photo

        [Test]
        public void PropertyPhoto_NullValue_WithoutException()
        {
            oCreateOwnerCommand.Photo = null;
            var result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Photo);
        }

        [Test]
        public void PropertyPhoto_ContentType_ThrowException()
        {
            oCreateOwnerCommand.Photo = FactoryValidator.GetImageTest("image/jpeg");
            var result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Photo.ContentType);

            oCreateOwnerCommand.Photo = FactoryValidator.GetImageTest("image/jpg");
            result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Photo.ContentType);

            oCreateOwnerCommand.Photo = FactoryValidator.GetImageTest("image/png");
            result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Photo.ContentType);

            oCreateOwnerCommand.Photo = FactoryValidator.GetImageTest("image/webp");
            result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldHaveValidationErrorFor(model => model.Photo.ContentType);            
        }

        #endregion

        #region Validation property Name
        [Test]
        public void PropertyBirthday_ValidDate_WithoutException()
        {
            oCreateOwnerCommand.Birthday = DateTime.MinValue;
            var result = oCreateOwnerCommandValidator.TestValidate(oCreateOwnerCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.Birthday);
        }
        #endregion

    }
}
