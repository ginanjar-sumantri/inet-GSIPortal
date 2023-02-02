using System;
using System.Data;
using System.Diagnostics;

namespace GSI.Common
{
    public class ErrorHandler
    {
        private static String _errorMsg;
        public static String ErrorMessage
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }

        public static String ErrorEventLog(String _prmError)
        {
            string eventLog = "Application";
            string eventSource = ".NET Runtime";

            if (!System.Diagnostics.EventLog.SourceExists(".NET Runtime"))
            {
                System.Diagnostics.EventLog.CreateEventSource(".NET Runtime", "Application");
            }

            // Create an EventLog instance and assign its source.
            EventLog myLog = new EventLog(eventLog);
            myLog.Source = eventSource;

            // Write the error entry to the event log.    
            myLog.WriteEntry("An error occurred in the Web application "
              + eventSource + "\r\n\r\n" + _prmError,
                EventLogEntryType.Error);

            return _prmError;
        }
    }
}
