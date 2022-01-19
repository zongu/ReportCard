
namespace ReportCard.Signalr.Client.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Signalr.Client.Signalr;

    public class ScoreDeleteSecondProcess : ISecondProcess
    {
        private IHubClient hubClient;

        private IConcoleWrapper console;

        public ScoreDeleteSecondProcess(IHubClient hubClient, IConcoleWrapper console)
        {
            this.hubClient = hubClient;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                var sujectSequenceActionResult = this.hubClient.GetAction(new GetSujectSequenceAction()).Result;

                if (sujectSequenceActionResult == null)
                {
                    throw new Exception($"{this.GetType().Name} GetSujectSequenceAction Empty");
                }

                var sujectSequenceAction = JsonConvert.DeserializeObject<SujectSequenceAction>(sujectSequenceActionResult.Message);

                var scoreSequenceActionResult = this.hubClient.GetAction(new GetScoreSequenceAction() { SujectId = null }).Result;

                if (scoreSequenceActionResult == null)
                {
                    throw new Exception($"{this.GetType().Name} GetScoreSequenceAction Empty");
                }

                var scoreSequenceAction = JsonConvert.DeserializeObject<ScoreSequenceAction>(scoreSequenceActionResult.Message);

                var displayFormat = scoreSequenceAction.Scores.Select(s =>
                {
                    var id = s.f_id;
                    var suject = sujectSequenceAction.Sujects.FirstOrDefault(p => p.f_id == s.f_sujectId)?.f_name ?? "已刪除";
                    var point = s.f_point;

                    return $"{id}.\t{suject}\t{point}";
                });

                this.console.WriteLine(string.Join("\r\n", displayFormat));
                this.console.Write("移除ID:");

                int scoreId = -1;

                while (
                    !int.TryParse(this.console.ReadLine(), out scoreId) &&
                    !scoreSequenceAction.Scores.Any(p => p.f_id == scoreId))
                {
                    this.console.Clear();
                    this.console.WriteLine(string.Join("\r\n", displayFormat));
                    this.console.Write("移除ID:");
                }

                this.hubClient.SendAction(new DeleteScoreAction()
                {
                    Id = scoreId
                });

                this.console.WriteLine("SendAction DeleteScoreAction");
                this.console.Read();

                return true;
            }
            catch (Exception ex)
            {
                this.console.Clear();
                this.console.WriteLine(ex.Message);
                this.console.Read();

                return false;
            }
        }
    }
}
