namespace Property.Model.Model
{
    public class PropertyBuilding
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Code { get; set; }
        public int Year { get; set; }
        public Owner Owner { get; set; }
    }
}
