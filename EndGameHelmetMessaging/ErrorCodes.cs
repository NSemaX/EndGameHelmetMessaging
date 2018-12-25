using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndGameHelmetMessaging
{
   public static class ErrorCodes
    {
        public static string error_An_error_occured
        {
            get
            {
                return "10400";
            }
        }

        public static string error_Message_not_validated
        {
            get
            {
                return "10300";
            }
        }

        public static string error_Message_empty
        {
            get
            {
                return "10301";
            }
        }


        public static string error_SenderId_ReceiverId_required
        {
            get
            {
                return "10302";
            }
        }

        public static string error_invalid_message_content
        {
            get
            {
                return "10303";
            }
        }

        public static string success_message
        {
            get
            {
                return "00000";
            }
        }
    }
}
