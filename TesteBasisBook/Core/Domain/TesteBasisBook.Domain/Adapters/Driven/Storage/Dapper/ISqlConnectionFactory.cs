using System.Data;

namespace TesteBasisBook.Domain.Adapters.Driven.Storage.Dapper
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
