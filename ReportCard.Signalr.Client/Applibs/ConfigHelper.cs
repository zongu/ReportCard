
namespace ReportCard.Signalr.Client.Applibs
{
    using System.Configuration;

    internal static class ConfigHelper
    {
        public static string SignalrUrl
        {
            get
                => $"http://{ConfigurationManager.AppSettings["SignalrUrl"]}:8085/signalr";
        }
    }
}
