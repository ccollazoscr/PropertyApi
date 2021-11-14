using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.Port
{
    public interface IPropertyFinder
    {
        bool ExistProperty(string code);
    }
}
