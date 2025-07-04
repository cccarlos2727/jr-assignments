using IMoocService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoocService
{
    public class LoggingService: ILoggingService
    {
        public List<string> _logs = new List<string>();
        private readonly Guid _instanceId = Guid.NewGuid();
        public void LogInfo(string message)
        {
            _logs.Add($"INFO: {DateTime.Now}: {message}");
            Console.WriteLine($"INFO: {DateTime.Now}: {message}");
        }
        public void LogWarning(string message)
        {
            _logs.Add($"WARNING: {DateTime.Now}: {message}");
            Console.WriteLine($"INFO: {DateTime.Now}: {message}");
        }
        public void LogError(string message)
        {
            _logs.Add($"ERROR: {DateTime.Now}: {message}");
            Console.WriteLine($"INFO: {DateTime.Now}: {message}");
        }

        public List<string> GetLog() => _logs;        
        public Guid GetInstanceId() => _instanceId;
    }
}
