
namespace ReportCard.Tests.Model.SecondProcess
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;
    using ReportCard.Model.SecondProcess;

    [TestClass]
    public class ScoreAddSecondProcessTests
    {
        [TestMethod]
        public void 新增分數測試()
        {
            var sujectRepo = new Mock<ISujectRepository>();
            var scoreRepo = new Mock<IScoreRepository>();
            var console = new Mock<IConcoleWrapper>();

            sujectRepo.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 5).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            scoreRepo.Setup(p => p.Add(1, 100))
                .Returns((null, new Score()
                {
                    f_id = 1,
                    f_sujectId = 1,
                    f_point = 100
                }));

            console.SetupSequence(p => p.ReadLine())
                .Returns("1")
                .Returns("100");

            var process = new ScoreAddSecondProcess(sujectRepo.Object, scoreRepo.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
