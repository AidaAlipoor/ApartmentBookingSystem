using Book.Application.Abstraction.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Book.Infrastructure.Data
{
    public sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
    {
        private readonly string _connectionString = connectionString;

        public IDbConnection CreateConnection()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection;
            }
        }
    }
}
