using Dapper;
using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Data.Handlers;
using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.DTO.Order;
using EcommerceAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EcommerceAPI.Data.Repositories
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
            var query = "SELECT * FROM orders";
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
        public bool Put(Guid OrderId, UpdateOrderDTO order)
        {
            var SelectOrder = _dbContext.Orders.FirstOrDefault(o => o.OrderId.Equals(OrderId));
            if (SelectOrder == null)
                return false;
            else
            {
                SelectOrder.Status = order.Status;
                _dbContext.Orders.Update(SelectOrder);
                _dbContext.SaveChanges();
                return true;
            }
        }
        public void Delete(Guid OrderId)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.OrderId == OrderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
        }
    }
}
