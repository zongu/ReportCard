
namespace ReportCard.Applibs
{
    using System.Configuration;

    internal static class ConfigHelper
    {
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ReportCard"].ConnectionString;
    }
}
