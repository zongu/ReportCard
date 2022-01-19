
namespace ReportCard.Signalr.Client
{
    using System;
    using System.Linq;
    using System.Threading;
    using Autofac;
    using Autofac.Features.Indexed;
    using Microsoft.AspNet.SignalR.Client;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.FirstProcess;
    using ReportCard.Signalr.Client.Signalr;

    class Program
    {
        static void Main(string[] args)
        {
            var console = Applibs.AutofacConfig.Container.Resolve<IConcoleWrapper>();

            var legalTypes = new FistProcessType[]
            {
                FistProcessType.SujectKind,
                FistProcessType.ScoreKind
            };

            var legalTypesFormat = legalTypes.Select(t => $"{((int)t)}");
            var legalTypesDisplay = legalTypes.Select(t => t.ToDisplay());

            try
            {
                var hubClient = Applibs.AutofacConfig.Container.Resolve<IHubClient>();
                hubClient.StartAsync();

                while(!SpinWait.SpinUntil(() => false, 1000) && hubClient.State != ConnectionState.Connected)
                {
                    console.Clear();
                    console.WriteLine($"HubClient State:{hubClient.State}...");
                }

                var processSets = Applibs.AutofacConfig.Container.Resolve<IIndex<FistProcessType, IFirstProcess>>();

                string cmd = string.Empty;

                while (cmd.ToLower() != "exit")
                {
                    console.Clear();

                    // 處理第一層業務
                    if (legalTypesFormat.Any(p => p == cmd) &&
                        processSets.TryGetValue((FistProcessType)Convert.ToInt32(cmd), out IFirstProcess process) &&
                        !process.Execute())
                    {

                        console.Clear();
                        console.WriteLine("Finished!");
                        console.Read();
                    }

                    console.WriteLine(string.Join("\r\n", legalTypesDisplay));

                    cmd = console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                console.Clear();
                console.WriteLine(ex.Message);
                console.Read();
            }

            console.Clear();
            console.WriteLine("Finished!");
            console.Read();
        }
    }
}
