
namespace ReportCard.Signalr.Server.ActionHandler
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.Model;

    public class AddScoreActionHandler : IActionHandler
    {
        private IScoreRepository repo;

        public AddScoreActionHandler(IScoreRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<AddScoreAction>(action.Message);
                var addResult = this.repo.Add(content.SujectId, content.Point);

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                var actionResult = new ScoreAction()
                {
                    Score = addResult.score
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
