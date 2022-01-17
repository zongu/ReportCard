
namespace ReportCard.Domain.Model
{
    /// <summary>
    /// console 包
    /// </summary>
    public interface IConcoleWrapper
    {
        /// <summary>
        /// console clear
        /// </summary>
        void Clear();

        /// <summary>
        /// console read
        /// </summary>
        /// <returns></returns>
        int Read();

        /// <summary>
        /// console readLine
        /// </summary>
        /// <returns></returns>
        string ReadLine();

        /// <summary>
        /// console write
        /// </summary>
        /// <param name="str"></param>
        void Write(string str);

        /// <summary>
        /// console writeLine
        /// </summary>
        /// <param name="str"></param>
        void WriteLine(string str);
    }
}
