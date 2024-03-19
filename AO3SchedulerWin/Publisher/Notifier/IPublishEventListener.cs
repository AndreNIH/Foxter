using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Publisher.Notifier
{
    public interface IPublishEventListener
    {
        public Task OnPublish();
    }
}
