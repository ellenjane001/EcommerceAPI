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
        private readonly ILogger _logger;
        public OrderRepository(AppDBContext dataContext, AppDapperContext dapperContext, ILogger logger)
        {
            _dbContext = dataContext;
            _connection = dapperContext.CreateConnection();
            _logger = logger;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var CartItemHandlers = new CartItemHandlers(_dbContext);
            var query = "SELECT * FROM orders WHERE status = 0";
            _connection.Open();
            _logger.LogInformation("initialize connection");
            var orders = await _connection.QueryAsync<Order>(query);
            var orderIds = orders.Select(order => order.OrderId).ToArray();
            var cartItems = CartItemHandlers.GetCartItemsByOrderId(orderIds);
            foreach (var order in orders)
            {
                order.CartItems = cartItems.Where(cartItem => cartItem.OrderId == order.OrderId).ToList();
            }
            _logger.LogInformation("Fetch Cart Items Success");
            return orders.ToList();
        }
        public async Task<Order> GetOrder(Guid OrderId)
        {
            var query = "SELECT * FROM orders WHERE OrderId=@OrderId";
            var parameters = new { OrderId };
            _logger.LogInformation("initialize connection");
            _connection.Open();
            var orders = await _connection.QueryAsync<Order>(query, parameters);
            var order = orders.First();
            var cartItems = await _dbContext.CartItems.Where(cartItem => order.OrderId.Equals(cartItem.OrderId)).ToListAsync();
            order.CartItems = cartItems;
            _logger.LogInformation("get individual cart success");
            return order;
        }
        public async Task Put(Guid OrderId, UpdateOrderDTO order)
        {
            var SelectOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderId.Equals(OrderId)) ?? throw new Exception("Not Found");
            SelectOrder!.Status = order.Status;
            _dbContext.Orders.Update(SelectOrder);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Put {OrderId} Success");
        }
        public async Task Delete(Guid OrderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderId == OrderId) ?? throw new Exception("Not Found");
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Delete {OrderId} success");
        }
    }
}
