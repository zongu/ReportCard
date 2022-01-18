
namespace ReportCard.Domain.Action
{
    using System.Collections.Generic;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;

    /// <summary>
    /// Score指令
    /// </summary>
    public class ScoreSequenceAction : ActionBase
    {
        public override string Action()
            => "scoreSequence";

        /// <summary>
        /// Score 集合
        /// </summary>
        public IEnumerable<Score> Scores { get; set; }
    }
}
