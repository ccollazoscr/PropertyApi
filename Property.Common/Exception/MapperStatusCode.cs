using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Property.Common.Exception
{
    public static class MapperStatusCode
    {
        public static HttpStatusCode GetHttpStatusCode(EnumErrorCode errorCode) {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            switch (errorCode)
            {
                case EnumErrorCode.MandatoryNameProduct:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            return statusCode;
        }
    }
}
