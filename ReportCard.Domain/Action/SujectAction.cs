
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;

    /// <summary>
    /// 回應Suject指令
    /// </summary>
    public class SujectAction : ActionBase
    {
        public override string Action()
            => "suject";

        /// <summary>
        /// Suject
        /// </summary>
        public Suject Suject { get; set; }
    }
}
