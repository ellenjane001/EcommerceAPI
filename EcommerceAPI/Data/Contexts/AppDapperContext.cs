using Microsoft.Data.SqlClient;
using System.Data;

namespace EcommerceAPI.Data.Contexts
{
    public class AppDapperContext
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;
        public AppDapperContext(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("DefaultSQLConnection") ?? string.Empty;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
