using System.ComponentModel.DataAnnotations;

namespace AssestmenNowOptics.Requests
{
    public class StoreProductMappingRequest
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int StoreId { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
