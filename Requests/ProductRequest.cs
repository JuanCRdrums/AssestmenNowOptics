using System.ComponentModel.DataAnnotations;

namespace AssestmenNowOptics.Requests
{
    public class ProductRequest
    {
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
    }
}
