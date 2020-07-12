using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH4
{
    public struct TextFileData
    {
        public string FileName { get; private set; }
        public string Text { get; private set; }
        public MimeType MimeType { get; }
        public TextFileData(string filename, string text)
        {
            Text = text;
            MimeType = MimeType.TextPlain;
            FileName = $"{filename}-{GetFileTimestamp()}";
        }
        public void SaveTextFile()
        {
            File.WriteAllText(FileName, Text);
        }

        private static string GetFileTimestamp()
        {
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Day;
            var hour = DateTime.Now.Hour;
            var minutes = DateTime.Now.Minute;
            var seconds = DateTime.Now.Second;
            var milliseconds = DateTime.Now.Millisecond;
            return $"{year}{month}{day}@{hour}{minutes}{seconds}{milliseconds}";
        }
    }
}
