CREATE TABLE [dbo].[associados_empresas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CD_empresa] [int] NOT NULL,
	[CD_associado] [int] NOT NULL,
 CONSTRAINT [PK_associados_empresas] PRIMARY KEY CLUSTERED (Id),
 CONSTRAINT [FK_associados_empresas_empresas] FOREIGN KEY (CD_empresa) REFERENCES [dbo].[empresas] (ID),
 CONSTRAINT [FK_associados_empresas_associados] FOREIGN KEY (CD_associado) REFERENCES [dbo].[associados] (ID)
)