
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
    public class GetSujectSequenceActionHandlerTests
    {
        [TestMethod]
        public void 取Suject測試()
        {
            var repo = new Mock<ISujectRepository>();

            repo.Setup(p => p.Query())
                .Returns((null, Enumerable.Range(1, 3).Select(index => new Suject()
                {
                    f_id = index + 1,
                    f_name = $"f_name-{index + 1}"
                })));

            var handler = new GetSujectSequenceActionHandler(repo.Object);
            var result = handler.ExecuteAction(new ActionModule()
            {
                Message = new GetSujectSequenceAction() { }.ToString()
            });

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.actionBase);
        }
    }
}
