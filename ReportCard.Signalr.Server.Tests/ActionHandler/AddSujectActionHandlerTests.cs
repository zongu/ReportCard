
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
    public class AddSujectActionHandlerTests
    {
        [TestMethod]
        public void 新增Suject測試()
        {
            var repo = new Mock<ISujectRepository>();

            repo.Setup(p => p.Add("TEST001"))
                .Returns((null, new Suject()
                {
                    f_id = 1,
                    f_name = "TEST001"
                }));

            var handler = new AddSujectActionHandler(repo.Object);
            var result = handler.ExecuteAction(new ActionModule()
            {
                Message = new AddSujectAction()
                {
                    Name = "TEST001"
                }.ToString()
            });

            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.actionBase);
        }
    }
}
