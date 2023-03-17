using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderId { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        //public virtual User User { get; set; } = null!;
        public short Status { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
