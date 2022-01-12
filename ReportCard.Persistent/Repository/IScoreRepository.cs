﻿
namespace ReportCard.Persistent.Repository
{
    using System;
    using System.Collections.Generic;
    using ReportCard.Persistent.Model;

    /// <summary>
    /// 分數持久層
    /// </summary>
    public interface IScoreRepository
    {
        /// <summary>
        /// 新增分數
        /// </summary>
        /// <param name="sujectId"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        (Exception exception, Score score) Add(int sujectId, int point);

        /// <summary>
        /// 移除分數
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        (Exception exception, Score score) Delete(int id);

        /// <summary>
        /// 取得所有分數
        /// </summary>
        /// <param name="sujectId"></param>
        /// <returns></returns>
        (Exception exception, IEnumerable<Score> scores) Query(int? sujectId);
    }
}
