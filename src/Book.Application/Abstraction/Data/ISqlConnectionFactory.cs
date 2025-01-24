using System.Data;

namespace Book.Application.Abstraction.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
