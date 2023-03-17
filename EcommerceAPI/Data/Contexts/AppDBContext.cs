using EcommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Data.Contexts
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
