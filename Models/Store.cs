namespace AssestmenNowOptics.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; } = "";
        public StoreProductMapping[] storeProductMappings { get; set; } = new StoreProductMapping[0];
    }
}
