
namespace ReportCard.Domain.KeepAliveConn
{
    using Newtonsoft.Json;

    /// <summary>
    /// 長連接模組
    /// </summary>
    public class ActionModule
    {
        /// <summary>
        /// 指令
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 指令內容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 物件轉Json結構字串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => JsonConvert.SerializeObject(this);

        /// <summary>
        /// 轉強型別
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ActionModule FromString(string message)
            => JsonConvert.DeserializeObject<ActionModule>(message);
    }
}
