
namespace ReportCard.Signalr.Client.Tests.ActionHandler
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;
    using ReportCard.Signalr.Client.ActionHandler;

    [TestClass]
    public class SujectActionHandlerTests
    {
        [TestMethod]
        public void Suject指令通知測試()
        {
            var console = new Mock<IConcoleWrapper>();

            var handler = new SujectActionHandler(console.Object);
            var result = handler.Execute(new ActionModule()
            {
                Message = new SujectAction()
                {
                    Suject = new Suject()
                    {
                        f_id = 1,
                        f_name = "TEST001"
                    }
                }.ToString()
            });

            Assert.IsTrue(result);
        }
    }
}
