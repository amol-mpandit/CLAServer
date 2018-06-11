using System;
using System.Data;
using System.Data.SqlClient;

namespace persistence
{
    public class DBConnection : IDbConnection
    {
        private readonly IDbConnection Connection;

        public string ConnectionString { get; set; }

        public int ConnectionTimeout { get; private set; }

        public string Database { get; private set; }

        public ConnectionState State { get; private set; }

        public DBConnection(string connectionString) 
        {
            Connection = new SqlConnection(connectionString);
            EnsureDbConnection();
        }

        public void EnsureDbConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public void Close()
        {
            Connection.Close();
        }
        public void Open()
        {
            Connection.Open();
        }

        public IDbTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
