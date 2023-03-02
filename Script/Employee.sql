USE [INTRANET]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 3/2/2023 10:51:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HRNo] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Result] [varchar](50) NULL
) ON [PRIMARY]
GO


