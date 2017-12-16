using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLPopupDimensions
    {
        private DLPopupDimensions() { }

        private static PopupDimensions dimensions;

        private const int DEFAULT_FORM_WIDTH = 371;
        private const int DEFAULT_FORM_HEIGHT = 307;
        private const int DEFAULT_FONT_TITLE_SIZE = 14;
        private const int DEFAULT_FONT_NOTE_SIZE = 9;


        public static PopupDimensions GetPopupDimensions()
        {
            if (dimensions == null)
                RefreshDimensions();

            return dimensions;
        }

        private static void SaveAndCloseDataBase(RemindMeDbEntities db)
        {
            db.SaveChanges();            
            db.Dispose();
            RefreshDimensions();
        }

        private static void RefreshDimensions()
        {

            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {
                int count = db.PopupDimensions.Where(o => o.Id >= 0).Count();
                if (count == 0) //no dimensions yet.
                {
                    dimensions = new PopupDimensions();
                    dimensions.FormWidth = DEFAULT_FORM_WIDTH;
                    dimensions.FormHeight = DEFAULT_FORM_HEIGHT;
                    dimensions.FontTitleSize = DEFAULT_FONT_TITLE_SIZE;
                    dimensions.FontNoteSize = DEFAULT_FONT_NOTE_SIZE;

                    UpdatePopupDimensions(dimensions);
                }
                else
                    dimensions = (from s in db.PopupDimensions select s).ToList().FirstOrDefault();

                db.SaveChanges();
                db.Dispose();                
            }
        }

        public static void ResetToDefaults()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {

                dimensions = new PopupDimensions();
                dimensions.FormWidth = DEFAULT_FORM_WIDTH;
                dimensions.FormHeight = DEFAULT_FORM_HEIGHT;
                dimensions.FontTitleSize = DEFAULT_FONT_TITLE_SIZE;
                dimensions.FontNoteSize = DEFAULT_FONT_NOTE_SIZE;

                UpdatePopupDimensions(dimensions);
                db.Dispose();              
            }
        }

        public static void UpdatePopupDimensions(PopupDimensions dimensions)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {

                var count = db.PopupDimensions.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {
                    db.PopupDimensions.Attach(dimensions);
                    var entry = db.Entry(dimensions);
                    entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                    SaveAndCloseDataBase(db);
                }
                else
                {//The dimensions table is still empty
                    db.PopupDimensions.Add(dimensions);
                    SaveAndCloseDataBase(db);
                }
            }
        }
    }
}
