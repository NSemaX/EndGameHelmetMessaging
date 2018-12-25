using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndGameHelmetMessaging.Aggregates
{
    public  interface IMessagingValidator
   {
         MessageValidateResult MessageValidation(MessageRequest request);
    }
}
