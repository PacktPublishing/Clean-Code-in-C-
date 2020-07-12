using System;

namespace CH3.DependencyInjection
{
    /// <summary>
    /// Logs messages to a text file.
    /// </summary>
    public class TextFileLogger : ILogger
    {
        /// <summary>
        /// Outputs the message to a text file.
        /// </summary>
        /// <param name="message">
        /// The message to be written to the text file.
        /// </param>
        public void OutputMessage(string message)
        {
            System.IO.File.WriteAllText(FileName(), message);
        }

        private string FileName()
        {
            var timestamp = DateTime.Now.ToFileTimeUtc().ToString();
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return $"{path}_{timestamp}";
        }
    }
}
