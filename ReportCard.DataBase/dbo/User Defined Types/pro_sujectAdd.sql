/*
	描述: 新增科目
	建立日期: 2022-01-12

	exec pro_sujectAdd
		@name = 'test'
*/

CREATE PROCEDURE [dbo].[pro_sujectAdd]
	@name NVARCHAR(20)
AS
	INSERT INTO t_suject (f_name)
	OUTPUT inserted.*
	VALUES (@name)
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_sujectAdd] TO PUBLIC
    AS [dbo];
