CREATE TABLE [dbo].[t_suject]
(
	[f_id]		INT	IDENTITY (1, 1)	NOT NULL,
	[f_name]	NVARCHAR(20)		NOT NULL,
	CONSTRAINT [PK_suject] PRIMARY KEY CLUSTERED ([f_id] ASC)
)
