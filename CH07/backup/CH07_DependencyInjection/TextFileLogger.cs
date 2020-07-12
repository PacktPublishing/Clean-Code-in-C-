using System;
using System.IO;
using static System.Environment;

namespace CH07_DependencyInjection
{
    public class TextFileLogger : ILoggerService
    {
        public void Log(string message)
        {
            var filename = GetHashedTextFileName("Log", Environment.SpecialFolder.MyDocuments);
            File.WriteAllText(filename, message);
        }

        private string GetHashedTextFileName(string name, SpecialFolder folder)
        {
            var fileName = $"{name}-{DateTime.UtcNow.GetHashCode()}.txt";
            var dir = Environment.GetFolderPath(folder);
            return $"{dir}\\{fileName}";
        }
    }
}
