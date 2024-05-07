using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Publisher.Notifier
{
    public class PublishNotifier
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private HashSet<IPublishEventListener> _publishListener;

        public PublishNotifier()
        {
            _publishListener = new();
        }

        public void Subscribe(IPublishEventListener listener)
        {
            _logger.Info($"'{listener}' registered for chapter upload events");
            _publishListener.Add(listener);
        }

        public void Unsubscribe(IPublishEventListener listener)
        {
            _logger.Info($"'{listener}' unregistered for chapter upload events");
            _publishListener.Remove(listener);
        }

        public async Task NotifyPublish()
        {
            foreach (var listener in _publishListener)
            {
                _logger.Info("publish event occured, notifying " + listener);
                await listener.OnPublish();
            }
        }
    }
}
