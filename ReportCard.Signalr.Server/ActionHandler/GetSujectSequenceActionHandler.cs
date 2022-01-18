
namespace ReportCard.Signalr.Server.ActionHandler
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.Model;

    /// <summary>
    /// 取Suject指令解析
    /// </summary>
    public class GetSujectSequenceActionHandler : IActionHandler
    {
        private ISujectRepository repo;

        public GetSujectSequenceActionHandler(ISujectRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<GetSujectSequenceAction>(action.Message);
                var getResult = this.repo.Query();

                if (getResult.exception != null)
                {
                    throw getResult.exception;
                }

                var actionResult = new SujectSequenceAction()
                {
                    Sujects = getResult.sujects
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
