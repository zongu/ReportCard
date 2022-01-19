/*
	描述: 移除科目
	建立日期: 2022-01-12

	exec pro_sujectDelete
		@id = 1
*/

CREATE PROCEDURE [dbo].[pro_sujectDelete]
	@id INT
AS
	DELETE t_suject WITH (ROWLOCK)
	OUTPUT deleted.*
	WHERE f_id = @id
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_sujectDelete] TO PUBLIC
    AS [dbo];
