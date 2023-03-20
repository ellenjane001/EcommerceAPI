using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Domain.Entities
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CartItemId { get; set; }
        public string? CartItemName { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        //public virtual Order? Order { get; set; }

    }
}
