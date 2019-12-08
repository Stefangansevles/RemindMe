using QiHe.CodeLib.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Business_Logic_Layer
{
    /// <summary>
    /// This class will for now, only contain one method to send the e-mail.
    /// </summary>
    public class BLEmail
    {       
        private BLEmail() {}       

        /// <summary>
        /// Sends an e-mail to the RemindMe support e-mail address
        /// </summary>
        /// <param name="subject">Subject of the e-mail</param>
        /// <param name="message">Message of the e-mail</param>
        /// <param name="email">The e-mail address of the user. Can be empty</param>
        /// <param name="includeLog">Include the system log or not</param>
        /// <returns></returns>
        public static Exception SendEmail(string subject, string message, string email = "", bool includeLog = true)
        {
            try
            {
                BLIO.Log("Attempting to send an e-mail...");
                MailMessage mes = new MailMessage();
                mes.From = new MailAddress("remindmesmtp@hotmail.com");
                if (string.IsNullOrWhiteSpace(mes.From.ToString())) { BLIO.WriteError(new Exception(),"[DEBUG] .From empty?" + mes.From.ToString()); } else BLIO.WriteError(new Exception(), "[DEBUG] mes.From not empty! : " +mes.From.ToString());
                mes.To.Add("remindmesmtp@gmail.com");
                mes.Subject = subject;
                mes.IsBodyHtml = false;
                mes.Body = "RemindMe Version " + IOVariables.RemindMeVersion + "\r\n" + message;

                if (!string.IsNullOrWhiteSpace(email))
                {
                    //If the user left his e-mail
                    mes.Body += "\r\nUser's e-mail: " + email;
                }
                BLIO.Log("MailMessage created");

                // Create the file attachment for this e-mail message.
                if (includeLog)
                {
                    BLIO.Log("Include log = true. Creating attachment....");
                    string path = BLIO.GetLogTxtPath();
                    Attachment data = new Attachment(path, MediaTypeNames.Application.Octet);

                    // Add time stamp information for the file.
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(path);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(path);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(path);

                    // Add the file attachment to this e-mail message.
                    mes.Attachments.Add(data);
                    BLIO.Log("Attachment created and added to the MailMessage");
                }

                SmtpClient client = new SmtpClient("smtp.live.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("remindmesmtp@hotmail.com", "This is used for e-mails :)"),
                    EnableSsl = true
                };
                BLIO.Log("SmtpClient created. Sending mail...");
                client.Send(mes);
            }
            catch(Exception ex)
            {
                BLIO.Log("Exception during SendEmail!");
                BLIO.WriteError(ex, "Exception during SendEmail!");
                return ex;
            }            
            return null;
        }
    }
}
