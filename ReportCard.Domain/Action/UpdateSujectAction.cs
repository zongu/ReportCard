
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;

    /// <summary>
    /// 更新Suject指令
    /// </summary>
    public class UpdateSujectAction : ActionBase
    {
        public override string Action()
            => "updateSuject";

        /// <summary>
        /// Suject Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Suject 名稱
        /// </summary>
        public string Name { get; set; }
    }
}
