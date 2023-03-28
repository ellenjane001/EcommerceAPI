using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Enums;

namespace EcommerceAPI.Data.Miscellaneous
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

        public OrderStatus returnEnumValue(short status)
        {
            OrderStatus stats = new OrderStatus();
            switch (status)
            {
                case 0:
                    stats = OrderStatus.Pending;
                    break;
                case 1:
                    stats = OrderStatus.Processed;
                    break;
                case 2:
                    stats = OrderStatus.Cancelled;
                    break;
            }
            return stats;
        }
    }
}
