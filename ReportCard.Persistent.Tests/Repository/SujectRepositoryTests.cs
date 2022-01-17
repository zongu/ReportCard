
namespace ReportCard.Persistent.Tests.Repository
{
    using System.Data.SqlClient;
    using System.Linq;
    using Dapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;
    using ReportCard.Persistent.Repository;

    [TestClass]
    public class SujectRepositoryTests
    {
        private const string connectionString = @"Data Source=localhost;database=ReportCard;Integrated Security=True";

        private ISujectRepository repo;

        [TestInitialize]
        public void Init()
        {
            var sqlStr = @"TRUNCATE TABLE t_suject";

            using (var cn = new SqlConnection(connectionString))
            {
                cn.Execute(sqlStr);
            }

            this.repo = new SujectRepository(connectionString);
        }

        [TestMethod]
        public void 新增科目測試()
        {
            var result = this.repo.Add("TEST001");

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.suject);
            Assert.AreEqual(result.suject.f_id, 1);
            Assert.AreEqual(result.suject.f_name, "TEST001");
        }

        [TestMethod]
        public void 移除科目測試()
        {
            var delResult = this.repo.Delete(1);

            Assert.IsNull(delResult.exception);
            Assert.IsNull(delResult.suject);

            var addResult = this.repo.Add("TEST001");

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.suject);
            Assert.AreEqual(addResult.suject.f_id, 1);
            Assert.AreEqual(addResult.suject.f_name, "TEST001");

            delResult = this.repo.Delete(1);

            Assert.IsNull(delResult.exception);
            Assert.IsNotNull(delResult.suject);
            Assert.AreEqual(delResult.suject.f_id, 1);
            Assert.AreEqual(delResult.suject.f_name, "TEST001");
        }

        [TestMethod]
        public void 取得所有科目測試()
        {
            var addResult = this.repo.Add("TEST001");

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.suject);
            Assert.AreEqual(addResult.suject.f_id, 1);
            Assert.AreEqual(addResult.suject.f_name, "TEST001");

            addResult = this.repo.Add("TEST002");

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.suject);
            Assert.AreEqual(addResult.suject.f_id, 2);
            Assert.AreEqual(addResult.suject.f_name, "TEST002");

            var queryResult = this.repo.Query();

            Assert.IsNull(queryResult.exception);
            Assert.IsNotNull(queryResult.sujects);
            Assert.AreEqual(queryResult.sujects.Count(), 2);
        }

        [TestMethod]
        public void 更新科目測試()
        {
            var updateReuslt = this.repo.Update(new Suject()
            {
                f_id = 1,
                f_name = "UPDATE001"
            });

            Assert.IsNull(updateReuslt.exception);
            Assert.IsNull(updateReuslt.suject);

            var addResult = this.repo.Add("TEST001");

            Assert.IsNull(addResult.exception);
            Assert.IsNotNull(addResult.suject);
            Assert.AreEqual(addResult.suject.f_id, 1);
            Assert.AreEqual(addResult.suject.f_name, "TEST001");

            updateReuslt = this.repo.Update(new Suject()
            {
                f_id = 1,
                f_name = "UPDATE001"
            });

            Assert.IsNull(updateReuslt.exception);
            Assert.IsNotNull(updateReuslt.suject);
            Assert.AreEqual(updateReuslt.suject.f_id, 1);
            Assert.AreEqual(updateReuslt.suject.f_name, "UPDATE001");
        }
    }
}
