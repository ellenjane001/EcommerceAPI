using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.DTO.CartItem
{
    public class AddCartItemDTO
    {
        [Required]
        public string CartItemName { get; set; }
        //[Required]
        //public Guid UserId { get; set; }

    }
}
