using Foxter.Controllers.AuthorControllers;
using Foxter.Models;
using Foxter.Models.Base;
using Foxter.Publisher.Notifier;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Publisher
{
    public class PublisherClient
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IPublisherStrategy _publishStrategy;
        private PublishNotifier _publishNotifier;
        private bool _supressNotifications;
        private PublishResult? _lastPublishResults;
        private bool _publishFailed;
        public async Task PublishChapters()
        {
            if(_publishStrategy != null)
            {
                var result = await _publishStrategy.Publish();
                //This means there were no stories to be published
                if (result.success == 0 && result.failed == 0) return;
                if (_supressNotifications == false || result.success >= 1)
                {
                    _logger.Info($"upload operation status= success:{result.success}, failed: {result.failed}\")");
                    MakeToast(result);
                    await _publishNotifier.NotifyPublish();
                }
                bool didErrorCountIncrease = (_lastPublishResults.HasValue && _lastPublishResults.Value.failed < result.failed);
                _supressNotifications = (!didErrorCountIncrease);
                _lastPublishResults = result;
                
                
                
            }
            
        }

        private void MakeToast(PublishResult result)
        {
            if(result.success > 0)
            {
                _logger.Info($"sending toast notification");
                new ToastContentBuilder()
                .AddText($"Chapters published")
                .AddText($"Published {result.success} chapter(s). Errors: {result.failed}")
                .AddAppLogoOverride(new Uri(Path.GetFullPath(@"Images\info.png")))
                .Show();
                _supressNotifications = false;
            }
            else
            {
                if (_supressNotifications) return;
                _logger.Info($"sending error toast notification");
                new ToastContentBuilder()
                .AddText($"Chapters failed to be published")
                .AddText(result.failed > 1 ? $"Failed to publish a total of {result.failed} chapter" : "Failed to publish one chapter")
                .AddAppLogoOverride(new Uri(Path.GetFullPath(@"Images\warning-sign.png")))
                .Show();
                _supressNotifications = true;
            }

        }
        
        public void SetPublishStrategy(IPublisherStrategy publisherStrategy) {
            _publishStrategy = publisherStrategy;
        }

        
        public PublisherClient(PublishNotifier publishNotifier) { 
            _publishStrategy = null;
            _publishNotifier = publishNotifier;
            _supressNotifications = false;
            _publishFailed = false;
        }
    }
}
