
namespace ReportCard.Tests.Model.SecondProcess
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Model;
    using ReportCard.Model.SecondProcess;
    using ReportCard.Persistent.Model;
    using ReportCard.Persistent.Repository;

    [TestClass]
    public class SujectAddSecondProcessTests
    {
        [TestMethod]
        public void 新增科目測試()
        {
            var repo = new Mock<ISujectRepository>();
            var console = new Mock<IConcoleWrapper>();

            console.Setup(p => p.ReadLine())
                .Returns("TEST001");

            repo.Setup(p => p.Add("TEST001"))
                .Returns((null, new Suject()
                {
                    f_id = 1,
                    f_name = "TEST001"
                }));

            var process = new SujectAddSecondProcess(repo.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
