
namespace ReportCard.Api.Client.Model.SecondProcess
{
    using System;
    using System.Linq;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Domain.Service;

    public class SujectQuerySecondProcess : ISecondProcess
    {
        private ISujectService svc;

        private IConcoleWrapper console;

        public SujectQuerySecondProcess(ISujectService svc, IConcoleWrapper console)
        {
            this.svc = svc;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                var getResult = this.svc.Query();

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
