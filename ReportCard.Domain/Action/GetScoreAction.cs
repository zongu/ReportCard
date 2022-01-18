
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;

    /// <summary>
    /// 取得Score指令
    /// </summary>
    public class GetScoreAction : ActionBase
    {
        public override string Action()
            => "getScore";

        /// <summary>
        /// 科目ID
        /// </summary>
        public int? SujectId { get; set; }
    }
}
