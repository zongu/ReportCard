/*
	描述: 刪除科目分數
	建立日期: 2022-01-12

	exec pro_scoreDelete
		@id = 1
*/

CREATE PROCEDURE [dbo].[pro_scoreDelete]
	@id INT
AS
	DELETE t_score WITH (ROWLOCK)
	OUTPUT deleted.*
	WHERE f_id = @id
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_scoreDelete] TO PUBLIC
    AS [dbo];
