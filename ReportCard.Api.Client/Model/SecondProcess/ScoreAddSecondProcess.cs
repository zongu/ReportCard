
namespace ReportCard.Api.Client.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Domain.Service;

    public class ScoreAddSecondProcess : ISecondProcess
    {
        private ISujectService sujectRepo;

        private IScoreService scoreRepo;

        private IConcoleWrapper console;

        public ScoreAddSecondProcess(ISujectService sujectRepo, IScoreService scoreRepo, IConcoleWrapper console)
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
                var getResult = this.sujectRepo.Query();

                if (getResult.exception != null)
                {
                    throw getResult.exception;
                }

                if (!getResult.sujects.Any())
                {
                    this.console.WriteLine("請先新增科目");
                    this.console.Read();
                    this.console.Clear();
                    return true;
                }

                var sujectFormat = getResult.sujects.Select(s => $"{s.f_id}.{s.f_name}");
                this.console.WriteLine(string.Join("\r\n", sujectFormat));
                this.console.Write("更新ID:");

                int sujectId = -1;

                while (
                    !int.TryParse(this.console.ReadLine(), out sujectId) &&
                    !getResult.sujects.Any(p => p.f_id == sujectId))
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

                var addResult = this.scoreRepo.Add(new ScoreAddDto()
                {
                    SujectId = sujectId,
                    Point = point
                });

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                this.console.Write($"新增成功:{JsonConvert.SerializeObject(addResult.score)}");
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
