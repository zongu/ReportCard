
namespace ReportCard.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Persistent.Repository;

    /// <summary>
    /// 新增分數事務
    /// </summary>
    public class ScoreAddSecondProcess : ISecondProcess
    {
        private ISujectRepository sujectRepo;

        private IScoreRepository scoreRepo;

        public ScoreAddSecondProcess(ISujectRepository sujectRepo, IScoreRepository scoreRepo)
        {
            this.sujectRepo = sujectRepo;
            this.scoreRepo = scoreRepo;
        }

        public bool Execute()
        {
            try
            {
                Console.Clear();
                var getResult = this.sujectRepo.Query();

                if (getResult.exception != null)
                {
                    throw getResult.exception;
                }

                if (!getResult.sujects.Any())
                {
                    Console.WriteLine("請先新增科目");
                    Console.Read();
                    Console.Clear();
                    return true;
                }

                var sujectFormat = getResult.sujects.Select(s => $"{s.f_id}.{s.f_name}");
                Console.WriteLine(string.Join("\r\n", sujectFormat));
                Console.Write("更新ID:");

                int sujectId = -1;

                while (
                    !int.TryParse(Console.ReadLine(), out sujectId) &&
                    !getResult.sujects.Any(p => p.f_id == sujectId))
                {
                    Console.Clear();
                    Console.WriteLine(string.Join("\r\n", sujectFormat));
                    Console.Write("更新ID:");
                }

                Console.Write("分數(0~100):");

                int point = -1;

                while (
                    !int.TryParse(Console.ReadLine(), out point) &&
                    (point < 0 || point > 100))
                {
                    Console.Clear();
                    Console.WriteLine(string.Join("\r\n", sujectFormat));
                    Console.Write("分數(0~100):");
                }

                var addResult = this.scoreRepo.Add(sujectId, point);

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                Console.Write($"新增成功:{JsonConvert.SerializeObject(addResult.score)}");
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
