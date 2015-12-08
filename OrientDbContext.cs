using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevStack.OrientDb.Client;
using System.Data;
using System.Configuration;
using RevStack.Pattern;

namespace RevStack.OrientDb
{
    public class OrientDbContext : RevStack.Pattern.IDataContext
    {
        private readonly OrientDbConnection _connection;
        private readonly OrientDbDatabase _database;

        public OrientDbContext()
        {
            _connection = new OrientDbConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            _database = new OrientDbDatabase(_connection);
        }

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
