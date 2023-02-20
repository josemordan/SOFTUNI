USE [SOFTUNI]
GO

/****** Object:  Table [dbo].[SolicitudUniversidad]    Script Date: 19/2/2023 15:01:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SolicitudUniversidad](
	[ID] [int] IDENTITY(1,1) NOT NULL primary key,
	[ID_Estudiante] [int] NOT NULL,
	[ID_Universidad] [int] NOT NULL,
	[ID_Carrera] [int] NOT NULL,
)
GO

ALTER TABLE [dbo].[SolicitudUniversidad]  WITH CHECK ADD FOREIGN KEY([ID_Carrera])
REFERENCES [dbo].[Carreras] ([ID])
GO

ALTER TABLE [dbo].[SolicitudUniversidad]  WITH CHECK ADD FOREIGN KEY([ID_Estudiante])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO

ALTER TABLE [dbo].[SolicitudUniversidad]  WITH CHECK ADD FOREIGN KEY([ID_Universidad])
REFERENCES [dbo].[UNIVERSIDADES] ([ID])
GO


