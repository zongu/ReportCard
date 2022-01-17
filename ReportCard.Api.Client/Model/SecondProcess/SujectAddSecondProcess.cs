
namespace ReportCard.Api.Client.Model.SecondProcess
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Domain.Service;

    public class SujectAddSecondProcess : ISecondProcess
    {
        private ISujectService repo;

        private IConcoleWrapper console;

        public SujectAddSecondProcess(ISujectService repo, IConcoleWrapper console)
        {
            this.repo = repo;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                var sujectName = string.Empty;

                while (string.IsNullOrEmpty(sujectName))
                {
                    this.console.Clear();
                    this.console.Write("科目名稱:");
                    sujectName = this.console.ReadLine();
                }

                var addResult = this.repo.Add(sujectName);

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                this.console.Write($"新增成功:{JsonConvert.SerializeObject(addResult.suject)}");
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
