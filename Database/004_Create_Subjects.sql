USE [cla]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SubjectClasess]') AND parent_object_id = OBJECT_ID(N'[dbo].[Subjects]'))
ALTER TABLE [dbo].[Subjects] DROP CONSTRAINT [FK_SubjectClasess]
GO

USE [cla]
GO

/****** Object:  Table [dbo].[Subjects]    Script Date: 05/24/2018 23:55:53 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Subjects]') AND type in (N'U'))
DROP TABLE [dbo].[Subjects]
GO

USE [cla]
GO

/****** Object:  Table [dbo].[Subjects]    Script Date: 05/24/2018 23:55:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Subjects](
	[SubId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[ClassId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Subjects]  WITH CHECK ADD  CONSTRAINT [FK_SubjectClasess] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
GO

ALTER TABLE [dbo].[Subjects] CHECK CONSTRAINT [FK_SubjectClasess]
GO


