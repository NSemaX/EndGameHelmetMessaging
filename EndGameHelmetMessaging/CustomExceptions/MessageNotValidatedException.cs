using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndGameHelmetMessaging.CustomExceptions
{
    [Serializable]
    class MessageNotValidatedException : Exception
    {
        public MessageNotValidatedException()
        {

        }

        public MessageNotValidatedException(string errortext)
        : base(String.Format("Invalid message : {0}", errortext))
        {

        }

    }
}
