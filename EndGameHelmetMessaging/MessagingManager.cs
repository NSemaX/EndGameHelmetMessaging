using EndGameHelmetMessaging;
using EndGameHelmetMessaging.Aggregates;
using EndGameHelmetMessaging.MessagingService;
using EndGameHelmetMessaging.Repositories;
using EndGameHelmetMessaging.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

public class MessagingManager
{
    public IMessagingValidator MessagingValidator { get; private set; }
    public IMessagingRepository MessagingRepository { get; private set; }

    IHelmetMessagingService service;


    public MessagingManager()
    {
        this.MessagingValidator = new MessagingValidator();
        this.MessagingRepository = new MessagingRepository();
        this.service = new HelmetMessagingServiceClient();

    }

    // constructor for unit test
    public MessagingManager(bool isUnitTest, IHelmetMessagingService wcfMockObject)
    {
        UnityContainer IoC = new UnityContainer();

        IoC.RegisterInstance<IHelmetMessagingService>(wcfMockObject);
        this.service = IoC.Resolve<IHelmetMessagingService>();

    }

    public MessageValidateResult MessageValidation(MessageRequest request)
    {
        return this.MessagingValidator.MessageValidation(request);
    }

    public MessageResponse MessageSendToService(MessageRequest request)
    {
        MessageResponse response = new MessageResponse();
        string returnString;


        MessageItem message_item;

        message_item = new MessageItem
        {
            Message = request.Message,
            SenderId = request.SenderId,
            ReceiverId = request.ReceiverId
        };


       // EndGameHelmetMessaging.MessagingService.HelmetMessagingServiceClient service = new EndGameHelmetMessaging.MessagingService.HelmetMessagingServiceClient();
        returnString = service.Send(message_item);

        if (returnString == string.Format("You send: {0}", message_item.Message))
        {
            response.IsSuccess = true;
            response.ResponseCode = ErrorCodes.success_message;
        }


        return response;
    }
}

