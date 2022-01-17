
namespace ReportCard.Api.Client.Model.SecondProcess
{
    using System;
    using System.Linq;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Domain.Service;

    public class ScoreQuerySecondProcess : ISecondProcess
    {
        private ISujectService sujectSvc;

        private IScoreService scoreSvc;

        private IConcoleWrapper console;

        public ScoreQuerySecondProcess(ISujectService sujectSvc, IScoreService scoreSvc, IConcoleWrapper console)
        {
            this.sujectSvc = sujectSvc;
            this.scoreSvc = scoreSvc;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                var getSujectResult = this.sujectSvc.Query();

                if (getSujectResult.exception != null)
                {
                    throw getSujectResult.exception;
                }

                var getScoreResult = this.scoreSvc.Query(null);

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
