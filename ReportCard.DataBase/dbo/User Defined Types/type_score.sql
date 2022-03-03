/*
	描述: 科目分數
	建立日期: 2022-03-03
*/

CREATE TYPE [dbo].[type_score] AS TABLE (
    [f_sujectId]	INT	NOT NULL,
	[f_point]		INT NOT NULL);
GO

GRANT EXECUTE
    ON TYPE::[dbo].[type_score] TO PUBLIC;
GO