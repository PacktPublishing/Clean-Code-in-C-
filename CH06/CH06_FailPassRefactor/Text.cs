using System;
using System.Text;
using static System.Environment;

namespace CH06_FailPassRefactor
{
    public class Text
    {
        private readonly StringBuilder _stringBuilder;
        public string ExceptionMessage => _stringBuilder.ToString();

        public Text()
        {
            _stringBuilder = new StringBuilder();
        }

        public void BuildExceptionMessage(Exception ex, bool isInnerException)
        {
            if (isInnerException)
            {
                _stringBuilder.Append("Inner Exception: ").AppendLine(ex.Message);
            }
            else
            {
                _stringBuilder.AppendLine("--------------------------------------------------------------------------------");
                _stringBuilder.Append("Exception: ").AppendLine(ex.Message);
            }
            if (ex.InnerException != null)
            {
                BuildExceptionMessage(ex.InnerException, true);
            }
            else
            {
                _stringBuilder.AppendLine("--------------------------------------------------------------------------------");
            }
        }

        public string GetHashedTextFileName(string name, SpecialFolder folder)
        {
            var fileName = $"{name}-{DateTime.UtcNow.GetHashCode()}.txt";
            var dir = Environment.GetFolderPath(folder);
            return $"{dir}\\{fileName}";
        }
    }
}
