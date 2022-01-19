
namespace ReportCard.Signalr.Client.Tests.Model.SecondProcess
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Model;
    using ReportCard.Signalr.Client.Model.SecondProcess;
    using ReportCard.Signalr.Client.Signalr;

    [TestClass]
    public class SujectAddSecondProcessTests
    {
        [TestMethod]
        public void 新增Suject測試()
        {
            var hubClient = new Mock<IHubClient>();
            var console = new Mock<IConcoleWrapper>();

            console.Setup(p => p.ReadLine())
                .Returns("TEST001");

            var process = new SujectAddSecondProcess(hubClient.Object, console.Object);
            var result = process.Execute();

            Assert.IsTrue(result);
        }
    }
}
