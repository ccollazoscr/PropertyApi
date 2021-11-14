using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Property.Common.Exception
{
    public class ErrorCode
    {
        public HttpStatusCode StatusCode { get; set; }
        public EnumErrorCode Code { get; set; }
        public string Description { get; set; }
    }
}
