
namespace ReportCard.Domain.Action
{
    using System.Collections.Generic;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;

    /// <summary>
    /// Score指令
    /// </summary>
    public class ScoreAction : ActionBase
    {
        public override string Action()
            => "score";

        /// <summary>
        /// Score 集合
        /// </summary>
        public IEnumerable<Score> Scores { get; set; }
    }
}
