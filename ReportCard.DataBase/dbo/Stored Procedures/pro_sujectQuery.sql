/*
	描述: 獲取所有科目
	建立日期: 2022-01-12

	exec pro_sujectQuery
*/

CREATE PROCEDURE [dbo].[pro_sujectQuery]
AS
	SELECT f_id,f_name FROM t_suject WITH (NOLOCK)
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_sujectQuery] TO PUBLIC
    AS [dbo];
