using EndGameHelmetMessaging.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndGameHelmetMessaging
{
    class Program
    {
        static void Main(string[] args)
        {

            MessagingManager manager = new MessagingManager();
            MessageRequest message_request = new MessageRequest();

            string content = Console.ReadLine();

            message_request = new MessageRequest
            {
                MessageId = 1,
                Message = content,
                SenderId = "tony_stark_0001",
                ReceiverId = "pepper_pots_004"
            };

            MessageResponse message_response = new MessageResponse();

            if(manager.MessageValidation(message_request).IsSuccess)
            {
                message_response = manager.MessageSendToService(message_request);
            }
       
            Console.WriteLine(message_response.ResponseCode);
            Console.ReadLine();
        }
    }
}
