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
            RuleFor(x => x.Property).NotEmpty().WithMessage($"{EnumErrorCode.PropertyIdOwnerMandatory.GetHashCode()}|The property is mandatory");
            RuleFor(x => x.Property).SetValidator(new PropertyValidator());
        }
    }
}
