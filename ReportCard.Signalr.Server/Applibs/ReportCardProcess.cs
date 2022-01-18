
namespace ReportCard.Signalr.Server.Applibs
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using NLog;

    internal static class ReportCardProcess
    {
        private static ILogger logger = LogManager.GetLogger("ReportCard.Signalr.Server");

        public static void ProcessStart()
        {
            logger.Info("ReportCard.Signalr.Server Application_Start");
            var container = AutofacConfig.Container;

            Task.Run(() =>
            {
                while (!SpinWait.SpinUntil(() => false, 1000))
                {
                    Console.Clear();
                    Console.WriteLine($"Current Memory Usage:{(int)((GC.GetTotalMemory(true) / 1024f))}(KB)");
                    Console.WriteLine($"Process Memory Usage:{(int)((Process.GetCurrentProcess().PrivateMemorySize64 / 1024f))}(KB)");
                    Console.WriteLine($"Handle count:{Process.GetCurrentProcess().HandleCount}");
                    Console.WriteLine($"Thread count:{Process.GetCurrentProcess().Threads.Count}");
                }
            });

            logger.Info("ReportCard.Signalr.Server Started");
        }

        public static void ProcessStop()
        {
            logger.Info("ReportCard.Signalr.Server Ended");
        }
    }
}
