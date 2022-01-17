
namespace ReportCard.Api.Server.Applibs
{
    using System.Configuration;

    internal static class ConfigHelper
    {
        public static string ServiceUrl
        {
            get
                => $"http://*:8085";
        }

        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ReportCard"].ConnectionString;
    }
}
