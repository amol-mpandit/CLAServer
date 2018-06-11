using Core;
using Dapper;
using System.Collections.Generic;
using System.Linq;


namespace persistence
{
    public class StudentRepository : BaseRepository
    {
        public StudentRepository(DBConnection dbConnection) : base(dbConnection)
        {
        }

        public int Add(Student entity)
        {
            const string query = @"
                                    INSERT INTO [cla].[dbo].[Students]
                                                   ([RollNo]
                                                   ,[FirstName]
                                                   ,[MiddleName]
                                                   ,[LastName]
                                                   ,[Mobile]
                                                   ,[HomePhone]
                                                   ,[ClassId])
                                             VALUES
                                                   (@RollNo
                                                   ,@FirstName
                                                   ,@MiddleName
                                                   ,@LastName
                                                   ,@Mobile
                                                   ,@HomePhone
                                                   ,@ClassId)";
            EnsureDBConnectionIsOpen();
            return Connection.Execute(query, entity);
        }

        public int Delete(int sId)
        {
            const string query = @"
                                    DELETE FROM [cla].[dbo].[Students] WHERE sid = @sId
                                  ";
            EnsureDBConnectionIsOpen();
            return Connection.Execute(query, sId);
        }

        public void Update(Student student)
        {
            const string query = @"
                                    UPDATE [cla].[dbo].[Students]
                                       SET 
                                           [RollNo] = @RollNo
                                          ,[FirstName] = @FirstName
                                          ,[MiddleName] = @MiddleName,
                                          ,[LastName] = @LastName
                                          ,[Mobile] = @Mobile
                                          ,[HomePhone] = @HomePhone
                                          ,[ClassId] = @ClassId
                                     WHERE [sid] = @SId
                                  ";
            EnsureDBConnectionIsOpen();
            Connection.Execute(query, student);
        }
        public IEnumerable<Student> GetAll()
        {
            const string query = @"
                                   SELECT [Sid]
                                          ,[RollNo]
                                          ,[FirstName]
                                          ,[MiddleName]
                                          ,[LastName]
                                          ,[Mobile]
                                          ,[HomePhone]
                                          ,[ClassId]
                                      FROM [cla].[dbo].[Students]
                                  ";
            EnsureDBConnectionIsOpen();
            return Connection.Query<Student>(query);
        }
        public Student Get(int rollNo)
        {
            const string query = @"
                                    SELECT [Sid]
                                          ,[RollNo]
                                          ,[FirstName]
                                          ,[MiddleName]
                                          ,[LastName]
                                          ,[Mobile]
                                          ,[HomePhone]
                                          ,[ClassId]
                                      FROM [cla].[dbo].[Students]
                                      WHERE RollNo = @rollNo
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Query<Student>(query, rollNo).SingleOrDefault();
        }

        public int GetRollNo(int sId)
        {
            const string query = @"
                                    SELECT [RollNo] FROM [cla].[dbo].[Students] WHERE Sid = @sId
                                   ";
            EnsureDBConnectionIsOpen();
            return Connection.Query<int>(query, sId).SingleOrDefault();  

        }

    }
}
