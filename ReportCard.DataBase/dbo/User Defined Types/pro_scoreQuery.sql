/*
	描述: 獲取科目分數
	建立日期: 2022-01-12

	exec pro_scoreQuery
		@sujectId = null
*/

CREATE PROCEDURE [dbo].[pro_scoreQuery]
	@sujectId INT
AS
	SELECT f_id, f_sujectId, f_point FROM t_score WITH (NOLOCK)
	WHERE (@sujectId is null OR f_sujectId = @sujectId)
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_scoreQuery] TO PUBLIC
    AS [dbo];
