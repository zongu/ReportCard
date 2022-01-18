
namespace ReportCard.Signalr.Server.ActionHandler
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.Model;

    /// <summary>
    /// 移除Suject解析
    /// </summary>
    public class DeleteSujectActionHandler : IActionHandler
    {
        private ISujectRepository repo;

        public DeleteSujectActionHandler(ISujectRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<DeleteSujectAction>(action.Message);
                var delResult = this.repo.Delete(content.Id);

                if(delResult.exception != null)
                {
                    throw delResult.exception;
                }

                var actionResult = new SujectAction()
                {
                    Suject = delResult.suject
                };

                return (null, actionResult);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
