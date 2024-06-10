using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SQLServer
{
    public class DbContext
    {
        private string _dbConnection;

        public DbContext(string dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection( _dbConnection );
        }
    }
}
