using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMoocService
{
    public interface ILoggingService
    {
        public void LogInfo(string message);
        public void LogWarning(string message);
        public void LogError(string message);
        public List<string> GetLog();
    }
}
