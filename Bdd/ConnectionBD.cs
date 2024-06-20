using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace parcial3.Bdd.ConnectionBD
{
    public class ConnectionDB
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=bubuchona;Database=postgres;Port=5432";
        public ConnectionDB(string _connectionString)
        {
            this.connectionString = _connectionString;
        }

        public NpgsqlConnection OpenConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
