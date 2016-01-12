using System;
using RevStack.OrientDb.Client;


namespace RevStack.OrientDb
{
    public class OrientDbContext
    {
        private readonly OrientDbConnection _connection;
        private readonly OrientDbDatabase _database;

        public OrientDbContext(string connectionString)
        {
            _connection = new OrientDbConnection(connectionString);
            _database = new OrientDbDatabase(_connection);
        }

        public OrientDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public OrientDbDatabase Database
        {
            get
            {
                return _database;
            }
        }
    }
}
