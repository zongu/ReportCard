
namespace ReportCard.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Persistent.Model;
    using ReportCard.Persistent.Repository;

    /// <summary>
    /// 更新課目事務
    /// </summary>
    public class SujectUpdateSecondProcess : ISecondProcess
    {
        private ISujectRepository repo;

        public SujectUpdateSecondProcess(ISujectRepository repo)
        {
            this.repo = repo;
        }

        public bool Execute()
        {
            try
            {
                Console.Clear();
                var getResult = this.repo.Query();

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

                string sujectName = string.Empty;

                while (string.IsNullOrEmpty(sujectName))
                {
                    Console.Clear();
                    Console.Write("更新名稱:");
                    sujectName = Console.ReadLine();
                }

                var updateResult = this.repo.Update(new Suject()
                {
                    f_id = sujectId,
                    f_name = sujectName
                });

                if (updateResult.exception != null)
                {
                    throw updateResult.exception;
                }

                Console.Write($"更新成功:{JsonConvert.SerializeObject(updateResult.suject)}");
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
