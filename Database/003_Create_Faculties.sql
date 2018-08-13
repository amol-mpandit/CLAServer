USE [cla]
GO

/****** Object:  Table [dbo].[Faculties]    Script Date: 05/24/2018 23:54:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Faculties]') AND type in (N'U'))
DROP TABLE [dbo].[Faculties]
GO

USE [cla]
GO

/****** Object:  Table [dbo].[Faculties]    Script Date: 05/24/2018 23:54:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Faculties](
	[FId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Designation] [nvarchar](50) NULL,
	[Phone] [numeric](18, 0) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[FId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


