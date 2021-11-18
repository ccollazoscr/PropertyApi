using FluentValidation;
using Microsoft.AspNetCore.Http;
using Property.Common.Exception;
using Property.Model.Model;

namespace Property.Application.Validator
{
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(x => x.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage($"{EnumErrorCode.OwnerPhotoType.GetHashCode()}|File type Photo is not allowed");
        }
    }

    public class PropertyValidator : AbstractValidator<PropertyBuilding>
    {
        public PropertyValidator()
        {
            RuleFor(item => item)
                .NotNull().WithMessage($"{EnumErrorCode.PropertyIdOwnerMandatory.GetHashCode()}|The property is mandatory");
            RuleFor(item => item.Name)
                .NotEmpty().WithMessage($"{EnumErrorCode.PropertyCodeMandatory.GetHashCode()}|Property name is required")
                .MaximumLength(256).WithMessage($"{EnumErrorCode.PropertyCodeLength.GetHashCode()}|Name must not exceed 256 characters");
            RuleFor(item => item.Address)
                .NotEmpty().WithMessage($"{EnumErrorCode.PropertyCodeMandatory.GetHashCode()}|Property address is required")
                .MaximumLength(256).WithMessage($"{EnumErrorCode.PropertyCodeLength.GetHashCode()}|Address must not exceed 256 characters");
            RuleFor(item => item.Price)
                .GreaterThanOrEqualTo(0).WithMessage($"{EnumErrorCode.PropertyYearValue.GetHashCode()}|The price must be greater than or equal to zero");
            RuleFor(item => item.Code)
                .NotEmpty().WithMessage($"{EnumErrorCode.PropertyCodeMandatory.GetHashCode()}|Property code is required")
                .MaximumLength(32).WithMessage($"{EnumErrorCode.PropertyCodeLength.GetHashCode()}|Code must not exceed 32 characters");
            RuleFor(item => item.Year)
                .GreaterThanOrEqualTo(1900).WithMessage($"{EnumErrorCode.PropertyYearValue.GetHashCode()}|The year must be greater than or equal to 1900");
            RuleFor(item => item.Owner)
                .NotNull().WithMessage($"{EnumErrorCode.PropertyOwnerMandatory.GetHashCode()}|The owner is required");
            RuleFor(item => item.Owner.Id)
                .NotNull().WithMessage($"{EnumErrorCode.PropertyIdOwnerMandatory.GetHashCode()}|The owner id is required")
                .GreaterThan(0).WithMessage($"{EnumErrorCode.PropertyIdOwnerValue.GetHashCode()}|The owner id must be a value greater than zero");
        }
    }
}
