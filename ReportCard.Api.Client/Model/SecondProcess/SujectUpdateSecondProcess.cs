
namespace ReportCard.Api.Client.Model.SecondProcess
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Domain.Service;

    public class SujectUpdateSecondProcess : ISecondProcess
    {
        private ISujectService svc;

        private IConcoleWrapper console;

        public SujectUpdateSecondProcess(ISujectService svc, IConcoleWrapper console)
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

                string sujectName = string.Empty;

                while (string.IsNullOrEmpty(sujectName))
                {
                    this.console.Clear();
                    this.console.Write("更新名稱:");
                    sujectName = this.console.ReadLine();
                }

                var updateResult = this.svc.Update(new SujectUpdateDto()
                {
                    Id = sujectId,
                    Name = sujectName
                });

                if (updateResult.exception != null)
                {
                    throw updateResult.exception;
                }

                this.console.Write($"更新成功:{JsonConvert.SerializeObject(updateResult.suject)}");
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
