using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lesson05
{
    public class Logger
    {
        private const string fileName = "log.log";

        private readonly int _maxLogItemCount; 
        private int _logItemCount;
        private readonly object _lock = new object();
        private readonly AutoResetEvent waitHandle = new AutoResetEvent(true);

        private Starter _starter = new Starter();

        public Logger(int maxCount)
        {
            _maxLogItemCount = maxCount;
        }

        public event EventHandler<CustomEventArgs> OnLogMax;

        public async Task Log(string message)
        {
            waitHandle.WaitOne();

            await File.AppendAllTextAsync(fileName, $"[{DateTime.Now}] {message}\n");
            Interlocked.Increment(ref _logItemCount);
            if (_logItemCount == _maxLogItemCount)
            {
                EventHandler<CustomEventArgs> eventHandler = OnLogMax;

                if (eventHandler != null)
                {
                    eventHandler(this, new CustomEventArgs(fileName));
                }

                _logItemCount = 0;
            }

            waitHandle.Set();
        }
    }
}
