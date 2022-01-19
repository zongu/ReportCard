﻿
namespace ReportCard.Signalr.Client.ActionHandler
{
    using System;
    using Newtonsoft.Json;
    using ReportCard.Domain.Action;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Domain.Model;
    using ReportCard.Signalr.Client.Model;

    public class ScoreActionHandler : IActionHandler
    {
        private IConcoleWrapper console;

        public ScoreActionHandler(IConcoleWrapper console)
        {
            this.console = console;
        }

        public bool Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ScoreAction>(actionModule.Message);

                this.console.Write($"操作成功:{JsonConvert.SerializeObject(action.Score)}");

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
