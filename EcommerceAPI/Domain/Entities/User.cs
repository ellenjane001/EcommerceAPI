using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
