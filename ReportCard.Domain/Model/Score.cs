
namespace ReportCard.Domain.Model
{
    /// <summary>
    /// 分數
    /// </summary>
    public class Score
    {
        /// <summary>
        /// ID
        /// </summary>
        public int f_id { get; set; }

        /// <summary>
        /// 科目索引ID
        /// </summary>
        public int f_sujectId { get; set; }

        /// <summary>
        /// 分數
        /// </summary>
        public int f_point { get; set; }
    }
}
