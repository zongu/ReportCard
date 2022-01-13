
namespace ReportCard.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Persistent.Repository;

    /// <summary>
    /// 刪除科目事務
    /// </summary>
    public class SujectDeleteSecondProcess : ISecondProcess
    {
        private ISujectRepository repo;

        public SujectDeleteSecondProcess(ISujectRepository repo)
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
                Console.Write("移除ID:");

                int sujectId = -1;

                while (
                    !int.TryParse(Console.ReadLine(), out sujectId) &&
                    !getResult.sujects.Any(p => p.f_id == sujectId))
                {
                    Console.Clear();
                    Console.WriteLine(string.Join("\r\n", sujectFormat));
                    Console.Write("移除ID:");
                }

                var delResult = this.repo.Delete(sujectId);

                if (delResult.exception != null)
                {
                    throw delResult.exception;
                }

                Console.Write($"移除成功:{JsonConvert.SerializeObject(delResult.suject)}");
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
