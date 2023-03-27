using Dapper;
using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Data.DTO.CartItem;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EcommerceAPI.Domain.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly IDbConnection _connection;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger _logger;

        public CartItemRepository(AppDBContext dbContext, AppDapperContext dapperContext, IHttpContextAccessor contextAccessor, ILogger<CartItemRepository> logger)
        {
            _dbContext = dbContext;
            _connection = dapperContext.CreateConnection();
            _contextAccessor = contextAccessor;
            _logger = logger;
        }

        public async Task<IEnumerable<Entities.CartItem>> GetCartItems()
        {
            var uid = Guid.Parse(_contextAccessor.HttpContext!.Request.Headers["x-user-id"]!);
            var orderQuery = "SELECT * FROM orders WHERE status = 0 AND UserId = @UserId";
            var parameters = new { UserId = uid };
            _connection.Open();
            var orders = await _connection.QueryAsync<Entities.Order>(orderQuery, parameters);
            IEnumerable<Entities.CartItem> cartItems = new List<Entities.CartItem>();
            foreach (var order in orders)
            {
                var query = "SELECT * FROM cartitems WHERE OrderId = @OrderId";
                var parameter = new { order.OrderId };
                cartItems = await _connection.QueryAsync<Entities.CartItem>(query, parameter);
            }

            _logger.LogInformation("Successfully fetched cartItems");
            return cartItems;
        }
        public async Task<Guid> Post(AddCartItemDTO cartItem)
        {
            var userId = _contextAccessor.HttpContext!.Request.Headers["x-user-id"].FirstOrDefault();
            Guid userID = Guid.Parse(userId!);
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserId == userID);
            var orderChecker = await _dbContext.Orders.FirstOrDefaultAsync(order => order.UserId == userID && order.Status == 0);

            Entities.CartItem newCartItem = new()
            {
                CartItemName = cartItem.CartItemName,
                UserId = user!.UserId,
            };
            if (orderChecker != null && orderChecker.Status == 0)
            {
                newCartItem.OrderId = orderChecker.OrderId;
                orderChecker.CartItems.Add(newCartItem);
                _dbContext.Orders.Update(orderChecker);
            }
            else
            {
                Entities.Order order = new()
                {
                    UserId = user!.UserId,
                    CartItems = new List<Entities.CartItem>()
                {
                    newCartItem
                }
                };
                _dbContext.Orders.Add(order);
            }
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation("Successfully added new cart item");
            return newCartItem.CartItemId;
        }

        public async Task Put(Guid CartItemId, UpdateCartItemDTO cartItem)
        {
            var CartItem = _dbContext.CartItems.FirstOrDefault(c => c.CartItemId.Equals(CartItemId)) ?? throw new Exception("Not found");

            CartItem.CartItemName = cartItem.CartItemName;
            _dbContext.CartItems.Update(CartItem);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Put {CartItemId}");
        }
        public async Task Delete(Guid CartItemId)
        {
            var CartItem = _dbContext.CartItems.FirstOrDefault(c => c.CartItemId.Equals(CartItemId)) ?? throw new Exception("Not Found");
            _dbContext.CartItems.Remove(CartItem);
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"Delete Success {CartItemId}");
        }
    }
}
