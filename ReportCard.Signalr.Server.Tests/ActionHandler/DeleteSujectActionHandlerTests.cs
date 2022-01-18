
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
    public class DeleteSujectActionHandlerTests
    {
        [TestMethod]
        public void 移除Suject測試()
        {
            var repo = new Mock<ISujectRepository>();

            repo.Setup(p => p.Delete(2))
                .Returns((null, new Suject()
                {
                    f_id = 2,
                    f_name = "TEST001"
                }));

            var handler = new DeleteSujectActionHandler(repo.Object);
            var result = handler.ExecuteAction(new ActionModule()
            {
                Message = new DeleteSujectAction()
                {
                    Id = 2
                }.ToString()
            });

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.actionBase);
        }
    }
}
