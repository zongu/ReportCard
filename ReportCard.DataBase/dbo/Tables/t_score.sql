CREATE TABLE [dbo].[t_score]
(
	[f_id]			INT	IDENTITY (1, 1)	NOT NULL,
	[f_sujectId]	INT	NOT NULL,
	[f_point]		INT NOT NULL,
	CONSTRAINT [PK_score] PRIMARY KEY CLUSTERED ([f_id] ASC)
)
