using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public string? Status { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
