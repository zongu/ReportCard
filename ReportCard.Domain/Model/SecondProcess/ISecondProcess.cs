
namespace ReportCard.Domain.Model.SecondProcess
{
    /// <summary>
    /// 第二層業務
    /// </summary>
    public enum SecondProcessType
    {
        [EnumDisplay("1. 新增科目")]
        SujectAdd = 1,
        [EnumDisplay("2. 移除科目")]
        SujectDelete = 2,
        [EnumDisplay("3. 查詢科目")]
        SujectQuery = 3,
        [EnumDisplay("4. 更新科目")]
        SujectUpdate = 4,
        [EnumDisplay("5. 新增分數")]
        ScoreAdd = 5,
        [EnumDisplay("6. 移除分數")]
        ScoreDelete = 6,
        [EnumDisplay("7. 查詢分數")]
        ScoreQuery = 7
    }

    public interface ISecondProcess
    {
        bool Execute();
    }
}
