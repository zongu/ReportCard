
namespace ReportCard.Signalr.Client.Tests.Model.SecondProcess
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;
    using ReportCard.Signalr.Client.Model.SecondProcess;
    using ReportCard.Signalr.Client.Signalr;

    [TestClass]
    public class ScoreAddSecondProcessTests
    {
        [TestMethod]
        public void 新增Score測試()
        {
            var hubClient = new Mock<IHubClient>();
            var console = new Mock<IConcoleWrapper>();

            hubClient.Setup(p => p.GetAction(It.IsAny<GetSujectSequenceAction>()))
                .Returns(Task.FromResult(new ActionModule()
                {
                    Message = new SujectSequenceAction()
                    {
                        Sujects = Enumerable.Range(1, 3).Select(index => new Suject()
                        {
                            f_id = index + 1,
                            f_name = $"f_name-{index + 1}"
                        })
                    }.ToString()
                }));

            console.SetupSequence(p => p.ReadLine())
                .Returns("1")
                .Returns("80");

            var process = new ScoreAddSecondProcess(hubClient.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
