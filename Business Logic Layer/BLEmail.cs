using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    /// <summary>
    /// This class will for now, only contain one method to send the e-mail.
    /// </summary>
    public class BLEmail
    {
        private BLEmail() { }
        /// <summary>
        /// Sends an e-mail to the RemindMe support e-mail adress
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool SendEmail(string subject,string body)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
            oSmtp.Timeout = 3000; //3 sec timeout
            //The "e-mail address" will contain the user's windows username, so that i can distinguish between people
            oMail.From = "RemindMeUser_" + Environment.UserName + "@gmail.com";

            oMail.To = "remindmehelp@gmail.com";

            // Set email subject
            oMail.Subject = subject;

            // Set email body
            oMail.TextBody = body;

            // Set SMTP server address to "".
            SmtpServer oServer = new SmtpServer("");
            

            try
            {                
                oSmtp.SendMail(oServer, oMail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
