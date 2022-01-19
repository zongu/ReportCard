
namespace ReportCard.Signalr.Client.Model.SecondProcess
{
    using System;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.SecondProcess;
    using ReportCard.Signalr.Client.Signalr;

    public class SujectAddSecondProcess : ISecondProcess
    {
        private IHubClient hubClient;

        private IConcoleWrapper console;

        public SujectAddSecondProcess(IHubClient hubClient, IConcoleWrapper console)
        {
            this.hubClient = hubClient;
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

                this.hubClient.SendAction(new AddSujectAction()
                {
                    Name = sujectName
                });

                this.console.WriteLine("SendAction AddSujectAction");
                this.console.Read();
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
