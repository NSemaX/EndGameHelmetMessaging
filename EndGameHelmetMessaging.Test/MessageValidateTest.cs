using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EndGameHelmetMessaging.Test
{
    [TestClass]
    public class MessageValidateTest
    {
        [TestMethod]
        public void SendMessage_With_Null_MessageText_Then_Send_Failed_Test()
        {
            var expected = new MessageResponse
            {
                IsSuccess = false,
                ResponseCode = ErrorCodes.error_Message_empty
            };

            var message_manager = new MessagingManager();

            var messageRequest = new MessageRequest
            {
                MessageId = 1,
                Message = "",
                SenderId = "tony_stark_0001",
                ReceiverId = "Steve_Rogers_0005"
            };

            var actual = message_manager.MessageValidation(messageRequest);

            Assert.AreEqual(expected.IsSuccess, actual.IsSuccess);
            Assert.AreEqual(expected.ResponseCode, actual.ResponseCode);
        }

        [TestMethod]
        public void SendMessage_With_Null_SenderOrReceiverId_Then_Send_Failed_Test()
        {
            var expected = new MessageResponse
            {
                IsSuccess = false,
                ResponseCode = ErrorCodes.error_SenderId_ReceiverId_required
            };

            var message_manager = new MessagingManager();

            var messageRequest = new MessageRequest
            {
                MessageId = 1,
                Message = "helloSteve",
                SenderId = "tony_stark_0001",
                ReceiverId = ""
            };

            var actual = message_manager.MessageValidation(messageRequest);

            Assert.AreEqual(expected.IsSuccess, actual.IsSuccess);
            Assert.AreEqual(expected.ResponseCode, actual.ResponseCode);
        }



        [TestMethod]
        public void SendMessage_With_Incorrect_MessageText_Then_Send_Failed_Test()
        {
            var expected = new MessageResponse
            {
                IsSuccess = false,
                ResponseCode = ErrorCodes.error_invalid_message_content
            };

            var message_manager = new MessagingManager();

            var messageRequest = new MessageRequest
            {
                MessageId = 1,
                Message = "hello002Steve",
                SenderId = "tony_stark_0001",
                ReceiverId = "Stev_Rogers_0005"
            };

            var actual = message_manager.MessageValidation(messageRequest);

            Assert.AreEqual(expected.IsSuccess, actual.IsSuccess);
            Assert.AreEqual(expected.ResponseCode, actual.ResponseCode);
        }


        //All Pramters Are Ok Test

        [TestMethod]
        public void SendMessage_With_Correct_Request_Parameter_Then_Send_OK_Test()
        {
            var expected = new MessageResponse
            {
                IsSuccess = true,
                ResponseCode = ErrorCodes.success_message
            };



            var message_manager = new MessagingManager();

            var messageRequest = new MessageRequest
            {
                MessageId = 1,
                Message = "helloSteve",
                SenderId = "tony_stark_0001",
                ReceiverId = "Steve_Rogers_0005"
            };

            var actual = message_manager.MessageValidation(messageRequest);

  

            Assert.AreEqual(expected.IsSuccess, actual.IsSuccess);
            Assert.AreEqual(expected.ResponseCode, actual.ResponseCode);
        }





    }
}
