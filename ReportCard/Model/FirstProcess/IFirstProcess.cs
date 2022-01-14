
namespace ReportCard.Model.FirstProcess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Autofac.Features.Indexed;
    using ReportCard.Model.SecondProcess;

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

        private IConcoleWrapper console;

        protected SecondProcessType[] legalTypes;

        protected IFirstProcess(IIndex<SecondProcessType, ISecondProcess> processSets, IConcoleWrapper console)
        {
            this.processSets = processSets;
            this.console = console;
        }

        private IEnumerable<string> legalTypesFormat
        {
            get
                => legalTypes?.Select(t => $"{((int)t)}") ?? new string[] { };
        }

        private IEnumerable<string> legalTypesDisplay
        {
            get
                => legalTypes?.Select(t => t.ToDisplay()) ?? new string[] { };
        }

        public bool Execute() 
        {
            try
            {
                string cmd = string.Empty;

                while (cmd.ToLower() != "exit")
                {
                    this.console.Clear();

                    // 處理第二層業務
                    if (legalTypesFormat.Any(p => p == cmd) &&
                        this.processSets.TryGetValue((SecondProcessType)Convert.ToInt32(cmd), out ISecondProcess process) &&
                        !process.Execute())
                    {
                        return false;
                    }

                    this.console.WriteLine(string.Join("\r\n", legalTypesDisplay));

                    cmd = this.console.ReadLine();
                }

                this.console.Clear();
                return true;
            }
            catch (Exception ex)
            {
                this.console.Clear();
                this.console.WriteLine(ex.Message);
                this.console.Read();

                return false;
            }
        }
    }
}
