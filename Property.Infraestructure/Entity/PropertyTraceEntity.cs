using System;

namespace Property.Infraestructure.Entity
{
    public class PropertyTraceEntity
    {
        public long IdPropertyTrace { get; set; }
        public DateTime? DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal? Tax { get; set; }
        public long IdProperty { get; set; }
        public DateTime DateTrace { get; set; }
    }
}
