using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Data.DTO.CartItem
{
    public class UpdateCartItemDTO
    {
        [Required]
        public string CartItemName { get; set; }
    }
}
