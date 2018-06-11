using Core;
using Dapper;
using System.Collections.Generic;
using System.Linq;


namespace persistence
{
    public class SubjectRepository : BaseRepository
    {
        public SubjectRepository(DBConnection dbConnection) : base(dbConnection)
        {
        }

        public int Add(Subject subject)
        {
            const string query = @"
                                    INSERT INTO [cla].[dbo].[Subjects]
                                           ([Name]
                                           ,[Code]
                                           ,[ClassId])
                                     VALUES
                                           (@Name
                                           ,@Code
                                           ,@ClassId)
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Execute(query, subject);
        }

        public int Delete(int subId)
        {
            const string query = @"
                                   DELETE FROM [cla].[dbo].[Subjects]
                                            WHERE SubId = @subId
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Execute(query, subId);
        }

        public void Update(Subject subject)
        {
            const string query = @"
                                    UPDATE [cla].[dbo].[Subjects]
                                       SET [Name] = @Name 
                                          ,[Code] = @Code
                                          ,[ClassId] = @ClassId
                                     WHERE [SubId] = @SubId
                                    ";
            EnsureDBConnectionIsOpen();
            Connection.Execute(query, subject);
        }
        public IEnumerable<Subject> GetAll()
        {
            const string query = @"
                                    SELECT [SubId]
                                          ,[Name]
                                          ,[Code]
                                          ,[ClassId]
                                      FROM [cla].[dbo].[Subjects]
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Query<Subject>(query);
        }
        public Subject Get(string subjectCode)
        {
            const string query = @"
                                    SELECT [SubId]
                                          ,[Name]
                                          ,[Code]
                                          ,[ClassId]
                                      FROM [cla].[dbo].[Subjects]
                                      WHERE Code = @subjectCode
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Query<Subject>(query, subjectCode).SingleOrDefault();
        }

        public string GetSubjectCode(int subId)
        {
            const string query = @"
                                    SELECT [Code]
                                      FROM [cla].[dbo].[Subjects]
                                      WHERE subId = @subId
                                    ";
            EnsureDBConnectionIsOpen();
            return Connection.Query<string>(query, subId).SingleOrDefault();
        }
    }
}
