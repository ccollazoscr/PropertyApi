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
                    oErrorCode.Description = "Código de propiedad ya existe";
                    break;
                default:
                    break;
            }

            return oErrorCode;
        }
    }
}
