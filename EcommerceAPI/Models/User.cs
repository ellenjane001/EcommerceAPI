namespace EcommerceAPI.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Models.Order> Orders { get; set; } = new List<Models.Order>();
    }
}
