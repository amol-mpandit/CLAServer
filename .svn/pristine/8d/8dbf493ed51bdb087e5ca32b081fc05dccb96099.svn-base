using Core;
using Dapper;
using System.Collections.Generic;
using System.Linq;


namespace persistence
{
    public class FacultyRepository : BaseRepository
    {
        public FacultyRepository(DBConnection dbConnection) : base(dbConnection)
        {
        }

        public int Add(Faculty entity)
        {
            const string query = @"
                                 INSERT INTO [cla].[dbo].[Faculties]
                                       ([FirstName]
                                       ,[LastName]
                                       ,[Designation]
                                       ,[Phone])
                                 VALUES
                                       (@FirstName
                                       ,@LastName
                                       ,@Designation
                                       ,@Phone)";
            EnsureDBConnectionIsOpen();
            return Connection.Execute(query, entity);
        }

        public int Delete(int facultyId)
        {
            const string query = @"DELETE FROM [cla].[dbo].[Faculties] WHERE Fid = @facultyId";
            EnsureDBConnectionIsOpen();
            return Connection.Execute(query, facultyId);
        }

        public void Update(Faculty entity)
        {
            const string query = @"
                                    UPDATE [cla].[dbo].[Faculties]
                                       SET [FirstName] = @FirstName,
                                           [LastName] = @LastName, 
                                           [Designation] = @Designation, 
                                           [Phone] = @Phone, 
                                     WHERE @FId = @FId
                                    ";
            EnsureDBConnectionIsOpen();
            Connection.Execute(query, entity);
        }
        public IEnumerable<Faculty> GetAll()
        {
            const string query = @"
                                     SELECT [FId]
                                          ,[FirstName]
                                          ,[LastName]
                                          ,[Designation]
                                          ,[Phone]
                                      FROM [cla].[dbo].[Faculties]";
            EnsureDBConnectionIsOpen();
            return Connection.Query<Faculty>(query);
        }
        public Faculty Get(int facultyId)
        {
            const string query = @"
                                     SELECT [FId]
                                          ,[FirstName]
                                          ,[LastName]
                                          ,[Designation]
                                          ,[Phone]
                                      FROM [cla].[dbo].[Faculties]
                                        WHERE FId = @facultyId
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Query<Faculty>(query, facultyId).SingleOrDefault();
        }
    }
}
