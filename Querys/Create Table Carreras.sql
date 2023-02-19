USE [SOFTUNI]
GO

/****** Object:  Table [dbo].[Carreras]    Script Date: 19/2/2023 11:12:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Carreras](
	[ID] [int] IDENTITY(1,1) NOT NULL primary key,
	[ID_Universidad] [int] NOT NULL,
	[Nombre] [varchar](100) NULL,
) 
GO


