
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
    public class UpdateSujectActionHandlerTests
    {
        [TestMethod]
        public void 更新Suject測試()
        {
            var repo = new Mock<ISujectRepository>();

            repo.Setup(p => p.Update(It.IsAny<Suject>()))
                .Returns((null, new Suject()
                {
                    f_id = 2,
                    f_name = "TEST001"
                }));

            var handler = new UpdateSujectActionHandler(repo.Object);
            var result = handler.ExecuteAction(new ActionModule()
            {
                Message = new UpdateSujectAction()
                {
                    Id = 2,
                    Name = "TEST001"
                }.ToString()
            });

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.actionBase);
        }
    }
}
