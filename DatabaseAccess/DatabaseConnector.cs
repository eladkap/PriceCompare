using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FinalLab
{
    public class DatabaseConnector
    {
        private SqlConnection _connection;

        public void ConnectToDatabase()
        {
            try
            {
                string connectionString = Constants.ConnectionString;
                _connection = new SqlConnection(connectionString);
                _connection.Open(); // OpenAsync
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                throw;
            }
        }

        public void DisconnectFromDatabase()
        {
            _connection?.Close();
        }

        public SqlConnection Connection { get { return _connection; } }
    }
}
