using FluentValidation;
using Property.Application.Command;
using Property.Common.Exception;
using Property.Model.Model;

namespace Property.Application.Validator
{
    public class CreatePropertyCommandValidator : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Property).SetValidator(new PropertyValidator());
        }
    }
}
