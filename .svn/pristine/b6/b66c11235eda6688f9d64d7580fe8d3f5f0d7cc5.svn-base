using Core;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace persistence
{
    public class AttendanceRepository : BaseRepository
    {
        public AttendanceRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public void Add(Attendance attendance)
        {
            const string query = @"
                                    INSERT INTO [cla].[dbo].[Attendance]
                                               ([TimeTableId]
                                               ,[IsPresent]
                                               ,[StudentId]
                                               ,[CreatedDateTime])
                                         VALUES
                                               (@TimeTableId
                                               ,@IsPresent
                                               ,@StudentId
                                               ,getDate())";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, attendance);
        }

        public void Delete(int attendanceId)
        {
            const string query = @"
                                    DELETE FROM [cla].[dbo].[Attendance]
                                        WHERE [AttendanceId] = @attendanceId
                                  ";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, new { attendanceId });
        }

        public void Update(Attendance attendance)
        {
            const string query = @"
                                   UPDATE [cla].[dbo].[Attendance]
                                       SET [TimeTableId] = @TimeTableId
                                          ,[IsPresent] = @IsPresent
                                          ,[StudentId] = @StudentId
                                     WHERE [AttendanceId] = @attendanceId";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, attendance);
        }
        public IEnumerable<Attendance> GetAll()
        {
            const string query = @"
                                SELECT [AttendanceId]
                                      ,[TimeTableId]
                                      ,[IsPresent]
                                      ,[StudentId]
                                      ,[CreatedDateTime]
                                  FROM [cla].[dbo].[Attendance]
                                  ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<Attendance>(query);
        }
        public Attendance Get(int attendanceId)
        {
            const string query = @"
                                    SELECT [AttendanceId]
                                      ,[TimeTableId]
                                      ,[IsPresent]
                                      ,[StudentId]
                                      ,[CreatedDateTime]
                                  FROM [cla].[dbo].[Attendance]
                                    WHERE [AttendanceId] = @attendanceId
                                    ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<Attendance>(query, new { attendanceId }).SingleOrDefault();
        }

        public IEnumerable<Attendance> GetAllForTimeTable(int timeTableId)
        {
            const string query = @"
                                    SELECT [AttendanceId]
                                      ,[TimeTableId]
                                      ,[IsPresent]
                                      ,[StudentId]
                                      ,[CreatedDateTime]
                                  FROM [cla].[dbo].[Attendance]
                                    WHERE [TimeTableId] = @timeTableId

                                    ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<Attendance>(query, new { timeTableId });
        }

        public void RecordAttendance(int studentId, int timeTableId, bool isPresent)
        {
            const string query = @"
                                   INSERT INTO [cla].[dbo].[Attendance]
                                               ([TimeTableId]
                                               ,[IsPresent]
                                               ,[StudentId]
                                               ,[CreatedDateTime])
                                         VALUES
                                               (@TimeTableId
                                               ,@IsPresent
                                               ,@StudentId
                                               ,getDate())";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, new {studentId, timeTableId, isPresent });
        }

        public bool isStudentPreset(int studentId, int timeTableId)
        {
            const string query = @"
                                   SELECT count(StudentId)
                                    FROM  [cla].[dbo].[Attendance]
                                    WHERE [StudentId] = @studentId
                                    AND   [TimeTableId] = @timeTableId";
            EnsureDbConnectionIsOpen();
            var attendance = Connection.Query<int>(query, new { studentId, timeTableId, }).SingleOrDefault();

            return attendance > 0;
        }
    }
}
