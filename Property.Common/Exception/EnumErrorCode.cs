using System;
using System.Collections.Generic;
using System.Text;

namespace Property.Common.Exception
{
    public enum EnumErrorCode
    {
        Generic = 1,
        ExistCodeProperty = 10000,
        PropertyIdOwnerMandatory = 10001,
        PropertyCodeMandatory = 10002,
        PropertyCodeLength = 10003,
        PropertyYearValue = 10004,
        PropertyOwnerMandatory = 10005,
        PropertyIdOwnerValue = 10006,

        ConstraintViolated = 20001


    }
}
