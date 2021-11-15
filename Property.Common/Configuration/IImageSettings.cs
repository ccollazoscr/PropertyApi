using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Common.Configuration
{
    public interface IImageSettings
    {
        string GetRootFolder();
        string GetOwnerFolder();
        string GetPropertyFolder();
    }
}
