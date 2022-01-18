
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;

    /// <summary>
    /// 移除Suject指令
    /// </summary>
    public class DeleteSujectAction : ActionBase
    {
        public override string Action()
            => "deleteSuject";

        /// <summary>
        /// Suject Id
        /// </summary>
        public int Id { get; set; }
    }
}
