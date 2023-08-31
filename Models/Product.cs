namespace AssestmenNowOptics.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public virtual ICollection<StoreProductMapping> storeProductMappings { get; set; } = new List<StoreProductMapping>();
    }
}
