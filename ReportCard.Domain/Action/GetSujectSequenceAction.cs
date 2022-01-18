
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;

    /// <summary>
    /// 取Suject指令
    /// </summary>
    public class GetSujectSequenceAction : ActionBase
    {
        public override string Action()
            => "getSujectSequence";
    }
}
