
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;

    /// <summary>
    /// 新增Suject
    /// </summary>
    public class AddSujectAction : ActionBase
    {
        public override string Action()
            => "addSuject";

        /// <summary>
        /// Suject 名稱
        /// </summary>
        public string Name { get; set; }
    }
}
