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
        private static List<string> smtpServers = new List<string>();

        private BLEmail() {}

        /// <summary>
        /// Default SMTP Port.
        /// </summary>
        private static int SmtpPort = 25;





        public static Exception SendEmail(string subject, string message, string email = "", bool includeLog = true)
        {
            try
            {
                BLIO.Log("Attempting to send an e-mail...");
                MailMessage mes = new MailMessage();
                mes.From = new MailAddress("remindmesmtp@hotmail.com");                
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
                return ex;
            }            
            return null;
        }
        


        private static string GetDomainName(string emailAddress)
        {
            int atIndex = emailAddress.IndexOf('@');
            if (atIndex == -1)
            {
                throw new ArgumentException("Not a valid email address",
                                            "emailAddress");
            }
            if (emailAddress.IndexOf('<') > -1 &&
                emailAddress.IndexOf('>') > -1)
            {
                return emailAddress.Substring(atIndex + 1,
                       emailAddress.IndexOf('>') - atIndex);
            }
            else
            {
                return emailAddress.Substring(atIndex + 1);
            }
        }

        private static IPAddress[] GetMailExchangeServer(string domainName)
        {
            IPHostEntry hostEntry = DomainNameUtil.GetIPHostEntryForMailExchange(domainName);

            if (hostEntry == null)
                return null;

            if (hostEntry.AddressList.Length > 0)
            {
                return hostEntry.AddressList;
            }
            else if (hostEntry.Aliases.Length > 0)
            {
                return System.Net.Dns.GetHostAddresses(hostEntry.Aliases[0]);
            }
            else
            {
                return null;
            }
        }

       
    }
}
