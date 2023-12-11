CREATE TABLE [dbo].[empresas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[CNPJ] [varchar](14) NOT NULL,
 CONSTRAINT [PK_empresas] PRIMARY KEY CLUSTERED 
(
