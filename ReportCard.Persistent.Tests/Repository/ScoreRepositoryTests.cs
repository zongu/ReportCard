
namespace ReportCard.Persistent.Tests.Repository
{
using System;
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReportCard.Persistent.Repository;

    [TestClass]
    public class ScoreRepositoryTests
    {
        private const string connectionString = @"Data Source=localhost;database=ReportCard;Integrated Security=True";

        private IScoreRepository repo;

        [TestInitialize]
        public void Init()
        {
            var sqlStr = @"TRUNCATE TABLE t_score";

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Execute(sqlStr);
            }

            this.repo = new ScoreRepository(connectionString);
        }

        [TestMethod]
        public void 新增分數測試()
        {
            var addResult = this.repo.Add(1, 80);

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.score);
            Assert.AreEqual(addResult.score.f_id, 1);
            Assert.AreEqual(addResult.score.f_sujectId, 1);
            Assert.AreEqual(addResult.score.f_point, 80);
        }

        [TestMethod]
        public void 移除分數測試()
        {
            var delResult = this.repo.Delete(1);

            Assert.IsNull(delResult.exception);
            Assert.IsNull(delResult.score);

            var addResult = this.repo.Add(1, 80);

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.score);
            Assert.AreEqual(addResult.score.f_id, 1);
            Assert.AreEqual(addResult.score.f_sujectId, 1);
            Assert.AreEqual(addResult.score.f_point, 80);

            delResult = this.repo.Delete(1);

            Assert.IsNull(delResult.exception);
            Assert.IsNotNull(delResult.score);
            Assert.AreEqual(delResult.score.f_id, 1);
            Assert.AreEqual(delResult.score.f_sujectId, 1);
            Assert.AreEqual(delResult.score.f_point, 80);
        }

        [TestMethod]
        public void 取得所有分數測試()
        {
            var addResult = this.repo.Add(1, 80);

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.score);
            Assert.AreEqual(addResult.score.f_id, 1);
            Assert.AreEqual(addResult.score.f_sujectId, 1);
            Assert.AreEqual(addResult.score.f_point, 80);

            addResult = this.repo.Add(4, 85);

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.score);
            Assert.AreEqual(addResult.score.f_id, 2);
            Assert.AreEqual(addResult.score.f_sujectId, 4);
            Assert.AreEqual(addResult.score.f_point, 85);

            var queryReuslt = this.repo.Query(null);

            Assert.IsNull(queryReuslt.exception);
            Assert.IsNotNull(queryReuslt.scores);
            Assert.AreEqual(queryReuslt.scores.Count(), 2);

            queryReuslt = this.repo.Query(4);

            Assert.IsNull(queryReuslt.exception);
            Assert.IsNotNull(queryReuslt.scores);
            Assert.AreEqual(queryReuslt.scores.Count(), 1);
        }
    }
}
