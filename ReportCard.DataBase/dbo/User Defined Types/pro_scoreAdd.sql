/*
	描述: 建立科目分數
	建立日期: 2022-01-12

	exec pro_scoreAdd
		@sujectId = 1,
		@point = 80
*/

CREATE PROCEDURE [dbo].[pro_scoreAdd]
	@sujectId INT,
	@point INT
AS
	INSERT INTO t_score (f_sujectId, f_point)
	OUTPUT inserted.*
	VALUES (@sujectId, @point)
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_scoreAdd] TO PUBLIC
    AS [dbo];
