/*
	描述: 批次新增新增科目分數
	建立日期: 2022-03-03

	ex:
		declare @type_score  type_score
		insert into @type_score (f_sujectId, f_point)
		select (1, 80)

		exec pro_scoreBatchInsert
		@type_score = @type_score
*/

CREATE PROCEDURE [dbo].[pro_scoreBatchInsert]
	@type_score type_score READONLY
AS
	INSERT INTO t_score (f_sujectId, f_point)
	OUTPUT inserted.*
	SELECT f_sujectId, f_point FROM @type_score
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_scoreBatchInsert] TO PUBLIC
    AS [dbo];
