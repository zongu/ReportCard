
namespace ReportCard.Signalr.Server.Hubs
{
    using System;
    using System.Threading.Tasks;
    using Autofac;
    using Autofac.Features.Indexed;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    using NLog;
    using ReportCard.Domain.KeepAliveConn;
    using ReportCard.Signalr.Server.Applibs;
    using ReportCard.Signalr.Server.Model;

    [HubName("ReportCardHub")]
    public class ReportCardHub : Hub
    {
        /// <summary>
        /// logger
        /// </summary>
        private static ILogger logger = LogManager.GetLogger("ReportCard.Signalr.Server");

        /// <summary>
        /// 連線時觸發
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            logger.Info($"{this.Context.ConnectionId} Connected");
            return base.OnConnected();
        }

        /// <summary>
        /// 段線時觸發
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            logger.Info($"{this.Context.ConnectionId} Disconnected");
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 斷線重連時觸發
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            logger.Info($"{this.Context.ConnectionId} Reconnected");
            return base.OnReconnected();
        }

        /// <summary>
        /// 接收RS請求
        /// </summary>
        /// <param name="bytes"></param>
        public void SendAction(string str)
        {
            try
            {
                var action = ActionModule.FromString(str);

                logger.Info($"{this.GetType().Name} SendAction Receipt:{str}");

                using (var scope = AutofacConfig.Container.BeginLifetimeScope())
                {
                    var handlerSets = scope.Resolve<IIndex<string, IActionHandler>>();

                    if (handlerSets.TryGetValue(action.Action.ToLower(), out var actionHandler))
                    {
                        var excuteResult = actionHandler.ExecuteAction(action);

                        if (excuteResult.exception != null)
                        {
                            throw excuteResult.exception;
                        }

                        this.Clients.All.BroadCastAction(new ActionModule()
                        {
                            Action = excuteResult.actionBase.Action(),
                            Message = excuteResult.actionBase.ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"{this.GetType().Name} ExecuteAction Exception");
            }
        }
    }
}
