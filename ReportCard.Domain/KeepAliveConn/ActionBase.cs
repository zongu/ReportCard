
namespace ReportCard.Domain.KeepAliveConn
{
    using Newtonsoft.Json;

    /// <summary>
    /// Action基礎類別
    /// </summary>
    public abstract class ActionBase
    {
        /// <summary>
        /// 指令字串
        /// </summary>
        public abstract string Action();

        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}
