using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HelmetMessagingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHelmetMessagingService" in both code and config file together.
    [ServiceContract]
    public interface IHelmetMessagingService
    {
            [OperationContract]
            string Send(MessageItem message);

    }

    [DataContract]
    public class MessageItem
    {

        string stringMessage = "";
        string stringSenderId = "";
        string stringReceiverId = "";


        [DataMember]
        public string Message
        {
            get { return stringMessage; }
            set { stringMessage = value; }
        }

        [DataMember]
        public string SenderId
        {
            get { return stringSenderId; }
            set { stringSenderId = value; }
        }

        [DataMember]
        public string ReceiverId
        {
            get { return stringReceiverId; }
            set { stringReceiverId = value; }
        }
    }



}
