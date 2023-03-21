using Dapper;
using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Data.DTO.Order;
using EcommerceAPI.Data.Miscellaneous;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EcommerceAPI.Domain.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly IDbConnection _connection;
        public OrderRepository(AppDBContext dataContext, AppDapperContext dapperContext)
        {
            _dbContext = dataContext;
            _connection = dapperContext.CreateConnection();
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var CartItemHandlers = new CartItemHandlers(_dbContext);
            var query = "SELECT * FROM orders WHERE status = 0";
            _connection.Open();
            var orders = await _connection.QueryAsync<Order>(query);
            var orderIds = orders.Select(order => order.OrderId).ToArray();
            var cartItems = CartItemHandlers.GetCartItemsByOrderId(orderIds);
            foreach (var order in orders)
            {
                order.CartItems = cartItems.Where(cartItem => cartItem.OrderId == order.OrderId).ToList();
            }
            return orders.ToList();
        }
        public async Task<Order> GetOrder(Guid OrderId)
        {
            var query = "SELECT * FROM orders WHERE OrderId=@OrderId";
            var parameters = new { OrderId };
            _connection.Open();
            var orders = await _connection.QueryAsync<Order>(query, parameters);
            var order = orders.First();
            var cartItems = await _dbContext.CartItems.Where(cartItem => order.OrderId.Equals(cartItem.OrderId)).ToListAsync();
            order.CartItems = cartItems;
            return order;
        }
        public async Task Put(Guid OrderId, UpdateOrderDTO order)
        {
            var SelectOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderId.Equals(OrderId)) ?? throw new Exception("Not Found");
            SelectOrder!.Status = order.Status;
            _dbContext.Orders.Update(SelectOrder);
            await _dbContext.SaveChangesAsync();

        }
        public async Task Delete(Guid OrderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderId == OrderId) ?? throw new Exception("Not Found");
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
