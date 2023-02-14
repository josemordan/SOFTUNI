USE [SOFTUNI]
GO

/****** Object:  Table [dbo].[UsuarioDumy]    Script Date: 14/2/2023 19:14:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UsuarioDumy](
	[ID] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Nombres] [varchar](80) NULL,
	[Apellidos] [varchar](80) NULL,
	[Identificacion] [varchar](20) NULL,
	[Telefono] [varchar](20) NULL,
	[Celular] [varchar](20) NULL,
	[Fecha_Nacimiento] [date] NULL,
	[Lugar_Nacimiento] [varchar](150) NULL,
	[Nacionalidad] [varchar](100) NULL,
	[Region] [varchar](100) NULL,
	[Provincia] [varchar](100) NULL,
	[Municipio] [varchar](200) NULL,
	[Sector] [varchar](200) NULL,
	[Residencia] [varchar](250) NULL
)
GO


