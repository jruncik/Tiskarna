using TV.Core.Log;

namespace TV.CoreImpl.Tests
{
    public class LogWriterTest : ILogWriter
    {
        public void WriteMessage(string logMessage)
        {
            IsMessageLogged = true;
        }

        public bool IsMessageLogged
        {
            get; set;
        }
    }
}