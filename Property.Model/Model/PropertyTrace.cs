using System;

namespace Property.Model.Model
{
    public class PropertyTrace
    {
        public long Id { get; set; }
        public DateTime? DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal? Tax { get; set; }
        public PropertyBuilding PropertyBuilding { get; set; }
        public DateTime DateTrace { get; set; }
    }
}
