
namespace ReportCard.Model.FirstProcess
{
    using Autofac.Features.Indexed;
    using ReportCard.Model.SecondProcess;

    /// <summary>
    /// 科目類型業務
    /// </summary>
    public class SujectKindFirstProcess : IFirstProcess
    {
        public SujectKindFirstProcess(IIndex<SecondProcessType, ISecondProcess> processSets) 
            : base(processSets)
        {
            this.legalTypes = new SecondProcessType[]
            {
                SecondProcessType.SujectAdd,
                SecondProcessType.SujectDelete,
                SecondProcessType.SujectQuery,
                SecondProcessType.SujectUpdate
            };
        }
    }
}
