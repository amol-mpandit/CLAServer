USE [cla]
GO

/****** Object:  Table [dbo].[Attendance]    Script Date: 06/19/2018 12:45:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[TimeTableId] [int] NOT NULL,
	[IsPresent] [bit] NULL,
	[StudentId] [int] NOT NULL,
	[CreatedDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_AttendanceStudents] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Students] ([Sid])
GO

ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_AttendanceStudents]
GO

ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_AttendanceTimeTable] FOREIGN KEY([TimeTableId])
REFERENCES [dbo].[TimeTable] ([TimeTableId])
GO

ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_AttendanceTimeTable]
GO

ALTER TABLE [cla].[dbo].[Attendance]
  ADD CONSTRAINT uniqueAttendace_constraint UNIQUE(StudentId, TimeTableId);
GO

