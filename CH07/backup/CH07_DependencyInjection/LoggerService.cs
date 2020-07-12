using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_DependencyInjection
{
    // See: https://www.codeproject.com/Articles/347651/Define-Your-Own-IoC-Container#_articleTop.
    public class LoggerService : ILoggerService
    {
        public void Log(string submittedMsg)
        {
            if (!string.IsNullOrEmpty(submittedMsg))
            {
                Console.WriteLine(string.Format("[{0}] {1}\r\n", DateTime.Now, submittedMsg));
                Console.ReadKey();
            }
        }
    }
}
