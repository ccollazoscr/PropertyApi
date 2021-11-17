using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyApi.EntryModel
{
    public class UpdatePriceEntryModel
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
    }
}
