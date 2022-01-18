
namespace ReportCard.Domain.Action
{
    using ReportCard.Domain.KeepAliveConn;

    /// <summary>
    /// 新增Score指令
    /// </summary>
    public class AddScoreAction : ActionBase
    {
        public override string Action()
            => "addScore";

        /// <summary>
        /// 科目ID
        /// </summary>
        public int SujectId { get; set; }

        /// <summary>
        /// 分數
        /// </summary>
        public int Point { get; set; }
    }
}
