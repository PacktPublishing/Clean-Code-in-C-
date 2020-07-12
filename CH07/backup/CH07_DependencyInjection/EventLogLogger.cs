using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH07_DependencyInjection
{
    public class EventLogLogger : ILoggerService
    {
        public void Log(string message)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message, EventLogEntryType.Information, 101, 1);
            }
        }

        public void Log(string message, EventLogEntryType eventLogEntryType, int eventId, short category)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message, eventLogEntryType, eventId, category);
            }
        }
    }
}
