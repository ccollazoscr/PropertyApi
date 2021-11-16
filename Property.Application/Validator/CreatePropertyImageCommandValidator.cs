using FluentValidation;
using Property.Application.Command;
using Property.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Validator
{
    public class CreatePropertyImageCommandValidator : AbstractValidator<CreatePropertyImageCommand>
    {
        public CreatePropertyImageCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(item => item.IdProperty)
           .GreaterThan(0).WithMessage($"{EnumErrorCode.PropertyBuildingIdValue.GetHashCode()}|IdProperty must be a value greater than zero");

            When(item => item.File == null, () =>
            {
                RuleFor(x => x.File).NotNull().WithMessage($"{EnumErrorCode.FileMandatory.GetHashCode()}|File is required");
            }).Otherwise(()=> {
                RuleFor(x => x.File).SetValidator(new FileValidator());
            });
        }


    }
}
