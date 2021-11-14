using FluentValidation;
using MediatR;
using Property.Common.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.SeedWork
{
    public class RequestValidationBehavior<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;
        public RequestValidationBehavior(IValidator<TRequest>[] validators) =>
                                                             _validators = validators;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var r = request;
            var validationFailures = _validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure != null)
            .ToList();

            if (validationFailures.Any())
            {
                List<ErrorCode> lstCustomErrorException = new List<ErrorCode>();
                foreach (var item in validationFailures)
                {
                    ErrorCode objErrorCode = new ErrorCode();
                    if (item.ErrorMessage.Contains('|'))
                    {
                        string[] lstErrorCode = item.ErrorMessage.Split('|');
                        objErrorCode.Description = lstErrorCode[0];
                        objErrorCode.Code = (EnumErrorCode)Enum.Parse(typeof(EnumErrorCode), lstErrorCode[1]);
                    }
                    else
                    {
                        objErrorCode.Description = item.ErrorMessage;
                    }
                    lstCustomErrorException.Add(objErrorCode);
                }
                throw new CustomErrorException(lstCustomErrorException);
            }

            return next();
        }
    }
}
