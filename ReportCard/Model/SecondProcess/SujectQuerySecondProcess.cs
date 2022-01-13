
namespace ReportCard.Model.SecondProcess
{
    using System;
    using System.Linq;
    using ReportCard.Persistent.Repository;

    /// <summary>
    /// 科目查找事務
    /// </summary>
    public class SujectQuerySecondProcess : ISecondProcess
    {
        private ISujectRepository repo;

        public SujectQuerySecondProcess(ISujectRepository repo)
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
