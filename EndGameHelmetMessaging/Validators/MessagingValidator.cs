using EndGameHelmetMessaging.Aggregates;
using System;
using System.Text.RegularExpressions;


namespace EndGameHelmetMessaging.Validators
{
   public class MessagingValidator: IMessagingValidator
    {
       
        public MessageValidateResult MessageValidation(MessageRequest request)
        {
            MessageValidateResult response = new MessageValidateResult();

            response.IsSuccess = true;
            response.ResponseCode = ErrorCodes.success_message;

            if (String.IsNullOrEmpty(request.Message))
            {
                response.IsSuccess = false;
                response.ResponseCode = ErrorCodes.error_Message_empty;

            }

            if (string.IsNullOrEmpty(request.SenderId) || string.IsNullOrEmpty(request.ReceiverId))
            {
                response.IsSuccess = false;
                response.ResponseCode = ErrorCodes.error_SenderId_ReceiverId_required;

            }

            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!String.IsNullOrEmpty(request.Message))
                if (!regex.IsMatch(request.Message))
                {
                    response.IsSuccess = false;
                    response.ResponseCode = ErrorCodes.error_invalid_message_content;

                }
                


            return response;
        }

    }
}
