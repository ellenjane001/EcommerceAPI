using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.DTO.CartItem
{
    public class UpdateCartItemDTO
    {
        [Required]
        public string CartItemName { get; set; }
    }
}
