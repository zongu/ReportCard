
namespace ReportCard.Api.Client.Tests.Model.SecondProcess
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Api.Client.Model.SecondProcess;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Service;

    [TestClass]
    public class ScoreAddSecondProcessTests
    {
        [TestMethod]
        public void 新增分數測試()
        {
            var sujectSvc = new Mock<ISujectService>();
            var scoreSvc = new Mock<IScoreService>();
            var console = new Mock<IConcoleWrapper>();

            sujectSvc.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 5).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            scoreSvc.Setup(p => p.Add(It.IsAny<ScoreAddDto>()))
                .Returns((null, new Score()
                {
                    f_id = 1,
                    f_sujectId = 1,
                    f_point = 100
                }));

            console.SetupSequence(p => p.ReadLine())
                .Returns("1")
                .Returns("100");

            var process = new ScoreAddSecondProcess(sujectSvc.Object, scoreSvc.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
