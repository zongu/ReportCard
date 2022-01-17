
namespace ReportCard.Api.Client.Tests.Model.SecondProcess
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Api.Client.Model.SecondProcess;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Service;

    [TestClass]
    public class SujectDeleteSecondProcessTests
    {
        [TestMethod]
        public void 移除科目測試()
        {
            var svc = new Mock<ISujectService>();
            var console = new Mock<IConcoleWrapper>();

            svc.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            svc.Setup(p => p.Delete(2))
                .Returns((null, new Suject()
                {
                    f_id = 2,
                    f_name = "f_name-2"
                }));

            console.Setup(p => p.ReadLine())
                .Returns("2");

            var proecess = new SujectDeleteSecondProcess(svc.Object, console.Object);
            var result = proecess.Execute();

            Assert.IsTrue(result);
        }
    }
}
