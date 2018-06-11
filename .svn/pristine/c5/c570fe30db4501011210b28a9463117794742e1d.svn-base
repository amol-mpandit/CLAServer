using Core;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace persistence
{
    public class ClassesRepository : BaseRepository
    {
        public ClassesRepository(DBConnection dbConnection) : base(dbConnection)
        {
        }

        public int Add(Classes entity)
        {
            const string query = @"
                                     INSERT INTO [cla].[dbo].[Classes]
                                                ([ClassName]
                                                ,[Division])
                                            VALUES
                                                (@ClassName,@Division)
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Execute(query,entity); 
        }

        public int Delete(int classId)
        {
            const string query = @"
                                     DELETE FROM [cla].[dbo].[Classes]
                                            WHERE classId = @classId
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Execute(query, classId);
        }

        public void Update(Classes entity)
        {
            const string query = @"
                                     UPDATE [cla].[dbo].[Classes]
                                           SET [ClassName] = @ClassName,
                                               [Division] = @Division
                                         WHERE classId = @classId
                                    ";
            EnsureDBConnectionIsOpen();
            Connection.Execute(query,entity);
        }

        public IEnumerable<Classes> GetAll()
        {
            const string query = @"
                                    SELECT [ClassId]
                                          ,[ClassName]
                                          ,[Division]
                                      FROM [cla].[dbo].[Classes]
                                     ";
            EnsureDBConnectionIsOpen();
            return Connection.Query<Classes>(query);
        }

        public Classes Get(int classId)
        {
            const string query = @"
                                    SELECT [ClassId]
                                          ,[ClassName]
                                          ,[Division]
                                      FROM [cla].[dbo].[Classes] 
                                        WHERE ClassId = @classId
                                    ";

            EnsureDBConnectionIsOpen();
            return Connection.Query<Classes>(query, classId).SingleOrDefault();
        }
    }
}
