
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
    public class SujectControllerTests
    {
        [TestMethod]
        public void GetTest()
        {
            var repo = new Mock<ISujectRepository>();

            repo.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            var controller = new SujectController(repo.Object);
            var getResult = controller.Get();
            var result = JsonConvert.DeserializeObject<IEnumerable<Suject>>(getResult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(getResult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PostTest()
        {
            var repo = new Mock<ISujectRepository>();

            repo.Setup(p => p.Add("TEST001"))
                .Returns((null, new Suject()
                {
                    f_id = 1,
                    f_name = "TEST001"
                }));

            var controller = new SujectController(repo.Object);
            var postResult = controller.Post(new SujectAddDto()
            {
                Name = "TEST001"
            });

            var result = JsonConvert.DeserializeObject<Suject>(postResult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(postResult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PutTest()
        {
            var repo = new Mock<ISujectRepository>();

            repo.Setup(p => p.Update(It.IsAny<Suject>()))
                .Returns((null, new Suject()
                {
                    f_id = 1,
                    f_name = "UPDATE001"
                }));

            var controller = new SujectController(repo.Object);
            var putResult = controller.Put(new SujectUpdateDto()
            {
                Id = 1,
                Name = "UPDATE001"
            });

            var result = JsonConvert.DeserializeObject<Suject>(putResult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(putResult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var repo = new Mock<ISujectRepository>();

            repo.Setup(p => p.Delete(1))
                .Returns((null, new Suject()
                {
                    f_id = 1,
                    f_name = "TEST001"
                }));

            var controller = new SujectController(repo.Object);
            var delResult = controller.Delete(1);

            var result = JsonConvert.DeserializeObject<Suject>(delResult.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(delResult.StatusCode, HttpStatusCode.OK);
            Assert.IsNotNull(result);
        }
    }
}
