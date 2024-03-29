﻿using Core;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace persistence
{
    public class StudentRepository : BaseRepository
    {
        public StudentRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public void Add(Student student)
        {
            const string query = @"
                                    INSERT INTO [cla].[dbo].[Students]
                                               ([RollNo]
                                               ,[FirstName]
                                               ,[MiddleName]
                                               ,[LastName]
                                               ,[Mobile]
                                               ,[HomePhone]
                                               ,[EnrollmentNo]
                                               ,[Email]           
                                               ,[ClassId])
                                         VALUES
                                               (@RollNo
                                               ,@FirstName
                                               ,@MiddleName
                                               ,@LastName
                                               ,@Mobile
                                               ,@HomePhone
                                               ,@EnrollmentNo
                                               ,@Email
                                               ,@ClassId)";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, student);
        }

        public void Delete(int sId)
        {
            const string query = @"
                                    DELETE FROM [cla].[dbo].[Students] WHERE [sId] = @sId
                                  ";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, new { sId });
        }

        public void Update(Student student)
        {
            const string query = @"
                                    UPDATE [cla].[dbo].[Students]
                                       SET [RollNo] = @RollNo
                                          ,[FirstName] = @FirstName
                                          ,[MiddleName] = @MiddleName
                                          ,[LastName] = @LastName
                                          ,[Mobile] = @Mobile
                                          ,[HomePhone] = @HomePhone
                                          ,[EnrollmentNo] = @EnrollmentNo
                                          ,[Email] = @Email
                                          ,[ClassId] = @ClassId
                                     WHERE [Sid] = @Sid";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, student);
        }
        public IEnumerable<Student> GetAll()
        {
            const string query = @"
                                   SELECT  [Sid]
                                          ,[RollNo]
                                          ,[FirstName]
                                          ,[MiddleName]
                                          ,[LastName]
                                          ,[Mobile]
                                          ,[HomePhone]
                                          ,[EnrollmentNo]
                                          ,[Email]
                                          ,[ClassId]
                                      FROM [cla].[dbo].[Students]
                                  ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<Student>(query);
        }
        public Student Get(int sId)
        {
            const string query = @"
                                    SELECT [Sid]
                                          ,[RollNo]
                                          ,[FirstName]
                                          ,[MiddleName]
                                          ,[LastName]
                                          ,[Mobile]
                                          ,[HomePhone]
                                          ,[EnrollmentNo]
                                          ,[Email]
                                          ,[ClassId]
                                      FROM [cla].[dbo].[Students] 
		                                    WHERE [Sid] = @sId
                                    ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<Student>(query, new { sId }).SingleOrDefault();
        }

        public int GetRollNo(int sId)
        {
            const string query = @"
                                    SELECT [RollNo] FROM [cla].[dbo].[Students] WHERE Sid = @sId
                                   ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<int>(query, new { sId }).SingleOrDefault();  

        }
        public Student GetStudentBy(int rollNo)
        {
            const string query = @"
                                    SELECT * FROM [cla].[dbo].[Students] WHERE RollNo = @rollNo
                                   ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<Student>(query, new { rollNo }).SingleOrDefault();
        }

    }
}
