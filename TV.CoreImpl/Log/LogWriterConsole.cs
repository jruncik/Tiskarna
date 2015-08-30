using System;
using TV.Core.Log;

namespace TV.CoreImpl.Log
{
    internal class LogWriterConsole : ILogWriter
    {
        public void WriteMessage(string logMessage)
        {
            Console.WriteLine(logMessage);
        }
    }
}