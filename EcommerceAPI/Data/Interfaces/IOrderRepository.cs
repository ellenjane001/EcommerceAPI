using EcommerceAPI.Domain.Entities;
using EcommerceAPI.DTO.Order;

namespace EcommerceAPI.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(Guid OrderId);
        bool Put(Guid OrderId, UpdateOrderDTO order);
        void Delete(Guid OrderId);
    }
}
