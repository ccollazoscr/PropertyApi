using FluentValidation;
using Microsoft.AspNetCore.Http;
using Property.Application.Command;
using Property.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           .MaximumLength(128).WithMessage($"{EnumErrorCode.OwnerAddressLength.GetHashCode()}|Address must not exceed 128 characters");

            When(item => item.Photo != null, () =>
            {
                RuleFor(x => x.Photo).SetValidator(new FileValidator());
            });

            RuleFor(item => item.Birthday)
            .NotNull().WithMessage($"{EnumErrorCode.OwnerBirthdayMandatory.GetHashCode()}|Owner birthay is required");
        }

        public class FileValidator : AbstractValidator<IFormFile>
        {
            public FileValidator()
            {
                RuleFor(x => x.ContentType).Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                    .WithMessage($"{EnumErrorCode.OwnerPhotoType.GetHashCode()}|File type Photo is not allowed");
            }
        }
    }
}
