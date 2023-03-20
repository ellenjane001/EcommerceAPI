using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Data.Handlers
{
    public class OrderHandlers
    {
        private readonly AppDBContext _dbContext;
        public OrderHandlers(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IEnumerable<Order> GetOrdersByUserId(Guid[] Guids)
        {
            return _dbContext.Orders.Where(order => Guids.Any(oId => oId.Equals(order.UserId))).ToList();
        }

    }
}
