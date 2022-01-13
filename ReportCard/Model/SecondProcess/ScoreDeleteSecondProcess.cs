
namespace ReportCard.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Persistent.Repository;

    /// <summary>
    /// 移除分數事務
    /// </summary>
    public class ScoreDeleteSecondProcess : ISecondProcess
    {
        private ISujectRepository sujectRepo;

        private IScoreRepository scoreRepo;

        public ScoreDeleteSecondProcess(ISujectRepository sujectRepo, IScoreRepository scoreRepo)
        {
            this.sujectRepo = sujectRepo;
            this.scoreRepo = scoreRepo;
        }

        public bool Execute()
        {
            try
            {
                Console.Clear();
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

                Console.WriteLine(string.Join("\r\n", displayFormat));
                Console.Write("移除ID:");

                int scoreId = -1;

                while (
                    !int.TryParse(Console.ReadLine(), out scoreId) &&
                    !getScoreResult.scores.Any(p => p.f_id == scoreId))
                {
                    Console.Clear();
                    Console.WriteLine(string.Join("\r\n", displayFormat));
                    Console.Write("移除ID:");
                }

                var delResult = this.scoreRepo.Delete(scoreId);

                if (delResult.exception != null)
                {
                    throw delResult.exception;
                }

                Console.Write($"移除成功:{JsonConvert.SerializeObject(delResult.score)}");
                Console.Read();
                Console.Clear();

                return true;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.Read();

                return false;
            }
        }
    }
}
