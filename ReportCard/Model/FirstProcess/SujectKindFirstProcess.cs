
namespace ReportCard.Model.FirstProcess
{
    using System;
    using System.Linq;
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

        public override bool Execute()
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
