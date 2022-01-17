﻿
namespace ReportCard.Model.FirstProcess
{
    using Autofac.Features.Indexed;
    using ReportCard.Domain.Model;
    using ReportCard.Domain.Model.FirstProcess;
    using ReportCard.Domain.Model.SecondProcess;

    /// <summary>
    /// 科目類型業務
    /// </summary>
    public class SujectKindFirstProcess : IFirstProcess
    {
        public SujectKindFirstProcess(IIndex<SecondProcessType, ISecondProcess> processSets, IConcoleWrapper console) 
            : base(processSets, console)
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
