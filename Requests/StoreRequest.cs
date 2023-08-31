using System.ComponentModel.DataAnnotations;

namespace AssestmenNowOptics.Requests
{
    public class StoreRequest
    {
        [Required]
        [StringLength(50)]
        public string StoreName { get; set; }
    }
}
