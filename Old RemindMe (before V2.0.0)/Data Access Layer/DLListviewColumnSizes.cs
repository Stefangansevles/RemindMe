using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLListviewColumnSizes
    {
        private DLListviewColumnSizes() { }
        private static ListviewColumnSizes sizes;
        
        private const int DEFAULT_TITLE_WIDTH = 300;
        private const int DEFAULT_DATE_WIDTH = 100;
        private const int DEFAULT_REPEAT_WIDTH = 135;
        private const int DEFAULT_ENABLED_WIDTH = 110;


        public static ListviewColumnSizes GetColumnSizes()
        {
            if (sizes == null)
                RefreshDimensions();

            return sizes;
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
                int count = db.ListviewColumnSizes.Where(o => o.Id >= 0).Count();
                if (count == 0) //no dimensions yet.
                {
                    sizes = new ListviewColumnSizes();
                    sizes.Title = DEFAULT_TITLE_WIDTH;
                    sizes.Date = DEFAULT_DATE_WIDTH;
                    sizes.Repeating = DEFAULT_REPEAT_WIDTH;
                    sizes.Enabled = DEFAULT_ENABLED_WIDTH;

                    UpdateListviewSizes(sizes);
                }
                else
                    sizes = (from s in db.ListviewColumnSizes select s).ToList().FirstOrDefault();

                db.SaveChanges();
                db.Dispose();
            }
        }

        public static void ResetToDefaults()
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {

                sizes = new ListviewColumnSizes();
                sizes.Title = DEFAULT_TITLE_WIDTH;
                sizes.Date = DEFAULT_DATE_WIDTH;
                sizes.Repeating = DEFAULT_REPEAT_WIDTH;
                sizes.Enabled = DEFAULT_ENABLED_WIDTH;

                UpdateListviewSizes(sizes);
                db.Dispose();
            }
        }

        public static void UpdateListviewSizes(ListviewColumnSizes sizes)
        {
            using (RemindMeDbEntities db = new RemindMeDbEntities())
            {

                var count = db.ListviewColumnSizes.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {
                    db.ListviewColumnSizes.Attach(sizes);
                    var entry = db.Entry(sizes);
                    entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                    SaveAndCloseDataBase(db);
                }
                else
                {//The dimensions table is still empty
                    db.ListviewColumnSizes.Add(sizes);
                    SaveAndCloseDataBase(db);
                }
            }
        }
    }
}
