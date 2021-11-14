using System;
using System.Collections.Generic;
using System.Text;

namespace Property.Common.Converter
{
    public interface IEntryModelConverter<V, M> where V : class where M : class
    {
        M FromEntryModelToModel(V source);
        V FromModelToEntryModel(M source);
    }
}
