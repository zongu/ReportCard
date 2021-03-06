
namespace ReportCard.Model.FirstProcess
{
    using Autofac.Features.Indexed;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.FirstProcess;
    using ReportCard.Domain.Model.SecondProcess;

    /// <summary>
    /// 分數類型業務
    /// </summary>
    public class ScoreKindFirstProcess : IFirstProcess
    {
        public ScoreKindFirstProcess(IIndex<SecondProcessType, ISecondProcess> processSets, IConcoleWrapper console) 
            : base(processSets, console)
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
