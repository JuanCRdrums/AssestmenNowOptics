namespace AssestmenNowOptics.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; } = "";
        public virtual ICollection<StoreProductMapping> storeProductMappings { get; set; } = new List<StoreProductMapping>();
    }
}
