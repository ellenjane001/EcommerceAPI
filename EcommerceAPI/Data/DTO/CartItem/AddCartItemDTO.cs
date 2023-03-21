using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Data.DTO.CartItem
{
    public class AddCartItemDTO
    {
        [Required]
        public string? CartItemName { get; set; }
    }
}
