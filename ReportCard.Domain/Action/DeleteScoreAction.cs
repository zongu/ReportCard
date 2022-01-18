
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;

    /// <summary>
    /// 移除Score指令
    /// </summary>
    public class DeleteScoreAction : ActionBase
    {
        public override string Action()
            => "deleteScore";

        /// <summary>
        /// Score Id
        /// </summary>
        public int Id { get; set; }
    }
}
