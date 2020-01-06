using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using Database.Entity;

namespace Business_Logic_Layer
{
    public class BLReadMessages
    {
        private BLReadMessages() { }

        /// <summary>
        /// Gets the column sizes of the Listview in the SQLite database 
        /// </summary>
        /// <returns></returns>
        public static List<ReadMessages> Messages
        {
            get { return DLReadMessages.Messages; }
        }

        /// <summary>
        /// Inserts the reminder into the database.
        /// </summary>
        /// <param name="rem">The reminder you want added into the database</param>
        public static bool MarkMessageRead(Database.Entity.RemindMeMessages message)
        {
            try
            {
                ReadMessages msg = new ReadMessages();
                msg.ReadMessageId = message.Id;
                msg.MessageText = message.Message;
                msg.ReadDate = message.DateOfCreation.Value.ToString();

                using (RemindMeDbEntities db = new RemindMeDbEntities())
                {
                    if (db.ReadMessages.Count() > 0)
                        msg.Id = db.ReadMessages.Max(i => i.Id) + 1;
                    else
                        msg.Id = 0;

                    db.ReadMessages.Add(msg);
                    db.SaveChanges();                    
                    db.Dispose();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Removes a message that is marked as read from the local database
        /// </summary>
        /// <param name="onlineMessageId">the Id of the online message in the database</param>
        public static void DeleteMessage(int onlineMessageId)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                ReadMessages readMess = db.ReadMessages.Where(rm => rm.ReadMessageId == onlineMessageId).FirstOrDefault();
                if (readMess != null)
                {
                    db.ReadMessages.Attach(readMess);
                    db.ReadMessages.Remove(readMess);
                    db.SaveChanges();
                    db.Dispose();
                }
            }
        }
    }
}
