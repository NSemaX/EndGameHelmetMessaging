using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac.Extras.Moq;
using Moq;
using System;
using EndGameHelmetMessaging.MessagingService;


namespace EndGameHelmetMessaging.Test
{
    [TestClass]
   public class MessageServiceTest
    {

        [TestMethod]
        public void Should_Return_Successfully_Send_Message()
        {

            var messageRequest = new EndGameHelmetMessaging.MessagingService.MessageItem
            {
                Message = "helloSteve",
                SenderId = "tony_stark_0001",
                ReceiverId = "Stev_Rogers_0005"
            };


            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<EndGameHelmetMessaging.MessagingService.IHelmetMessagingService>()
                    .Setup(srv => srv.Send(
                        It.IsAny<EndGameHelmetMessaging.MessagingService.MessageItem>()
                        ))
                    .Returns<EndGameHelmetMessaging.MessagingService.MessageItem>(p =>
                      "[MOCK] Successfully registered and send message.");

                var sut = mock.Create<EndGameHelmetMessaging.MessagingService.IHelmetMessagingService>();
                Assert.AreEqual("[MOCK] Successfully registered and send message.",
                    sut.Send(messageRequest));
            }
        }
    }
}
