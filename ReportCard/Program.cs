
namespace ReportCard
{
    using System;
    using System.Linq;
    using Autofac;
    using Autofac.Features.Indexed;
    using ReportCard.Model;
    using ReportCard.Model.FirstProcess;

    class Program
    {
        static void Main(string[] args)
        {
            var legalTypes = new FistProcessType[]
            {
                FistProcessType.SujectKind,
                FistProcessType.ScoreKind
            };

            var legalTypesFormat = legalTypes.Select(t => $"{((int)t)}");
            var legalTypesDisplay = legalTypes.Select(t => t.ToDisplay());

            try
            {
                var processSets = Applibs.AutofacConfig.Container.Resolve<IIndex<FistProcessType, IFirstProcess>>();

                string cmd = string.Empty;

                while (cmd.ToLower() != "exit")
                {
                    Console.Clear();

                    // 處理第一層業務
                    if (legalTypesFormat.Any(p => p == cmd) &&
                        processSets.TryGetValue((FistProcessType)Convert.ToInt32(cmd), out IFirstProcess process) &&
                        !process.Execute())
                    {

                        Console.Clear();
                        Console.WriteLine("Finished!");
                        Console.Read();
                    }

                    Console.WriteLine(string.Join("\r\n", legalTypesDisplay));

                    cmd = Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.Read();
            }

            Console.Clear();
            Console.WriteLine("Finished!");
            Console.Read();
        }
    }
}
