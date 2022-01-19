
namespace ReportCard.Signalr.Client.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Signalr.Client.Signalr;

    public class ScoreAddSecondProcess : ISecondProcess
    {
        private IHubClient hubClient;

        private IConcoleWrapper console;

        public ScoreAddSecondProcess(IHubClient hubClient, IConcoleWrapper console)
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

                if (!sujectSequenceAction.Sujects.Any())
                {
                    this.console.WriteLine("請先新增科目");
                    this.console.Read();
                    this.console.Clear();
                    return true;
                }

                var sujectFormat = sujectSequenceAction.Sujects.Select(s => $"{s.f_id}.{s.f_name}");
                this.console.WriteLine(string.Join("\r\n", sujectFormat));
                this.console.Write("更新ID:");

                int sujectId = -1;

                while (
                    !int.TryParse(this.console.ReadLine(), out sujectId) &&
                    !sujectSequenceAction.Sujects.Any(p => p.f_id == sujectId))
                {
                    this.console.Clear();
                    this.console.WriteLine(string.Join("\r\n", sujectFormat));
                    this.console.Write("更新ID:");
                }

                this.console.Write("分數(0~100):");

                int point = -1;

                while (
                    !int.TryParse(this.console.ReadLine(), out point) &&
                    (point < 0 || point > 100))
                {
                    this.console.Clear();
                    this.console.WriteLine(string.Join("\r\n", sujectFormat));
                    this.console.Write("分數(0~100):");
                }

                this.hubClient.SendAction(new AddScoreAction()
                {
                    SujectId = sujectId,
                    Point = point
                });

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
