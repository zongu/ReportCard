
namespace ReportCard.Signalr.Server.Applibs
{
    using System.Configuration;

    internal static class ConfigHelper
    {
        public static string SignalrUrl
        {
            get
                => $"http://*:8085";
        }

        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ReportCard"].ConnectionString;
    }
}
