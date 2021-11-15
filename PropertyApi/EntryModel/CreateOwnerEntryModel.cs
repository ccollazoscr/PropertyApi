using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyApi.EntryModel
{
    public class CreateOwnerEntryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IFormFile Photo { get; set; }
        public DateTime Birthday { get; set; }
    }
}
