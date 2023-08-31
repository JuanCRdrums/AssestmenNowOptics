namespace AssestmenNowOptics.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public StoreProductMapping[] storeProductMappings { get; set; } = new StoreProductMapping[0];
    }
}
