USE [cla]
GO

/****** Object:  Table [dbo].[TimeTable]    Script Date: 06/19/2018 12:37:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TimeTable](
	[TimeTableId] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[FacultyId] [int] NOT NULL,
	[SubjectId] [int] NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NOT NULL,
	[DurationInMin] [int] NOT NULL,
	[IsActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TimeTableId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTableClasses] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
GO

ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTableClasses]
GO

ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTableFaculties] FOREIGN KEY([FacultyId])
REFERENCES [dbo].[Faculties] ([FId])
GO

ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTableFaculties]
GO

ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTableSubjects] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Subjects] ([SubId])
GO

ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTableSubjects]
GO


