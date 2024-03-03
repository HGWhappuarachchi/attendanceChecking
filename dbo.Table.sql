CREATE TABLE [dbo].[Students]
(
	[StId] INT NOT NULL PRIMARY KEY,
	[Student Name] CHAR NOT NULL ,
	[Telephone] INT NOT NULL,
	[Email] CHAR  NOT NULL,
	[Parent name ]  CHAR NOT NULL,
	[Parent number] int not null,
	[Image] VARBINARY(MAX) NULL

)
