using System.Net;

namespace Property.Common.Exception
{
    public static class FactoryErrorCode
    {
        public static ErrorCode GetErrorCode(EnumErrorCode errorCode) {
            ErrorCode oErrorCode = new ErrorCode { Code = errorCode };
            oErrorCode.StatusCode = HttpStatusCode.BadRequest;
            switch (errorCode)
            {
                case EnumErrorCode.ExistCodeProperty:
                    oErrorCode.Description = "Property code already exists";
                    break;
                case EnumErrorCode.ConstraintViolated:
                    oErrorCode.Description = "Constraint violated. Please review all references.";
                    break;
                case EnumErrorCode.SaveImageFileStorage:
                    oErrorCode.Description = "Error save image";
                    break;
                case EnumErrorCode.UnauthorizedUser:
                    oErrorCode.Description = "Unauthorized user";
                    oErrorCode.StatusCode = HttpStatusCode.Unauthorized;
                    break;
                default:
                    break;
            }

            return oErrorCode;
        }
    }
}
