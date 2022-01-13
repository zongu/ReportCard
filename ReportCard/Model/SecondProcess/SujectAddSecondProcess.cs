
namespace ReportCard.Model.SecondProcess
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Persistent.Repository;

    /// <summary>
    /// 新增科目事務
    /// </summary>
    public class SujectAddSecondProcess : ISecondProcess
    {
        private ISujectRepository repo;

        public SujectAddSecondProcess(ISujectRepository repo)
        {
            this.repo = repo;
        }

        public bool Execute()
        {
            try
            {
                var sujectName = string.Empty;

                while (string.IsNullOrEmpty(sujectName))
                {
                    Console.Clear();
                    Console.Write("科目名稱:");
                    sujectName = Console.ReadLine();
                }

                var addResult = this.repo.Add(sujectName);

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                Console.Write($"新增成功:{JsonConvert.SerializeObject(addResult.suject)}");
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
