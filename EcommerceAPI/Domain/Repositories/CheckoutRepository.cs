using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Data.DTO.Checkout;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;

namespace EcommerceAPI.Domain.Repositories
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
