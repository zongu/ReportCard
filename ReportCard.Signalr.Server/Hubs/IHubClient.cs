
namespace ReportCard.Signalr.Server.Hubs
{
    using ReportCard.Domain.KeepAliveConn;

    public interface IHubClient
    {
        /// <summary>
        /// 廣撥用
        /// </summary>
        void BroadCastAction<A>(A act)
            where A : ActionBase;
    }
}
