using Dapper;
using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Data.Handlers;
using EcommerceAPI.Data.Interfaces;
using EcommerceAPI.DTO.User;
using EcommerceAPI.Entities;
using System.Data;

namespace EcommerceAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext _db, AppDapperContext dapperContext)
        {
            _dbContext = _db;
            _connection = dapperContext.CreateConnection();

        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var OrderHandlers = new OrderHandlers(_dbContext);
            var CartItemHandlers = new CartItemHandlers(_dbContext);
            var query = "SELECT * FROM users";
            _connection.Open();
            var users = await _connection.QueryAsync<User>(query);
            var userIds = users.Select(u => u.UserId).ToArray();
            var orders = OrderHandlers.GetOrdersByUserId(userIds);
            var orderIds = orders.Select(o => o.OrderId).ToArray();
            var cartItems = CartItemHandlers.GetCartItemsByOrderId(orderIds);
            foreach (var order in orders)
            {
                order.CartItems = cartItems.Where(cartItem => cartItem.OrderId == order.OrderId).ToList();
            }
            foreach (var user in users)
            {
                user.Orders = orders.Where(order => order.UserId == user.UserId).ToList();
            }
            return users.ToList();
        }

        public async Task<IEnumerable<User>> GetUser(Guid UserId)
        {
            var query = "SELECT * FROM users WHERE UserId=@UserId";
            var parameters = new { UserId };
            _connection.Open();
            var user = await _connection.QueryAsync<User>(query, parameters);
            return user.ToList();
        }
        public void Post(CreateUserDTO user)
        {
            User newUser = new()
            {
                UserName = user.UserName
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }
    }
}
