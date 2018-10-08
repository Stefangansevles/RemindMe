using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;

namespace RemindMe
{
    public partial class UCReminderItem : UserControl
    {
        //Fill this user control with the details of this reminder
        private Reminder rem;
        //Determine if this control is "Selected"
        private bool selected = false;
        public UCReminderItem(Reminder rem)
        {
            InitializeComponent();
            this.rem = rem;

            //Make it so that it doesn't matter where on the item you click, the click event gets fired
            this.Click += UCReminderItem_Selected;
            lblDate.Click += UCReminderItem_Selected;
            lblReminderName.Click += UCReminderItem_Selected;
            lblRepeat.Click += UCReminderItem_Selected;
            pbRepeat.Click += UCReminderItem_Selected;
            pbDate.Click += UCReminderItem_Selected;
        }
        private void UCReminderItem_Selected(object sender,EventArgs e)
        {
            selected = !selected;

            if (selected)
                this.BackColor = Color.FromArgb(75,75,75);
            else
                this.BackColor = Color.DimGray;

        }
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                if (selected)
                    this.BackColor = Color.FromArgb(75,75,75);
                else
                    this.BackColor = Color.DimGray;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {

            if (this.ClientRectangle.Contains(this.PointToClient(Control.MousePosition)))
                return;
            else
            {
                if(!selected)
                    this.BackColor = Color.DimGray;

                base.OnMouseLeave(e);
            }
        }

        private void UCReminderItem_Load(object sender, EventArgs e)
        {
            //Prevent flickering
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            lblDate.Text = rem.Date.Split(',')[0].ToString();
            lblReminderName.Text = rem.Name;
            lblRepeat.Text = BLReminder.GetRepeatTypeText(rem);
        }

        

        private void UCReminderItem_MouseEnter(object sender, EventArgs e)
        {
            if(!selected)
                this.BackColor = Color.FromArgb(150, 150, 150);
        }

        
    }
}
