namespace AssestmenNowOptics.Models
{
    public class StoreProductMapping
    {
        public int MappingId { get; set; }
        public int StoreId { set; get; }
        public int ProductId { set; get; }
        public int Stock { set; get; }
        public Store? Store { set; get; } = null;
        public Product? Product { set; get; } = null;
    }
}
