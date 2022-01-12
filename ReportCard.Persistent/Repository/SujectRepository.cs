
namespace ReportCard.Persistent.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Dapper;
    using ReportCard.Persistent.Model;

    /// <summary>
    /// 科目持久層
    /// </summary>
    public class SujectRepository : ISujectRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private string connectionString;

        public SujectRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 新增科目
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public (Exception exception, Suject suject) Add(string name)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Suject>(
                        "pro_sujectAdd",
                        new
                        {
                            name = name
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
        /// 移除科目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public (Exception exception, Suject suject) Delete(int id)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Suject>(
                        "pro_sujectDelete",
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
        /// 取得所有科目
        /// </summary>
        /// <returns></returns>
        public (Exception exception, IEnumerable<Suject> sujects) Query()
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.Query<Suject>(
                        "pro_sujectQuery",
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
        /// 更新科目
        /// </summary>
        /// <param name="suject"></param>
        /// <returns></returns>
        public (Exception exception, Suject suject) Update(Suject suject)
        {
            try
            {
                using (var cn = new SqlConnection(this.connectionString))
                {
                    var result = cn.QueryFirstOrDefault<Suject>(
                        "pro_sujectUpdate",
                        new
                        {
                            id = suject.f_id,
                            name = suject.f_name
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
