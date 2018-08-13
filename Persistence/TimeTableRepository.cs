using Core;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace persistence
{
    public class TimeTableRepository : BaseRepository
    {
        public TimeTableRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        public void Add(TimeTable timeTable)
        {
            const string query = @"
                                    INSERT INTO [cla].[dbo].[TimeTable]
                                                           ([ClassId]
                                                           ,[FacultyId]
                                                           ,[SubjectId]
                                                           ,[StartTime]
                                                           ,[EndTime]
                                                           ,[DurationInMin]
                                                           ,[IsActive])
                                                     VALUES
                                                           (@ClassId
                                                           ,@FacultyId
                                                           ,@SubjectId
                                                           ,@StartTime
                                                           ,@EndTime
                                                           ,@DurationInMin
                                                           ,@IsActive)";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, timeTable);
        }

        public void Delete(int timeTableId)
        {
            const string query = @"
                                    DELETE FROM [cla].[dbo].[TimeTable]
                                            WHERE [TimeTableId] = @timeTableId
                                  ";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, new { timeTableId });
        }

        public void Update(TimeTable timeTable)
        {
            const string query = @"
                                   UPDATE [cla].[dbo].[TimeTable]
                                        SET [ClassId] = @ClassId
                                            ,[FacultyId] = @FacultyId
                                            ,[SubjectId] = @SubjectId
                                            ,[StartTime] = @StartTime
                                            ,[EndTime] = @EndTime
                                            ,[DurationInMin] = @DurationInMin
                                            ,[IsActive] = @IsActive
                                        WHERE [TimeTableId] = @TimeTableId";
            EnsureDbConnectionIsOpen();
            Connection.Query(query, timeTable);
        }
        public IEnumerable<TimeTable> GetAll()
        {
            const string query = @"
                                SELECT   [TimeTableId]
                                        ,[ClassId]
                                        ,[FacultyId]
                                        ,[SubjectId]
                                        ,[StartTime]
                                        ,[EndTime]
                                        ,[DurationInMin]
                                        ,[IsActive]
                                    FROM [cla].[dbo].[TimeTable]
                                  ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<TimeTable>(query);
        }
        public TimeTable Get(int timeTableId)
        {
            const string query = @"
                                    SELECT [TimeTableId]
                                        ,[ClassId]
                                        ,[FacultyId]
                                        ,[SubjectId]
                                        ,[StartTime]
                                        ,[EndTime]
                                        ,[DurationInMin]
                                        ,[IsActive]
                                    FROM [cla].[dbo].[TimeTable]
                                    WHERE [TimeTableId] = @timeTableId
                                    ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<TimeTable>(query, new { timeTableId }).SingleOrDefault();
        }

        public IEnumerable<TimeTable> GetTodaysActiveScheduleBy(int classId, int studentId)
        {
            const string query = @"
                                    SELECT [TimeTableId]
                                          ,tt.ClassId
                                          ,[FacultyId]
                                          ,[SubjectId]
                                          ,[StartTime]
                                          ,[EndTime]
                                          ,[DurationInMin]
                                          ,[IsActive]
                                      FROM [cla].[dbo].[TimeTable] tt
                                      LEFT JOIN [cla].[dbo].[Students] s
                                      ON tt.ClassId = s.ClassId
                                      WHERE s.ClassId = @classId 
                                      AND s.SId = @studentId
                                      AND Convert(date, StartTime) >= Convert(date, GETDATE())
                                      AND Convert(date, EndTime) <= Convert(date, GETDATE())
                                      AND IsActive = 1
                                    ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<TimeTable>(query, new { classId, studentId });
        }

        public IEnumerable<TimeTable> GetTimeTablesForDate(DateTime date)
        {
            const string query = @"
                                    SELECT [TimeTableId]
                                          ,[ClassId]
                                          ,[FacultyId]
                                          ,[SubjectId]
                                          ,[StartTime]
                                          ,[EndTime]
                                          ,[DurationInMin]
                                          ,[IsActive]
                                      FROM [cla].[dbo].[TimeTable] 
                                      WHERE Convert(date, StartTime) >= Convert(date, @date)
                                      AND Convert(date, EndTime) <= Convert(date, @date)
                                    ";
            EnsureDbConnectionIsOpen();
            return Connection.Query<TimeTable>(query, new { date });
        }
    }
}
