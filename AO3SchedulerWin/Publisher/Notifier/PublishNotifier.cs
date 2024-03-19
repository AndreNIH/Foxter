using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Publisher.Notifier
{
    public class PublishNotifier
    {
        private HashSet<IPublishEventListener> _publishListener;

        PublishNotifier()
        {
            _publishListener = new();
        }

        public void Subscribe(IPublishEventListener listener)
        {
            _publishListener.Add(listener);
        }

        public void Unsubscribe(IPublishEventListener listener)
        {
            _publishListener.Remove(listener);
        }

        public async Task NotifyPublish()
        {
            foreach(var listener in _publishListener)
            {
                await listener.OnPublish();
            }
        }
    }
}
