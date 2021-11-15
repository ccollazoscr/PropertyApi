using FluentValidation;
using Property.Application.Command;
using Property.Common.Exception;

namespace Property.Application.Validator
{
    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(item => item.Property)
                .NotNull().WithMessage($"{EnumErrorCode.PropertyIdOwnerMandatory.GetHashCode()}|The property is mandatory");
            RuleFor(item => item.Property.Name)
                .NotEmpty().WithMessage($"{EnumErrorCode.PropertyCodeMandatory.GetHashCode()}|Property name is required")
                .MaximumLength(256).WithMessage($"{EnumErrorCode.PropertyCodeLength.GetHashCode()}|Name must not exceed 256 characters");
            RuleFor(item => item.Property.Address)
                .NotEmpty().WithMessage($"{EnumErrorCode.PropertyCodeMandatory.GetHashCode()}|Property address is required")
                .MaximumLength(256).WithMessage($"{EnumErrorCode.PropertyCodeLength.GetHashCode()}|Address must not exceed 256 characters");
            RuleFor(item => item.Property.Price)
                .GreaterThanOrEqualTo(0).WithMessage($"{EnumErrorCode.PropertyYearValue.GetHashCode()}|The price must be greater than or equal to zero");
            RuleFor(item => item.Property.Code)
                .NotEmpty().WithMessage($"{EnumErrorCode.PropertyCodeMandatory.GetHashCode()}|Property code is required")
                .MaximumLength(32).WithMessage($"{EnumErrorCode.PropertyCodeLength.GetHashCode()}|Code must not exceed 32 characters");
            RuleFor(item => item.Property.Year)
                .GreaterThanOrEqualTo(1900).WithMessage($"{EnumErrorCode.PropertyYearValue.GetHashCode()}|The year must be greater than or equal to 1900");
            RuleFor(item => item.Property.Owner)
                .NotNull().WithMessage($"{EnumErrorCode.PropertyOwnerMandatory.GetHashCode()}|The owner is required");
            RuleFor(item => item.Property.Owner.IdOwner)
                .NotNull().WithMessage($"{EnumErrorCode.PropertyIdOwnerMandatory.GetHashCode()}|The owner id is required")
                .GreaterThan(0).WithMessage($"{EnumErrorCode.PropertyIdOwnerValue.GetHashCode()}|The owner id must be a value greater than zero");
        }
    }
}
