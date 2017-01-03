using Prism.Logging;
using System;
using System.Reactive.Subjects;

namespace PrismShell
{
    public delegate void LoggerCallback(string message, Category category, Priority priority);
    
    class PrismLogMessage
    {
        public string Message { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
    }

    public class PrismHackingLogger : ILoggerFacade
    {
        private LoggerCallback _callback;
        private readonly ReplaySubject<PrismLogMessage> _queue = new ReplaySubject<PrismLogMessage>();

        public LoggerCallback Callback
        {
            get { return _callback; }
            set { _callback = value; }
        }

        public void Log(string message, Category category, Priority priority)
        {
            if (_callback == null)
            {
                _queue.OnNext(new PrismLogMessage { Message = message, Category = category, Priority = priority });
            }
            else
            {
                _callback(message, category, priority);
            }
        }

        public void ReplayLogs()
        {
            if (_callback == null) { return; }
            using (var subscription = _queue.Subscribe(v => _callback(v.Message, v.Category, v.Priority)))
            {

            }
        }
    }
}
