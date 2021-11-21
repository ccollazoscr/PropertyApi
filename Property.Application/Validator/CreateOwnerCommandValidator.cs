using FluentValidation;
using Property.Application.Command;
using Property.Common.Exception;

namespace Property.Application.Validator
{
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(item => item.Name)
            .NotEmpty().WithMessage($"{EnumErrorCode.OwnerNameMandatory.GetHashCode()}|Owner name is required")
            .MaximumLength(128).WithMessage($"{EnumErrorCode.OwnerNameLength.GetHashCode()}|Name must not exceed 128 characters");

            RuleFor(item => item.Address)
           .NotEmpty().WithMessage($"{EnumErrorCode.OwnerAddressMandatory.GetHashCode()}|Owner address is required")
           .MaximumLength(256).WithMessage($"{EnumErrorCode.OwnerAddressLength.GetHashCode()}|Address must not exceed 256 characters");

            When(item => item.Photo != null, () =>
            {
                RuleFor(x => x.Photo).SetValidator(new FileValidator());
            });

            RuleFor(item => item.Birthday)
            .NotNull().WithMessage($"{EnumErrorCode.OwnerBirthdayMandatory.GetHashCode()}|Owner birthay is required");
        }

        
    }
}
