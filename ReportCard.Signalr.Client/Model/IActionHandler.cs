
namespace ReportCard.Signalr.Client.Model
{
    using ReportCard.Domain.KeepAliveConn;

    public interface IActionHandler
    {
        bool Execute(ActionModule actionModule);
    }
}
