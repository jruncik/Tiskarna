using System.Diagnostics;
using TV.Core.Log;

namespace TV.CoreImpl.Log
{
    internal class LogWriterDebug : ILogWriter
    {
        public void WriteMessage(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}