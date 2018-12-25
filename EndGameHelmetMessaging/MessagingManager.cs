using EndGameHelmetMessaging;
using EndGameHelmetMessaging.Aggregates;
using EndGameHelmetMessaging.Repositories;
using EndGameHelmetMessaging.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MessagingManager
{
    public IMessagingValidator MessagingValidator { get; private set; }
    public IMessagingRepository MessagingRepository { get; private set; }

    //public MessagingManager(IMessagingValidator messagingValidator, IMessagingRepository messagingRepository)
    //{
    //    this.MessagingValidator = messagingValidator;
    //    this.MessagingRepository = messagingRepository;

    //}

    public MessagingManager()
    {
        this.MessagingValidator = new MessagingValidator();
        this.MessagingRepository = new MessagingRepository();

    }

    public MessageValidateResult MessageValidation(MessageRequest request)
    {
        return this.MessagingValidator.MessageValidation(request);
    }

    public MessageResponse MessageSendToService(MessageRequest request)
    {
        MessageResponse response = new MessageResponse();
        string returnString;

        //TODO 
        EndGameHelmetMessaging.MessagingService.MessageItem message_item;

        message_item = new EndGameHelmetMessaging.MessagingService.MessageItem
        {
            Message = request.Message,
            SenderId = request.SenderId,
            ReceiverId = request.ReceiverId
        };


        EndGameHelmetMessaging.MessagingService.HelmetMessagingServiceClient service = new EndGameHelmetMessaging.MessagingService.HelmetMessagingServiceClient();
        returnString = service.Send(message_item);

        if (returnString == string.Format("You send: {0}", message_item.Message))
        {
            response.IsSuccess = true;
            response.ResponseCode = ErrorCodes.success_message;
        }

        //response.ResponseCode = "Message was sent successfully.";
        //response.ResponseCode = returnString;

        return response;
    }
}

