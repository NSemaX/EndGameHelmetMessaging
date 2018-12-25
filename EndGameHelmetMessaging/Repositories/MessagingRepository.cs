using EndGameHelmetMessaging.Aggregates;
using EndGameHelmetMessaging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndGameHelmetMessaging.Repositories
{
   public class MessagingRepository: IMessagingRepository
    {
        public List<Message> GeMessageList(DateTime StartDate, DateTime EndDate)
        {
            List<Message> messageList = new List<Message>();
            return messageList;
        }
    }
}
