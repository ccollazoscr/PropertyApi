using FluentValidation.TestHelper;
using NUnit.Framework;
using Property.Application.Command;
using Property.Application.Test.Utils;
using Property.Application.Validator;

namespace Property.Application.Test.Validator
{
    public class CreatePropertyImageCommandValidatorTest
    {
        private CreatePropertyImageCommandValidator oCreatePropertyImageCommandValidator;
        private CreatePropertyImageCommand oCreatePropertyImageCommand;

        [SetUp]
        public void Setup()
        {
            oCreatePropertyImageCommandValidator = new CreatePropertyImageCommandValidator();
            oCreatePropertyImageCommand = new CreatePropertyImageCommand().SetIdProperty(1).SetEnabled(true).SetFile(FactoryValidator.GetImageTest());
        }

        #region Validation General

        [Test]
        public void PropertyObject_AllValidation_WithoutException()
        {
            var result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            Assert.IsTrue(result.IsValid);
        }

        #endregion

        #region Validation property IdProperty

        [Test]
        public void PropertyIdProperty_GreaterThan_WithoutException()
        {
            oCreatePropertyImageCommand.IdProperty = -1;
            var result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            result.ShouldHaveValidationErrorFor(model => model.IdProperty);

            oCreatePropertyImageCommand.IdProperty = 0;
            result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            result.ShouldHaveValidationErrorFor(model => model.IdProperty);

            oCreatePropertyImageCommand.IdProperty = 1;
            result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.IdProperty);
        }

        #endregion

        #region Validation property File

        [Test]
        public void PropertyFile_NullValue_ThrowException()
        {
            oCreatePropertyImageCommand.File = null;
            var result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            result.ShouldHaveValidationErrorFor(model => model.File);
        }

        [Test]
        public void PropertyFile_ContentType_ThrowException()
        {
            oCreatePropertyImageCommand.File = FactoryValidator.GetImageTest("image/jpeg");
            var result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.File.ContentType);

            oCreatePropertyImageCommand.File = FactoryValidator.GetImageTest("image/jpg");
            result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.File.ContentType);

            oCreatePropertyImageCommand.File = FactoryValidator.GetImageTest("image/png");
            result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            result.ShouldNotHaveValidationErrorFor(model => model.File.ContentType);

            oCreatePropertyImageCommand.File = FactoryValidator.GetImageTest("image/webp");
            result = oCreatePropertyImageCommandValidator.TestValidate(oCreatePropertyImageCommand);
            result.ShouldHaveValidationErrorFor(model => model.File.ContentType);
        }

        #endregion
    }
}
