using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelmetMessagingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HelmetMessagingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select HelmetMessagingService.svc or HelmetMessagingService.svc.cs at the Solution Explorer and start debugging.
    public class HelmetMessagingService : IHelmetMessagingService
    {
        public string Send(MessageItem message)
        {
            return string.Format("You send: {0}", message.Message);
        }
    }
}
