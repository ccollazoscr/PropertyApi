using FluentValidation;
using Property.Application.Command;
using Property.Common.Exception;

namespace Property.Application.Validator
{
    public class UpdatePriceCommandValidator : AbstractValidator<UpdatePriceCommand>
    {
        public UpdatePriceCommandValidator()
        {
            RuleFor(item => item.Id)
                .GreaterThan(0).WithMessage($"{EnumErrorCode.PropertyBuildingIdValue.GetHashCode()}|Id must be a value greater than zero");
            RuleFor(item => item.Price)
                .GreaterThanOrEqualTo(0).WithMessage($"{EnumErrorCode.PropertyYearValue.GetHashCode()}|The price must be greater than or equal to zero");
        }
    }
}
