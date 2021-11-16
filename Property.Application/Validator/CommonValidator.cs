using FluentValidation;
using Microsoft.AspNetCore.Http;
using Property.Common.Exception;

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
}
