﻿using Dapper;
using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Data.DTO.User;
using EcommerceAPI.Data.Miscellaneous;
using EcommerceAPI.Domain.Entities;
using EcommerceAPI.Domain.Interfaces;
using System.Data;

namespace EcommerceAPI.Domain.Repositories
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

        public async Task<User> GetUser(Guid UserId)
        {
            var query = "SELECT * FROM users WHERE UserId=@UserId";
            var parameters = new { UserId };
            _connection.Open();
            var user = await _connection.QueryFirstAsync<User>(query, parameters);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var order = _dbContext.Orders.Where(order => order.UserId == user.UserId).FirstOrDefault();
            if (order != null)
            {
                user.Orders = new List<Order> { order };
            }
            return user;
        }
        public async Task<Guid> Post(CreateUserDTO user)
        {
            User newUser = new()
            {
                UserName = user.UserName
            };
            if (_dbContext.Users.FirstOrDefault(u => u.UserName!.Equals(newUser.UserName)) != null)
            {
                throw new Exception("User already exists");
            }
            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return _dbContext.Users.FirstOrDefault(u => u.UserName == newUser.UserName)!.UserId;
        }
    }
}
