
namespace ReportCard.Persistent.Repository
{
    using System;
    using System.Collections.Generic;
    using ReportCard.Persistent.Model;

    /// <summary>
    /// 科目持久層
    /// </summary>
    public interface ISujectRepository
    {
        /// <summary>
        /// 新增科目
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        (Exception exception, Suject suject) Add(string name);

        /// <summary>
        /// 移除科目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        (Exception exception, Suject suject) Delete(int id);

        /// <summary>
        /// 取得所有科目
        /// </summary>
        /// <returns></returns>
        (Exception exception, IEnumerable<Suject> sujects) Query();

        /// <summary>
        /// 更新科目
        /// </summary>
        /// <param name="suject"></param>
        /// <returns></returns>
        (Exception exception, Suject suject) Update(Suject suject);
    }
}
