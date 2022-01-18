
namespace ReportCard.Signalr.Server.ActionHandler
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.Model;

    /// <summary>
    /// 更新Suject指令解心
    /// </summary>
    public class UpdateSujectActionHandler : IActionHandler
    {
        private ISujectRepository repo;

        public UpdateSujectActionHandler(ISujectRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<UpdateSujectAction>(action.Message);
                var updateReuslt = this.repo.Update(new Suject()
                {
                    f_id = content.Id,
                    f_name = content.Name
                });

                if (updateReuslt.exception != null)
                {
                    throw updateReuslt.exception;
                }

                var actionResult = new SujectAction()
                {
                    Suject = updateReuslt.suject
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
