
namespace ReportCard.Domain.Model.FirstProcess
{
    using System.Collections.Generic;
    using System.Linq;
    using Autofac.Features.Indexed;
    using ReportCard.Domain.Model.SecondProcess;

    /// <summary>
    /// 第一層業務
    /// </summary>
    public enum FistProcessType
    {
        [EnumDisplay("1. 科目類型")]
        SujectKind = 1,
        [EnumDisplay("2. 分數類型")]
        ScoreKind = 2
    }

    public abstract class IFirstProcess
    {
        protected IIndex<SecondProcessType, ISecondProcess> processSets;

        protected IConcoleWrapper console;

        protected SecondProcessType[] legalTypes;

        protected IFirstProcess(IIndex<SecondProcessType, ISecondProcess> processSets, IConcoleWrapper console)
        {
            this.processSets = processSets;
            this.console = console;
        }

        protected IEnumerable<string> legalTypesFormat
        {
            get
                => legalTypes?.Select(t => $"{((int)t)}") ?? new string[] { };
        }

        protected IEnumerable<string> legalTypesDisplay
        {
            get
                => legalTypes?.Select(t => t.ToDisplay()) ?? new string[] { };
        }

        public abstract bool Execute();
    }
}
