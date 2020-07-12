using System.IO;
using System.Reflection;

namespace CrossCuttingConcerns.FileSystem
{
    public static class LogFile
    {
        private static string _location = string.Empty;
        private static string _filename = string.Empty;
        private static string _file = string.Empty;

        public static void AppendTextToFile(string filename, string text)
        {
            _location = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)}\\Logs";
            _filename = filename;
            AddDirectory();
            AddFile();
            File.AppendAllText(_file, text);
        }

        private static void AddDirectory()
        {
            if (!Directory.Exists(_location))
                Directory.CreateDirectory("Logs");
        }

        private static void AddFile()
        {
            _file = Path.Combine(_location, _filename);
            if (File.Exists(_file)) return;
            using (File.Create($"Logs\\{_filename}"))
            {

            }
        }
    }
}
