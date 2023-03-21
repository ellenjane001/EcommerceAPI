using EcommerceAPI.Data.DTO.Order;
using EcommerceAPI.Domain.Entities;

namespace EcommerceAPI.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(Guid OrderId);
        Task Put(Guid OrderId, UpdateOrderDTO order);
        Task Delete(Guid OrderId);
    }
}
