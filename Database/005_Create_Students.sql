USE [cla]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Students_Classes]') AND parent_object_id = OBJECT_ID(N'[dbo].[Students]'))
ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_Students_Classes]
GO

USE [cla]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 05/24/2018 23:57:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Students]') AND type in (N'U'))
DROP TABLE [dbo].[Students]
GO

USE [cla]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 05/24/2018 23:57:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[Sid] [int] IDENTITY(1,1) NOT NULL,
	[RollNo] [numeric](18, 0) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Mobile] [numeric](18, 0) NULL,
	[HomePhone] [numeric](18, 0) NULL,
	[EnrollmentNo] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[ClassId] [int] NULL
PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Classes] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Classes] ([ClassId])
GO

ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Classes]
GO


