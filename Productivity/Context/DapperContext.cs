using Microsoft.Data.SqlClient;
using System.Data;

namespace Productivity.Context
{
    //Creating the connection string in Dapper. The connection string is defined in the appsetting.json file
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
