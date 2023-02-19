USE [SOFTUNI]
GO

/****** Object:  Table [dbo].[UNIVERSIDADES]    Script Date: 19/2/2023 11:07:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UNIVERSIDADES](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[NOMBRE] [varchar](500) NULL,
	[Region] [varchar](100) NULL,
	[Provincia] [varchar](100) NULL,
	[Municipio] [varchar](200) NULL,
	[Sector] [varchar](200) NULL,
	[Residencia] [varchar](250) NULL,
	[Localicacion] [varchar](5000) NULL,
)
GO

