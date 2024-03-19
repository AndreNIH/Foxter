using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.Base;
using AO3SchedulerWin.Publisher.Notifier;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Publisher
{
    public class PublisherClient
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IPublisherStrategy _publishStrategy;
        private PublishNotifier _publishNotifier;
        private bool _supressError;
        
        public async Task PublishChapters()
        {
            var result = await _publishStrategy.Publish();
            //This means there were no stories to be published
            if (result.success == 0 && result.failed == 0) return; 
            if (result.success > 0) await _publishNotifier.NotifyPublish();
            MakeToast(result);
        }

        private void MakeToast(PublishResult result)
        {
            if(result.success > 0)
            {
                new ToastContentBuilder()
                .AddText($"Chapters published")
                .AddText($"Published {result.success} chapter(s). Errors: {result.failed}")
                .AddAppLogoOverride(new Uri(Path.GetFullPath(@"Images\info.png")))
                .Show();
                _supressError = false;
            }
            else
            {
                if (_supressError) return;
                new ToastContentBuilder()
                .AddText($"Chapters failed to be published")
                .AddText($"Failed to publish a total of {result.failed} chapter(s)")
                .AddAppLogoOverride(new Uri(Path.GetFullPath(@"Images\warning-sign.png")))
                .Show();
                _supressError = true;
            }

        }
        
        public PublisherClient(IPublisherStrategy publisherStrategy, PublishNotifier publishNotifier) { 
            _publishStrategy = publisherStrategy;
            _publishNotifier = publishNotifier;
            _supressError = false;
        }
    }
}
