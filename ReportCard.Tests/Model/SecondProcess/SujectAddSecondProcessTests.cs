
namespace ReportCard.Tests.Model.SecondProcess
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;
    using ReportCard.Model.SecondProcess;

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
