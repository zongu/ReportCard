
namespace ReportCard.Signalr.Server.ActionHandler
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Repository;
    using ReportCard.Signalr.Server.Model;

    /// <summary>
    /// 新增Suject指令解析
    /// </summary>
    public class AddSujectActionHandler : IActionHandler
    {
        private ISujectRepository repo;

        public AddSujectActionHandler(ISujectRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<AddSujectAction>(action.Message);
                var addResult = this.repo.Add(content.Name);

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                var result = new SujectAction()
                {
                    Suject = addResult.suject
                };

                return (null, result);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
