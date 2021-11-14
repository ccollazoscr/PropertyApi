namespace PropertyApi.EntryModel
{
    public class CreatePropertyEntryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public int Year { get; set; }
        public long IdOwner { get; set; }
    }
}
