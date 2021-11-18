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
    class UpdatePropertyCommandValidator : AbstractValidator<UpdatePropertyCommand>
    {
        public UpdatePropertyCommandValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Property).SetValidator(new PropertyValidator());

            RuleFor(item => item.Property.Id)
           .GreaterThan(0).WithMessage($"{EnumErrorCode.PropertyBuildingIdValue.GetHashCode()}|Id must be a value greater than zero");
        }
    }
}
