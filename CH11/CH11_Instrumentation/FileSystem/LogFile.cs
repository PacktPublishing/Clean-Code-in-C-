using System.IO;

namespace CH11_Instrumentation.FileSystem
{
    public class LogFile
    {
        private string _location = string.Empty;

        public void AppendTextToFile(string path, string filename, string text)
        { 
            _location = $"{path}\\Logs";
            var logFile = Path.Combine(_location, filename);
            AddDirectory(_location);
            AddFile(_location, filename);
            File.AppendAllText(logFile, text);
        }

        private void AddDirectory(string path)
        {
            if (!Directory.Exists(_location))
                Directory.CreateDirectory("Logs");
        }

        private void AddFile(string path, string filename)
        {
            var file = Path.Combine(path, filename);
            if (!File.Exists(file))
                File.Create($"Logs\\{filename}");
        }
    }
}
