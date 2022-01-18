
namespace ReportCard.Domain.Action
{
    using System.Collections.Generic;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;

    /// <summary>
    /// 回應Suject指令
    /// </summary>
    public class SujectSequenceAction : ActionBase
    {
        public override string Action()
            => "sujectSequence";

        /// <summary>
        /// Suject集合
        /// </summary>
        public IEnumerable<Suject> Sujects { get; set; }
    }
}
