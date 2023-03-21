using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Models
{
    public class CartItem
    {
        [Required]
        public string CartItemName { get; set; }
    }
}
