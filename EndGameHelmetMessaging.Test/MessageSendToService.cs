using EndGameHelmetMessaging.MessagingService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace EndGameHelmetMessaging.Test
{
    [TestClass]
    public class MessageSendToService
    {
        [TestMethod]
        public void Should_We_Successfully_Send_Message()
        {

            string val = "You send: helloSteve";

            var expected = new MessageResponse
            {
                IsSuccess = true,
                ResponseCode = ErrorCodes.success_message
            };

            // mock wcf interface
            Mock<IHelmetMessagingService> wcfMock = new Mock<IHelmetMessagingService>();
            wcfMock.Setup<string>(s => s.Send(It.IsAny<MessageItem>())).Returns(val);

            // create object to register with IoC
            IHelmetMessagingService wcfMockObject = wcfMock.Object;

            // register instance
            //UnityContainer IoC = new UnityContainer();
            // IoC.RegisterInstance<IHelmetMessagingService>(wcfMockObject);
           

            // create ServiceAgent object using parameterized constructor (for unit test)
            MessagingManager serviceAgent = new MessagingManager(true, wcfMockObject);

            var messageRequest = new MessageRequest
            {
                MessageId = 1,
                Message = "helloSteve",
                SenderId = "tony_stark_0001",
                ReceiverId = "steve_rogers_003"
            };

            // method call to be tested
            var actual  = serviceAgent.MessageSendToService(messageRequest);

            // verify if the expected method called during test or not
            wcfMock.Verify(srv => srv.Send(It.IsAny<MessageItem>()), Times.Exactly(1));


            Assert.AreEqual(expected.IsSuccess, actual.IsSuccess);
            Assert.AreEqual(expected.ResponseCode, actual.ResponseCode);


        }
    }
}
