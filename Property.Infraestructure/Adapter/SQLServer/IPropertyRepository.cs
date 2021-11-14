﻿using Property.Infraestructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infraestructure.Adapter.SQLServer
{
    public interface IPropertyRepository
    {
        public long Insert(PropertyEntity oPropertyEntity);

        public bool ExistProperty(string code);
    }
}
