using MvvmCross.Plugins.Sqlite;
using SQLite;

namespace SZWMar2018.Core.Services
{
    public class DataServiceBase
    {
        private const string ConnectionString = "SZWMar2018.dat";
        protected readonly SQLiteConnection Connection;

        protected DataServiceBase(IMvxSqliteConnectionFactory connectionFactory)
        {
            Connection = connectionFactory.GetConnection(ConnectionString);
        }
    }
}
