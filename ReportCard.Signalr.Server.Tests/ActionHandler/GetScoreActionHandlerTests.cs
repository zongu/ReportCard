
namespace ReportCard.Signalr.Server.Tests.ActionHandler
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.ActionHandler;

    [TestClass]
    public class GetScoreActionHandlerTests
    {
        [TestMethod]
        public void 取Score測試()
        {
            var repo = new Mock<IScoreRepository>();

            repo.Setup(p => p.Query(It.IsAny<int?>()))
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Score()
                {
                    f_id = index + 1,
                    f_sujectId = index + 1,
                    f_point = (index + 1) * 10
                })));

            var handler = new GetScoreSequenceActionHandler(repo.Object);
            var result = handler.ExecuteAction(new ActionModule()
            {
                Message = new GetScoreSequenceAction()
                {
                    SujectId = null
                }.ToString()
            });

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.actionBase);
        }
    }
}
