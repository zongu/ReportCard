
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

        protected SecondProcessType[] legalTypes;

        protected IFirstProcess(IIndex<SecondProcessType, ISecondProcess> processSets)
        {
            this.processSets = processSets;
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
                    Console.Clear();

                    // 處理第二層業務
                    if (legalTypesFormat.Any(p => p == cmd) &&
                        this.processSets.TryGetValue((SecondProcessType)Convert.ToInt32(cmd), out ISecondProcess process) &&
                        !process.Execute())
                    {
                        return false;
                    }

                    Console.WriteLine(string.Join("\r\n", legalTypesDisplay));

                    cmd = Console.ReadLine();
                }

                Console.Clear();
                return true;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.Read();

                return false;
            }
        }
    }
}
