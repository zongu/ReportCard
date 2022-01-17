
namespace ReportCard.Api.Client.Model.FirstProcess
{
    using Autofac.Features.Indexed;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.FirstProcess;
    using ReportCard.Domain.Model.SecondProcess;

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
