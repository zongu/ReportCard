
namespace ReportCard.Api.Server.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using ReportCard.Api.Server.Controllers;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;

    [TestClass]
    public class ScoreControllerTests
    {
        [TestMethod]
        public void GetTest()
        {
            var repo = new Mock<IScoreRepository>();

            repo.Setup(p => p.Query(It.IsAny<int?>()))
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Score()
                {
                    f_id = index + 1,
                    f_sujectId = index + 1,
                    f_point = (index + 1) * 10
                })));

            var controller = new ScoreController(repo.Object);
            var getRsult = controller.Get(null);
            var result = JsonConvert.DeserializeObject<IEnumerable<Score>>(getRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(getRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PutTest()
        {

            var repo = new Mock<IScoreRepository>();

            repo.Setup(p => p.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((null, new Score()
                {
                    f_id = 1,
                    f_sujectId = 1,
                    f_point = 80
                }));

            var controller = new ScoreController(repo.Object);
            var postRsult = controller.Post(new ScoreAddDto()
            {
                SujectId = 1,
                point = 80
            });

            var result = JsonConvert.DeserializeObject<Score>(postRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var repo = new Mock<IScoreRepository>();

            repo.Setup(p => p.Delete(It.IsAny<int>()))
                .Returns((null, new Score()
                {
                    f_id = 1,
                    f_sujectId = 1,
                    f_point = 80
                }));

            var controller = new ScoreController(repo.Object);
            var delRsult = controller.Delete(1);

            var result = JsonConvert.DeserializeObject<Score>(delRsult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(delRsult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }
    }
}
