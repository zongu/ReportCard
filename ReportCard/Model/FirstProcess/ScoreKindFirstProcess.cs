
namespace ReportCard.Model.FirstProcess
{
    using Autofac.Features.Indexed;
    using ReportCard.Model.SecondProcess;

    /// <summary>
    /// 分數類型業務
    /// </summary>
    public class ScoreKindFirstProcess : IFirstProcess
    {
        public ScoreKindFirstProcess(IIndex<SecondProcessType, ISecondProcess> processSets) 
            : base(processSets)
        {
            this.legalTypes = new SecondProcessType[]
            {
                SecondProcessType.ScoreAdd,
                SecondProcessType.ScoreDelete,
                SecondProcessType.ScoreQuery,
            };
        }
    }
}
