
namespace ReportCard.Api.Client.Tests.Model.SecondProcess
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Api.Client.Model.SecondProcess;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Service;

    [TestClass]
    public class ScoreQuerySecondProcessTests
    {
        [TestMethod]
        public void 取分數測試()
        {
            var sujectSvc = new Mock<ISujectService>();
            var scoreSvc = new Mock<IScoreService>();
            var console = new Mock<IConcoleWrapper>();

            sujectSvc.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            scoreSvc.Setup(p => p.Query(null))
                .Returns((null, Enumerable.Range(1, 10).Select(index => new Score()
                {
                    f_id = index + 1,
                    f_sujectId = (index % 3) + 1,
                    f_point = index * 5 + 1
                })));

            var process = new ScoreQuerySecondProcess(sujectSvc.Object, scoreSvc.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
