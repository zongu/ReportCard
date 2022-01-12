
namespace ReportCard.Persistent.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Dapper;
    using ReportCard.Persistent.Model;

    /// <summary>
    /// 分數持久層
    /// </summary>
    public class ScoreRepository : IScoreRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private string connectionString;

        public ScoreRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 新增分數
        /// </summary>
        /// <param name="sujectId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public (Exception exception, Score score) Add(int sujectId, int point)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Score>(
                        "pro_scoreAdd",
                        new
                        {
                            sujectId = sujectId,
                            point = point
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        /// <summary>
        /// 移除分數
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (Exception exception, Score score) Delete(int id)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Score>(
                        "pro_scoreDelete",
                        new
                        {
                            id = id
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        /// <summary>
        /// 取得所有分數
        /// </summary>
        /// <param name="sujectId"></param>
        /// <returns></returns>
        public (Exception exception, IEnumerable<Score> scores) Query(int? sujectId)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.Query<Score>(
                        "pro_scoreQuery",
                        new
                        {
                            sujectId = sujectId
                        },
                        commandType: CommandType.StoredProcedure);

                    return (null, result);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
