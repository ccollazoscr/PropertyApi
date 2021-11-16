using Microsoft.AspNetCore.Http;

namespace PropertyApi.EntryModel
{
    public class CreatePropertyImageEntryModel
    {
        public long IdProperty { get; set; }
        public IFormFile File { get; set; }
        public bool Enabled { get; set; }
    }
}
