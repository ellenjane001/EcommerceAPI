using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.DTO.Checkout;

namespace EcommerceAPI.Data.Repositories
{
    public class CheckoutRepository : ICheckoutRepository
    {
        private readonly AppDBContext _dbContext;
        public CheckoutRepository(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<Order> Checkout(CheckoutDTO order)
        {
            var UOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (UOrder == null)
                throw new Exception("Not Found");
            else
            {
                UOrder.Status = order.Status;
                _dbContext.Orders.Update(UOrder);
                await _dbContext.SaveChangesAsync();
                return UOrder;
            }

        }
    }
}
