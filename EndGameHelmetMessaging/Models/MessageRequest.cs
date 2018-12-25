using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndGameHelmetMessaging
{
    public class MessageRequest
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
    }
}
