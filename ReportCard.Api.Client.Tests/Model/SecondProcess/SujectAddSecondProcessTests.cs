
namespace ReportCard.Api.Client.Tests.Model.SecondProcess
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Api.Client.Model.SecondProcess;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Service;

    [TestClass]
    public class SujectAddSecondProcessTests
    {
        [TestMethod]
        public void 新增科目測試()
        {
            var svc = new Mock<ISujectService>();
            var console = new Mock<IConcoleWrapper>();

            console.Setup(p => p.ReadLine())
                .Returns("TEST001");

            svc.Setup(p => p.Add("TEST001"))
                .Returns((null, new Suject()
                {
                    f_id = 1,
                    f_name = "TEST001"
                }));

            var process = new SujectAddSecondProcess(svc.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
