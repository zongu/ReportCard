
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;

    /// <summary>
    /// 會應Score結果
    /// </summary>
    public class ScoreAction : ActionBase
    {
        public override string Action()
            => "score";

        /// <summary>
        /// Score
        /// </summary>
        public Score Score { get; set; }
    }
}
