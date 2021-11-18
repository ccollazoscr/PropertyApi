using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

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
                default:
                    break;
            }

            return oErrorCode;
        }
    }
}
