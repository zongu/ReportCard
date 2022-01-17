
namespace ReportCard.Tests.Model.SecondProcess
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;
    using ReportCard.Model.SecondProcess;

    [TestClass]
    public class ScoreQuerySecondProcessTests
    {
        [TestMethod]
        public void 取分數測試()
        {
            var sujectRepo = new Mock<ISujectRepository>();
            var scoreRepo = new Mock<IScoreRepository>();
            var console = new Mock<IConcoleWrapper>();

            sujectRepo.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            scoreRepo.Setup(p => p.Query(null))
                .Returns((null, Enumerable.Range(1, 10).Select(index => new Score()
                {
                    f_id = index + 1,
                    f_sujectId = (index % 3) + 1,
                    f_point = index * 5 + 1
                })));

            var process = new ScoreQuerySecondProcess(sujectRepo.Object, scoreRepo.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
