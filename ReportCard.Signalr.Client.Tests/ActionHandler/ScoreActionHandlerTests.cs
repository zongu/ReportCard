
namespace ReportCard.Signalr.Client.Tests.ActionHandler
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;
    using ReportCard.Signalr.Client.ActionHandler;

    [TestClass]
    public class ScoreActionHandlerTests
    {
        [TestMethod]
        public void Score通知測試()
        {
            var console = new Mock<IConcoleWrapper>();

            var handler = new ScoreActionHandler(console.Object);
            var result = handler.Execute(new ActionModule()
            {
                Message = new ScoreAction()
                {
                    Score = new Score()
                    {
                        f_id = 1,
                        f_sujectId = 1,
                        f_point = 80
                    }
                }.ToString()
            });

            Assert.IsTrue(result);
        }
    }
}
