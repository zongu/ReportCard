
namespace ReportCard.Model
{
    using System;

    /// <summary>
    /// console 包
    /// </summary>
    public class ConcoleWrapper : IConcoleWrapper
    {
        /// <summary>
        /// console clear
        /// </summary>
        public void Clear()
            => Console.Clear();

        /// <summary>
        /// console read
        /// </summary>
        /// <returns></returns>
        public int Read()
            => Console.Read();

        /// <summary>
        /// console readLine
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
            => Console.ReadLine();

        /// <summary>
        /// console write
        /// </summary>
        /// <param name="str"></param>
        public void Write(string str)
            => Console.Write(str);

        /// <summary>
        /// console writeLine
        /// </summary>
        /// <param name="str"></param>
        public void WriteLine(string str)
            => Console.WriteLine(str);
    }
}
