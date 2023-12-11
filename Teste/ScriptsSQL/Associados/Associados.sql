CREATE TABLE [dbo].[associados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[CPF] [varchar](11) NOT NULL UNIQUE,
	[Data_Nascimento] [datetime] NULL,
 CONSTRAINT [PK_associados] PRIMARY KEY CLUSTERED
(
