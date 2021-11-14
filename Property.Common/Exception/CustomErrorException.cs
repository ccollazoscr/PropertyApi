using System;
using System.Collections.Generic;

namespace Property.Common.Exception
{
    public sealed class CustomErrorException : SystemException
    {
        
        private List<ErrorCode> lstErrorCode = new List<ErrorCode>();


        public CustomErrorException(EnumErrorCode errorCode)
        {
            lstErrorCode.Add(FactoryErrorCode.GetErrorCode(errorCode));
        }

        public CustomErrorException(List<ErrorCode> lstErrorCode)
        {
            this.lstErrorCode = lstErrorCode;
        }

        public List<ErrorCode> GetListError()
        {
            return lstErrorCode;
        }
    }
}
