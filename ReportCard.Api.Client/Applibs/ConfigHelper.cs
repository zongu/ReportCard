
namespace ReportCard.Api.Client.Applibs
{
    using System.Configuration;

    internal static class ConfigHelper
    {
        public static string ServiceUrl 
        {
            get
                => $"http://{ConfigurationManager.AppSettings["ServiceUrl"]}:8085";
        }
    }
}
