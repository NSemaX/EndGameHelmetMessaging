using EndGameHelmetMessaging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndGameHelmetMessaging.Aggregates
{
    public  interface IMessagingRepository
    {
          List<Message> GeMessageList(DateTime StartDate, DateTime EndDate);
    }
}
