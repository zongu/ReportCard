
namespace ReportCard.Signalr.Server.ActionHandler
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.Model;

    public class GetScoreSequenceActionHandler : IActionHandler
    {
        private IScoreRepository repo;

        public GetScoreSequenceActionHandler(IScoreRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<GetScoreSequenceAction>(action.Message);
                var getResult = this.repo.Query(content.SujectId);

                if (getResult.exception != null)
                {
                    throw getResult.exception;
                }

                var actionResult = new ScoreSequenceAction()
                {
                    Scores = getResult.scores
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
