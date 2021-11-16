using System;
using System.Collections.Generic;
using System.Text;

namespace Property.Common.Exception
{
    public enum EnumErrorCode
    {
        Generic = 1,

        ConstraintViolated = 10000,
        SaveImageFileStorage = 10001,

        ExistCodeProperty = 20000,
        PropertyIdOwnerMandatory = 20001,
        PropertyCodeMandatory = 20002,
        PropertyCodeLength = 20003,
        PropertyYearValue = 20004,
        PropertyOwnerMandatory = 20005,
        PropertyIdOwnerValue = 20006,
        OwnerNameMandatory = 20007,
        OwnerAddressMandatory = 20008,
        OwnerNameLength = 20009,
        OwnerAddressLength = 20010,
        OwnerPhotoType = 20011,
        OwnerBirthdayMandatory = 20012,
        
        PropertyBuildingMandatory = 20014,
        PropertyBuildingIdValue = 20015,
        FileMandatory = 20016,
    }
}
