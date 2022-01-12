/*
	描述: 更新科目
	建立日期: 2022-01-12

	exec pro_sujectUpdate
		@id = 1,
		@name = 'test'
*/

CREATE PROCEDURE [dbo].[pro_sujectUpdate]
	@id INT,
	@name NVARCHAR(20)
AS
	UPDATE t_suject WITH (ROWLOCK)
	SET
		f_name = @name
	OUTPUT inserted.*
	WHERE
		f_id = @id
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_sujectUpdate] TO PUBLIC
    AS [dbo];
