
namespace ReportCard.Persistent.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Dapper;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;

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
        /// 批次新增分數
        /// </summary>
        /// <param name="scores"></param>
        /// <returns></returns>
        public (Exception exception, IEnumerable<Score> scores) BatchInsert(IEnumerable<Score> scores)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var udt = new DataTable();
                    udt.Columns.Add(nameof(Score.f_sujectId), typeof(int));
                    udt.Columns.Add(nameof(Score.f_point), typeof(int));

                    foreach (var score in scores)
                    {
                        var dr = udt.NewRow();
                        dr[nameof(score.f_sujectId)] = score.f_sujectId;
                        dr[nameof(score.f_point)] = score.f_point;

                        udt.Rows.Add(dr);
                    }

                    var result = cn.Query<Score>(
                        "pro_scoreBatchInsert",
                        new
                        {
                            type_score = udt.AsTableValuedParameter("type_score")
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
