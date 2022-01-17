
namespace ReportCard.Model.SecondProcess
{
    using System;
    using System.Linq;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Domain.Repository;

    /// <summary>
    /// 查找分數業務
    /// </summary>
    public class ScoreQuerySecondProcess : ISecondProcess
    {
        private ISujectRepository sujectRepo;

        private IScoreRepository scoreRepo;

        private IConcoleWrapper console;

        public ScoreQuerySecondProcess(ISujectRepository sujectRepo, IScoreRepository scoreRepo, IConcoleWrapper console)
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
