using EcommerceAPI.Domain.Entities;
using EcommerceAPI.DTO.Order;

namespace EcommerceAPI.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(Guid OrderId);
        Task Put(Guid OrderId, UpdateOrderDTO order);
        Task Delete(Guid OrderId);
    }
}
