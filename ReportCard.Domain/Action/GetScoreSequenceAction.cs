
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;

    /// <summary>
    /// 取得Score指令
    /// </summary>
    public class GetScoreSequenceAction : ActionBase
    {
        public override string Action()
            => "getScoreSequence";

        /// <summary>
        /// 科目ID
        /// </summary>
        public int? SujectId { get; set; }
    }
}
