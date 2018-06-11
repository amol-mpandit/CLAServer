using System.Data;

namespace persistence
{
    public abstract class BaseRepository 
    {
        public IDbConnection Connection;

        public BaseRepository(DBConnection dbConnection)
        {
            Connection = dbConnection;
        }

        public void EnsureDBConnectionIsOpen()
        {
            if(Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
    }
}
