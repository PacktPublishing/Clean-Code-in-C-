using System;
using System.IO;

namespace CH06_FailPassRefactor
{
    internal class Logger
    {
        private Text _text;

        public string Log(Exception ex)
        {
            BuildMessage(ex);
            return SaveLog();
        }

        private void BuildMessage(Exception ex)
        {
            _text = new Text();
            _text.BuildExceptionMessage(ex, false);
        }

        private string SaveLog()
        {
            var filename = _text.GetHashedTextFileName("Log", Environment.SpecialFolder.MyDocuments);
            File.WriteAllText(filename, _text.ExceptionMessage);
            return filename;
        }
    }
}
