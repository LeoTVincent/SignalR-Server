using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRServer.HubConfig
{
    public class TimeManager
    {
        private Timer _timer;
        private Action _action;
        private AutoResetEvent _autoResetEvent;
        public DateTime TimeStarted { get; set; }
        public TimeManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute,_autoResetEvent,1000,5000);
            TimeStarted = DateTime.Now;
        }

        public void Execute(object stateInfo)
        {
            _action();
            if((DateTime.Now - TimeStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }

    }
}
