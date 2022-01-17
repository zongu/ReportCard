
namespace ReportCard.Api.Client.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Domain.Service;

    public class ScoreDeleteSecondProcess : ISecondProcess
    {
        private ISujectService sujectRepo;

        private IScoreService scoreRepo;

        private IConcoleWrapper console;

        public ScoreDeleteSecondProcess(ISujectService sujectRepo, IScoreService scoreRepo, IConcoleWrapper console)
        {
            this.sujectRepo = sujectRepo;
            this.scoreRepo = scoreRepo;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                var getSujectResult = this.sujectRepo.Query();

                if (getSujectResult.exception != null)
                {
                    throw getSujectResult.exception;
                }

                var getScoreResult = this.scoreRepo.Query(null);

                if (getScoreResult.exception != null)
                {
                    throw getScoreResult.exception;
                }

                var displayFormat = getScoreResult.scores.Select(s =>
                {
                    var id = s.f_id;
                    var suject = getSujectResult.sujects.FirstOrDefault(p => p.f_id == s.f_sujectId)?.f_name ?? "已刪除";
                    var point = s.f_point;

                    return $"{id}.\t{suject}\t{point}";
                });

                this.console.WriteLine(string.Join("\r\n", displayFormat));
                this.console.Write("移除ID:");

                int scoreId = -1;

                while (
                    !int.TryParse(this.console.ReadLine(), out scoreId) &&
                    !getScoreResult.scores.Any(p => p.f_id == scoreId))
                {
                    this.console.Clear();
                    this.console.WriteLine(string.Join("\r\n", displayFormat));
                    this.console.Write("移除ID:");
                }

                var delResult = this.scoreRepo.Delete(scoreId);

                if (delResult.exception != null)
                {
                    throw delResult.exception;
                }

                this.console.Write($"移除成功:{JsonConvert.SerializeObject(delResult.score)}");
                this.console.Read();
                this.console.Clear();

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
