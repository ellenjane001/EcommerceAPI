using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Data.DTO.Checkout;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;

namespace EcommerceAPI.Domain.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger _logger;
        public CheckoutRepository(AppDBContext dBContext, IHttpContextAccessor httpContext, ILogger logger)
        {
            _dbContext = dBContext;
            _httpContext = httpContext;
            _logger = logger;
        }
        public async Task<Order> Checkout(CheckoutDTO order)
        {
            var userId = Guid.Parse(_httpContext.HttpContext!.Request.Headers["x-user-id"]!);
            var UOrder = _dbContext.Orders.FirstOrDefault(o => o.UserId == userId && o.Status == 0);

            if (UOrder == null)
                throw new Exception("Not Found");
            else
            {
                UOrder.Status = order.Status;
                _dbContext.Orders.Update(UOrder);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Checkout Success");
                return UOrder;
            }

        }
    }
}
