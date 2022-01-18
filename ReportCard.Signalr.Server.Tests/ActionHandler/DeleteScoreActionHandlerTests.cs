
namespace ReportCard.Signalr.Server.Tests.ActionHandler
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.ActionHandler;

    [TestClass]
    public class DeleteScoreActionHandlerTests
    {
        [TestMethod]
        public void 移除Score測試()
        {
            var repo = new Mock<IScoreRepository>();

            repo.Setup(p => p.Delete(2))
                .Returns((null, new Score()
                {
                    f_id = 2,
                    f_sujectId = 1,
                    f_point = 80
                }));

            var handler = new DeleteScoreActionHandler(repo.Object);
            var result = handler.ExecuteAction(new ActionModule()
            {
                Message = new DeleteScoreAction()
                {
                    Id = 2
                }.ToString()
            });

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.actionBase);
        }
    }
}
