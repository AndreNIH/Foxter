using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Publisher.Notifier
{
    internal class TestErrorPublish : IPublisherStrategy
    {
        public async Task<PublishResult> Publish()
        {
            var r =  new PublishResult();
            r.failed = 0;
            r.success = 22;
            return r;
        }
    }
}
