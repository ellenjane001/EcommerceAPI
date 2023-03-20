using Dapper;
using EcommerceAPI.Data.Contexts;
using EcommerceAPI.Domain.Entities;
using System.Data;

namespace EcommerceAPI.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDbConnection _connection;
        public AuthMiddleware(RequestDelegate next, AppDapperContext context)
        {
            _next = next;
            _connection = context.CreateConnection();
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var header = context.Request.Headers.ContainsKey("x-user-id");
            if (!header)
            {
                context.Response.StatusCode = 401;
                return;
            }
            string UserId = context.Request.Headers["x-user-id"]!;
            Guid parseUser = Guid.Parse(UserId);
            if (!ValidateUser(parseUser))
            {
                context.Response.StatusCode = 401;
                return;
            }
            await _next(context);

        }
        private bool ValidateUser(Guid UserId)
        {
            var query = "SELECT * FROM Users where UserId = @UserId";
            var parameters = new { UserId };
            _connection.Open();
            var user = _connection.Query<User>(query, parameters).FirstOrDefault();
            _connection.Close();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
