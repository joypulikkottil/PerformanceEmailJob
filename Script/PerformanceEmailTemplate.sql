USE [INTRANET]
GO

/****** Object:  Table [dbo].[PerformanceEmailTemplate]    Script Date: 3/2/2023 10:49:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PerformanceEmailTemplate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](50) NULL,
	[Email] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


