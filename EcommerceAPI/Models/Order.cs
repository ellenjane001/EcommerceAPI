using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models
{
    public class Order
    {
        [Required]
        public short Status { get; set; }
    }
}
