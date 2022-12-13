using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Business_Logic_Layer;
using MaterialSkin.Controls;
using System.Runtime.InteropServices;
using Database.Entity;

namespace RemindMe
{
    public partial class MUCHTTPRequest : UserControl
    {        
        private HttpClient client;
        private MUCNewReminder parent;
        private int rowCount = 1;
        public MUCHTTPRequest(MUCNewReminder parent)
        {
            try
            {
                InitializeComponent();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                client = new HttpClient();
                this.parent = parent;
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "Initialization of MUCHTTPRequest failed!");
            }
        }

        private void MUCHTTPRequest_Load(object sender, EventArgs e)
        {
            try
            {
                //Set the default to 'GET'
                cbType.SelectedItem = cbType.Items[0];

                //Numeric only
                tbInterval.KeyPress += num_KeyPress;
                tbInterval.KeyDown += num_KeyDown;
            }
            catch (Exception ex)
            {
                BLIO.WriteError(ex, "MUCHTTPRequest Load failed!");
            }
        }

        private async void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                btnTest.Text = "Executing...";
                if (string.IsNullOrWhiteSpace(tbHeaders.Text))
                    tbHeaders.Text = "{ }";

                object response = null;
                switch (cbType.SelectedItem.ToString())
                {
                    case "GET": response = await BLIO.HttpRequest("GET", tbUrl.Text, tbHeaders.Text);
                        break;
                    case "POST":response = await BLIO.HttpRequest("POST", tbUrl.Text, tbHeaders.Text, tbBody.Text);
                        break;
                }
                if(response != null)
                {
                    btnTest.Text = "Test";
                    string message = "API Connection: Success\r\n\r\n";
                    int count = 1;
                    try
                    {
                        foreach (var cond in Conditions)
                        {
                            HttpCondition condit = new HttpCondition(cond, (JObject)response);
                            message += "Condition " + count + ": " + condit.Evaluate() + "\r\n";

                            count++;
                        }
                    }
                    catch { }
                    MaterialRemindMeBox.Show(message); 
                }
            }
            catch (Exception ex)
            {
                MaterialRemindMeBox.Show("Failure! " + ex.Message);                
            }
            finally
            {
                btnTest.Text = "Test";
            }                                                
        }



        public bool ValidHttpConfiguration
        {
            get
            {                
                int condCount = Conditions.Count();
                if (condCount == 1)
                {
                    return !string.IsNullOrWhiteSpace(Condition) && !string.IsNullOrWhiteSpace(DataType)
                        && !string.IsNullOrWhiteSpace(Property) && !string.IsNullOrWhiteSpace(Operator)
                        && !string.IsNullOrWhiteSpace(Value) && Interval > 0;
                }
                else
                {
                    MaterialComboBox cbCond = null;
                    MaterialComboBox cbData = null;
                    MaterialComboBox cbOp = null;
                    MaterialTextBox tbProp = null;
                    MaterialTextBox tbVal = null;
                    bool valid = false;
                    for (int loopCount = 1; loopCount <= condCount; loopCount++)
                    {
                        try
                        {
                            if (loopCount == 1)
                            {
                                valid = !string.IsNullOrWhiteSpace(Condition) && !string.IsNullOrWhiteSpace(DataType)
                                    && !string.IsNullOrWhiteSpace(Property) && !string.IsNullOrWhiteSpace(Operator)
                                    && !string.IsNullOrWhiteSpace(Value) && Interval > 0;

                                if (valid == false)
                                    return false;
                            }
                            else
                            {
                                cbCond = (MaterialComboBox)pnlConditions.Controls.Find("cbCondition" + (loopCount-1), true)[0];
                                cbData = (MaterialComboBox)pnlConditions.Controls.Find("cbDataType" + (loopCount - 1), true)[0];
                                tbProp = (MaterialTextBox)pnlConditions.Controls.Find("tbProperty" + (loopCount - 1), true)[0];
                                cbOp = (MaterialComboBox)pnlConditions.Controls.Find("cbOperator" + (loopCount - 1), true)[0];
                                tbVal = (MaterialTextBox)pnlConditions.Controls.Find("tbValue" + (loopCount - 1), true)[0];


                                valid = !string.IsNullOrWhiteSpace(cbCond.SelectedItem.ToString()) && !string.IsNullOrWhiteSpace(cbData.SelectedItem.ToString())
                                    && !string.IsNullOrWhiteSpace(tbProp.Text) && !string.IsNullOrWhiteSpace(cbOp.SelectedItem.ToString())
                                    && !string.IsNullOrWhiteSpace(tbVal.Text) && Interval > 0;

                                if (valid == false)
                                    return false;
                            }
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    return valid;
                }
            }
        }
        public string URL
        {
            get { return tbUrl.Text; }
            set { tbUrl.Text = value; }
        }
        public string Type
        {
            get { return cbType.SelectedItem != null ? cbType.SelectedItem.ToString() : string.Empty; }
            set
            {
                if(cbType.FindStringExact(value) != -1)
                    cbType.SelectedItem = cbType.Items[cbType.FindStringExact(value)];
            }
        }
        public string AcceptHeader
        {
            get { return tbAccept.Text; }
            set { tbAccept.Text = value; }
        }
        public string ContentTypeHeader
        {
            get { return tbContentType.Text; }
            set { tbContentType.Text = value; }
        }
        public string OtherHeaders
        {
            get { return tbHeaders.Text; }
            set { tbHeaders.Text = value; }
        }
        public string Body
        {
            get { return tbBody.Text; }
            set { tbBody.Text = value; }
        }

        //
        public string Condition
        {
            get { return cbCondition.SelectedItem != null ? cbCondition.SelectedItem.ToString() : string.Empty; }
            set
            {
                if (cbCondition.FindStringExact(value) != -1)
                    cbCondition.SelectedItem = cbCondition.Items[cbCondition.FindStringExact(value)];
            }
        }
        public string DataType
        {
            get { return cbDataType.SelectedItem != null ? cbDataType.SelectedItem.ToString() : string.Empty; }
            set
            {
                if (cbDataType.FindStringExact(value) != -1)
                    cbDataType.SelectedItem = cbDataType.Items[cbDataType.FindStringExact(value)];
            }
        }
        public string Property
        {
            get { return tbProperty.Text; }
            set { tbProperty.Text = value; }
        }
        public string Operator
        {
            get { return cbOperator.SelectedItem != null ? cbOperator.SelectedItem.ToString() : string.Empty; }
            set
            {
                if (cbOperator.FindStringExact(value) != -1)
                    cbOperator.SelectedItem = cbOperator.Items[cbOperator.FindStringExact(value)];
            }
        }
        public string Value
        {
            get { return tbValue.Text; }
            set { tbValue.Text = value; }
        }

        public long Interval
        {
            get { return Convert.ToInt32(tbInterval.Text); }
            set { tbInterval.Text = ""+value; }
        }
        public string AfterPopup
        {
            get
            {
                if (cbAfterPopup.SelectedItem == null)
                    return "Stop";
                else if (cbAfterPopup.SelectedItem.ToString().StartsWith("Repeat"))
                    return "Repeat";
                else
                    return cbAfterPopup.SelectedItem.ToString();
            }
            set {
                if (cbAfterPopup.FindStringExact(value) != -1)
                    cbAfterPopup.SelectedItem = cbAfterPopup.Items[cbAfterPopup.FindStringExact(value)];
            }
        }
        public List<HttpRequestCondition> Conditions
        {
            get
            {
                List<HttpRequestCondition> returnValue = new List<HttpRequestCondition>();

                try
                {
                    //The actual controls first, then the dynamic controls
                    HttpRequestCondition con = new HttpRequestCondition();
                    con.Condition = cbCondition.SelectedItem.ToString();
                    con.DataType = cbDataType.SelectedItem.ToString();
                    con.Property = tbProperty.Text;
                    con.Operator = cbOperator.SelectedItem.ToString();
                    con.Value = tbValue.Text;
                    returnValue.Add(con);



                    for (int i = 1; i < rowCount; i++)
                    {
                        HttpRequestCondition cond = new HttpRequestCondition();
                        cond.Condition = ((MaterialComboBox)pnlConditions.Controls.Find("cbCondition" + i, true)[0]).SelectedItem.ToString();
                        cond.DataType = ((MaterialComboBox)pnlConditions.Controls.Find("cbDataType" + i, true)[0]).SelectedItem.ToString();
                        cond.Property = ((MaterialTextBox)pnlConditions.Controls.Find("tbProperty" + i, true)[0]).Text;
                        cond.Operator = ((MaterialComboBox)pnlConditions.Controls.Find("cbOperator" + i, true)[0]).SelectedItem.ToString();
                        cond.Value = ((MaterialTextBox)pnlConditions.Controls.Find("tbValue" + i, true)[0]).Text;

                        returnValue.Add(cond);
                    }
                }
                catch
                {
                    //To trigger ValidHttpCondition
                    HttpRequestCondition emptyCond = new HttpRequestCondition();
                    emptyCond.Condition = "";
                    emptyCond.DataType = "";
                    emptyCond.Property = "";
                    emptyCond.Operator = "";
                    emptyCond.Value = "";
                    returnValue.Add(emptyCond);
                }

                return returnValue;
            }
            set
            {
                MaterialComboBox cb = null;
                MaterialTextBox tb = null;
                int loopCount = 1;
                foreach (HttpRequestCondition cond in value)
                {
                    if (loopCount == 1)
                    {                        
                        cbCondition.SelectedItem = cbCondition.Items[cbCondition.FindStringExact(cond.Condition)];                        
                        cbDataType.SelectedItem = cbDataType.Items[cbDataType.FindStringExact(cond.DataType)];                        
                        tbProperty.Text = cond.Property;                        
                        cbOperator.SelectedItem = cbOperator.Items[cbOperator.FindStringExact(cond.Operator)];
                        tbValue.Text = cond.Value;
                    }
                    else
                    {
                        //First, add a row. The controls can then be accessed with .Find(name+count)
                        btnAddRow_Click(null, null);

                        cb = (MaterialComboBox)pnlConditions.Controls.Find("cbCondition" + (rowCount - 1), true)[0];
                        cb.SelectedItem = cb.Items[cb.FindStringExact(cond.Condition)];

                        cb = (MaterialComboBox)pnlConditions.Controls.Find("cbDataType" + (rowCount - 1), true)[0];
                        cb.SelectedItem = cb.Items[cb.FindStringExact(cond.DataType)];

                        tb = (MaterialTextBox)pnlConditions.Controls.Find("tbProperty" + (rowCount - 1), true)[0];
                        tb.Text = cond.Property;

                        cb = (MaterialComboBox)pnlConditions.Controls.Find("cbOperator" + (rowCount - 1), true)[0];
                        cb.SelectedItem = cb.Items[cb.FindStringExact(cond.Operator)];

                        tb = (MaterialTextBox)pnlConditions.Controls.Find("tbValue" + (rowCount - 1), true)[0];
                        tb.Text = cond.Value;
                     
                    }
                    loopCount++;
                }                                                    
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            if (cbAfterPopup.SelectedItem == null) //Default: stop
                cbAfterPopup.SelectedItem = cbAfterPopup.Items[0];                        

            if (!string.IsNullOrWhiteSpace(tbUrl.Text) && !ValidHttpConfiguration)
            {
                MaterialRemindMeBox.Show("Please fill in each field in the 'Rule' section to set up whenever this reminder is supposed to turn on.\r\n\r\n'Interval' Is also required");
                return;
            }

            
            MaterialForm form = (MaterialForm)this.Parent.Parent.Parent;                                    
            form.Hide();
            parent.AdvancedReminderFormCallback();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if(c is MaterialTextBox)
                {
                    c.ResetText();
                }
                if (c is MaterialMultiLineTextBox)
                {
                    c.Text = "{ }";
                }
                if(c is MaterialComboBox)
                {
                    MaterialComboBox cb = (MaterialComboBox)c;

                    if (cb.Name == "cbType")
                        cb.SelectedItem = cb.Items[0];
                    else                    
                        cb.SelectedItem = null;

                    cb.Invalidate();
                }
            }

            foreach (Control c in pnlConditions.Controls)
            {
                if (c is MaterialTextBox)
                {
                    c.ResetText();
                }
                if (c is MaterialComboBox)
                {
                    MaterialComboBox cb = (MaterialComboBox)c;
                
                    cb.SelectedItem = null;
                    cb.Invalidate();
                }
            }

            pnlConditions.AutoScrollPosition = new Point(0, 0);
            pnlConditions.Controls.Clear();

            pnlConditions.Controls.Add(cbCondition);
            pnlConditions.Controls.Add(cbDataType);
            pnlConditions.Controls.Add(tbProperty);
            pnlConditions.Controls.Add(cbOperator);
            pnlConditions.Controls.Add(tbValue); 

            rowCount = 1;            
        }

        private MaterialComboBox CloneComboBox(MaterialComboBox original)
        {
            MaterialComboBox copy = new MaterialComboBox();
            copy.AutoResize = original.AutoResize;
            copy.DrawMode = original.DrawMode;
            copy.DropDownHeight = original.DropDownHeight;
            copy.DropDownStyle = original.DropDownStyle;
            copy.DropDownWidth = original.DropDownWidth;
            copy.Font = original.Font;
            copy.ForeColor = original.ForeColor;
            copy.FormattingEnabled = original.FormattingEnabled;
            copy.Hint = original.Hint;
            copy.IntegralHeight = original.IntegralHeight;
            copy.ItemHeight = original.ItemHeight;
            copy.Items.AddRange(original.Items.Cast<Object>().ToArray());
            copy.MaxDropDownItems = original.MaxDropDownItems;
            copy.Size = original.Size;            
            return copy;
        }
        private MaterialTextBox CloneTextBox(MaterialTextBox original)
        {
            MaterialTextBox copy = new MaterialTextBox();
            copy.BorderStyle = original.BorderStyle;
            copy.Font = original.Font;
            copy.Hint = original.Hint;
            copy.Size = original.Size;
            copy.MaxLength = original.MaxLength;
            copy.Multiline = original.Multiline;            
            return copy;
        }
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedItem.ToString() != "GET")            
                tbHeaders.Size = new Size(365, tbHeaders.Height);
            else
                tbHeaders.Size = new Size(748, tbHeaders.Height);

            lblBody.Visible = cbType.SelectedItem.ToString() != "GET";
            tbBody.Visible = cbType.SelectedItem.ToString() != "GET";
        }

        private void cbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOperator.Items.Clear();

            if (cbDataType.SelectedItem != null)
            {
                switch (cbDataType.SelectedItem.ToString())
                {
                    case "string":
                        cbOperator.Items.AddRange(new[] { "==", "!=", "startsWith", "endsWith", "contains", "length ==", "length !=", "length >", "length <", "length >=", "length <=" });
                        break;
                    case "double":
                        cbOperator.Items.AddRange(new[] { "==", "!=", ">", "<", ">=", "<=" });
                        break;
                    case "bool":
                        cbOperator.Items.AddRange(new[] { "true", "false" });
                        break;
                }
            }
        }

        private void cbDataTypeDynamic_SelectedIndexChanged(int rCount)
        {
            Control[] op = pnlConditions.Controls.Find("cbOperator" + rCount, true);
            Control[] dt = pnlConditions.Controls.Find("cbDataType" + rCount, true);

            if (op.Length <= 0)
                throw new ArgumentException("No control with name cbOperator" + rCount + " was found!");

            if (dt.Length <= 0)
                throw new ArgumentException("No control with name cbDataType" + rCount + " was found!");

            MaterialComboBox cbOperatorDynamic = (MaterialComboBox)op[0];
            MaterialComboBox cbDataTypeDynamic = (MaterialComboBox)dt[0];
          
            cbOperatorDynamic.Items.Clear();
            if (cbDataTypeDynamic.SelectedItem != null)
            {
                switch (cbDataTypeDynamic.SelectedItem.ToString())
                {
                    case "string":
                        cbOperatorDynamic.Items.AddRange(new[] { "==", "!=", "startsWith", "endsWith", "contains", "length ==", "length !=", "length >", "length <", "length >=", "length <=" });
                        break;
                    case "double":
                        cbOperatorDynamic.Items.AddRange(new[] { "==", "!=", ">", "<", ">=", "<=" });
                        break;
                    case "bool":
                        cbOperatorDynamic.Items.AddRange(new[] { "true", "false" });
                        break;
                }
            }            
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            pnlConditions.AutoScrollPosition = new Point(0, 0);

            MaterialComboBox condition = CloneComboBox(cbCondition);
            MaterialComboBox dataType = CloneComboBox(cbDataType);
            MaterialComboBox op = CloneComboBox(cbOperator);

            MaterialTextBox property = CloneTextBox(tbProperty);
            MaterialTextBox value = CloneTextBox(tbValue);

            condition.Name = cbCondition.Name + rowCount;
            dataType.Name = cbDataType.Name + rowCount;
            op.Name = cbOperator.Name + rowCount;

            property.Name = tbProperty.Name + rowCount;
            value.Name = tbValue.Name + rowCount;
            //Names fixed, location is next

            condition.Location = new Point(cbCondition.Location.X, (cbCondition.Location.Y + cbCondition.Height) * rowCount);
            dataType.Location = new Point(cbDataType.Location.X, (cbDataType.Location.Y + cbDataType.Height) * rowCount);
            op.Location = new Point(cbOperator.Location.X, (cbOperator.Location.Y + cbOperator.Height) * rowCount);

            property.Location = new Point(tbProperty.Location.X, (tbProperty.Location.Y + cbCondition.Height) * rowCount);
            value.Location = new Point(tbValue.Location.X, (tbValue.Location.Y + cbCondition.Height) * rowCount);

            //location fixed, add em to the panel
            int currRowCount = 0 + rowCount;
            dataType.SelectedIndexChanged += (s, ee) => cbDataTypeDynamic_SelectedIndexChanged(currRowCount);
            op.SelectedIndexChanged += (s, ee) => cbOperatorDynamic_SelectedIndexChanged(currRowCount);

            pnlConditions.Controls.Add(condition);
            pnlConditions.Controls.Add(dataType);
            pnlConditions.Controls.Add(op);
            pnlConditions.Controls.Add(property);
            pnlConditions.Controls.Add(value);

            rowCount++;
        }

        private void cbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbOperator.SelectedItem.ToString() == "true" || cbOperator.SelectedItem.ToString() == "false")
            {
                tbValue.Text = "N/A";
                tbValue.Enabled = false;
            }
            else
            {
                tbValue.Text = "";
                tbValue.Enabled = true;
            }
        }

        private void cbOperatorDynamic_SelectedIndexChanged(int rCount)
        {
            Control[] op = pnlConditions.Controls.Find("cbOperator" + rCount, true);
            Control[] tb = pnlConditions.Controls.Find("tbValue" + rCount, true);

            if (op.Length <= 0)
                throw new ArgumentException("No control with name cbOperator" + rCount + " was found!");

            if (tb.Length <= 0)
                throw new ArgumentException("No control with name tbValue" + rCount + " was found!");

            MaterialComboBox cbOperatorDynamic = (MaterialComboBox)op[0];
            MaterialTextBox tbValueDynamic = (MaterialTextBox)tb[0];

            if (cbOperatorDynamic.SelectedItem.ToString() == "true" || cbOperatorDynamic.SelectedItem.ToString() == "false")
            {
                tbValueDynamic.Text = "N/A";
                tbValueDynamic.Enabled = false;
            }
            else
            {
                tbValueDynamic.Text = "";
                tbValueDynamic.Enabled = true;
            }
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (rowCount > 1)
                rowCount--;
            else
                return;

            Control c;

            c = pnlConditions.Controls.Find("cbCondition" + rowCount, true)[0];
            pnlConditions.Controls.Remove(c);
            c.Dispose();

            c = pnlConditions.Controls.Find("cbDataType" + rowCount, true)[0];
            pnlConditions.Controls.Remove(c);
            c.Dispose();

            c = pnlConditions.Controls.Find("tbProperty" + rowCount, true)[0];
            pnlConditions.Controls.Remove(c);
            c.Dispose();

            c = pnlConditions.Controls.Find("cbOperator" + rowCount, true)[0];
            pnlConditions.Controls.Remove(c);
            c.Dispose();

            c = pnlConditions.Controls.Find("tbValue" + rowCount, true)[0];
            pnlConditions.Controls.Remove(c);
            c.Dispose();            
        }

        private void num_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void num_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
                e.Handled = true;
        }
    }
}
