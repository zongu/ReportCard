
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
    public class AddScoreActionHandlerTests
    {
        [TestMethod]
        public void 新增Score測試()
        {
            var repo = new Mock<IScoreRepository>();

            repo.Setup(p => p.Add(1, 80))
                .Returns((null, new Score()
                {
                    f_id = 1,
                    f_sujectId = 1,
                    f_point = 80
                }));

            var handler = new AddScoreActionHandler(repo.Object);
            var result = handler.ExecuteAction(new ActionModule()
            {
                Message = new AddScoreAction()
                {
                    SujectId = 1,
                    Point = 80
                }.ToString()
            });

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.actionBase);
        }
    }
}
