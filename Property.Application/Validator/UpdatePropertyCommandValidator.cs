using FluentValidation;
using Property.Application.Command;
using Property.Common.Exception;

namespace Property.Application.Validator
{
    public class UpdatePropertyCommandValidator : AbstractValidator<UpdatePropertyCommand>
    {
        public UpdatePropertyCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            When(item => item.Property == null, () =>
            {
                RuleFor(item => item.Property).NotEmpty().WithMessage($"{EnumErrorCode.PropertyIdOwnerMandatory.GetHashCode()}|The property is mandatory");
            }).Otherwise(() =>
            {
                RuleFor(item => item.Property.Id).GreaterThan(0).WithMessage($"{EnumErrorCode.PropertyBuildingIdValue.GetHashCode()}|Id must be a value greater than zero");
                RuleFor(x => x.Property).SetValidator(new PropertyValidator());
            });
        }
    }
}
