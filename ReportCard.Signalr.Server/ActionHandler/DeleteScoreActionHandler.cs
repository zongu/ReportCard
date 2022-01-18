
namespace ReportCard.Signalr.Server.ActionHandler
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.Model;

    /// <summary>
    /// 解析deleteScoreAction
    /// </summary>
    public class DeleteScoreActionHandler : IActionHandler
    {
        private IScoreRepository repo;

        public DeleteScoreActionHandler(IScoreRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<DeleteScoreAction>(action.Message);
                var delResult = this.repo.Delete(content.Id);

                if (delResult.exception != null)
                {
                    throw delResult.exception;
                }

                var actionResult = new ScoreAction()
                {
                    Score = delResult.score
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
