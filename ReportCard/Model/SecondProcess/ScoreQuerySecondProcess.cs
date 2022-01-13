
namespace ReportCard.Model.SecondProcess
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using ReportCard.Persistent.Repository;

    /// <summary>
    /// 查找分數業務
    /// </summary>
    public class ScoreQuerySecondProcess : ISecondProcess
    {
        private ISujectRepository sujectRepo;

        private IScoreRepository scoreRepo;

        public ScoreQuerySecondProcess(ISujectRepository sujectRepo, IScoreRepository scoreRepo)
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
