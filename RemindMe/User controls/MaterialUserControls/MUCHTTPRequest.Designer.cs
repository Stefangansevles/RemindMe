namespace RemindMe
{
    partial class MUCHTTPRequest
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.btnReset = new MaterialSkin.Controls.MaterialButton();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.cbAfterPopup = new MaterialSkin.Controls.MaterialComboBox();
            this.tbUrl = new MaterialSkin.Controls.MaterialTextBox();
            this.tbInterval = new MaterialSkin.Controls.MaterialTextBox();
            this.tbBody = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.tbValue = new MaterialSkin.Controls.MaterialTextBox();
            this.btnTest = new MaterialSkin.Controls.MaterialButton();
            this.cbOperator = new MaterialSkin.Controls.MaterialComboBox();
            this.lblBody = new MaterialSkin.Controls.MaterialLabel();
            this.cbDataType = new MaterialSkin.Controls.MaterialComboBox();
            this.lbl = new MaterialSkin.Controls.MaterialLabel();
            this.materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            this.tbAccept = new MaterialSkin.Controls.MaterialTextBox();
            this.tbProperty = new MaterialSkin.Controls.MaterialTextBox();
            this.tbHeaders = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.cbCondition = new MaterialSkin.Controls.MaterialComboBox();
            this.tbContentType = new MaterialSkin.Controls.MaterialTextBox();
            this.cbType = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.pnlConditions = new System.Windows.Forms.Panel();
            this.btnAddRow = new MaterialSkin.Controls.MaterialButton();
            this.btnRemoveRow = new MaterialSkin.Controls.MaterialButton();
            this.pnlConditions.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.materialLabel3.Location = new System.Drawing.Point(38, 13);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(1279, 17);
            this.materialLabel3.TabIndex = 135;
            this.materialLabel3.Text = "Here you can enable reminders to popup if the specific condition is met from the " +
    "response of the given API url\r\nFor an explanation on how to use this, see: https" +
    "://github.com/stefangansevles/remindme";
            // 
            // btnReset
            // 
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Depth = 0;
            this.btnReset.DrawShadows = true;
            this.btnReset.HighEmphasis = true;
            this.btnReset.Icon = global::RemindMe.Properties.Resources.Bin_white;
            this.btnReset.Location = new System.Drawing.Point(635, 464);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(137, 36);
            this.btnReset.TabIndex = 134;
            this.btnReset.Text = "Reset form";
            this.btnReset.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReset.UseAccentColor = false;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSize = false;
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.DrawShadows = true;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = global::RemindMe.Properties.Resources.saveWhite;
            this.btnConfirm.Location = new System.Drawing.Point(21, 464);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(142, 36);
            this.btnConfirm.TabIndex = 133;
            this.btnConfirm.Text = "Save";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cbAfterPopup
            // 
            this.cbAfterPopup.AutoResize = false;
            this.cbAfterPopup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbAfterPopup.Depth = 0;
            this.cbAfterPopup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbAfterPopup.DropDownHeight = 174;
            this.cbAfterPopup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAfterPopup.DropDownWidth = 150;
            this.cbAfterPopup.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbAfterPopup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbAfterPopup.FormattingEnabled = true;
            this.cbAfterPopup.Hint = "On popup";
            this.cbAfterPopup.IntegralHeight = false;
            this.cbAfterPopup.ItemHeight = 43;
            this.cbAfterPopup.Items.AddRange(new object[] {
            "Stop",
            "Repeat (interval)"});
            this.cbAfterPopup.Location = new System.Drawing.Point(657, 94);
            this.cbAfterPopup.MaxDropDownItems = 4;
            this.cbAfterPopup.MouseState = MaterialSkin.MouseState.OUT;
            this.cbAfterPopup.Name = "cbAfterPopup";
            this.cbAfterPopup.Size = new System.Drawing.Size(109, 49);
            this.cbAfterPopup.TabIndex = 18;
            // 
            // tbUrl
            // 
            this.tbUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbUrl.Depth = 0;
            this.tbUrl.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbUrl.Hint = "URL";
            this.tbUrl.Location = new System.Drawing.Point(18, 38);
            this.tbUrl.MaxLength = 2048;
            this.tbUrl.MouseState = MaterialSkin.MouseState.OUT;
            this.tbUrl.Multiline = false;
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(633, 50);
            this.tbUrl.TabIndex = 0;
            this.tbUrl.Text = "";
            // 
            // tbInterval
            // 
            this.tbInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInterval.Depth = 0;
            this.tbInterval.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbInterval.Hint = "Interval(Minutes)";
            this.tbInterval.Location = new System.Drawing.Point(537, 94);
            this.tbInterval.MaxLength = 2048;
            this.tbInterval.MouseState = MaterialSkin.MouseState.OUT;
            this.tbInterval.Multiline = false;
            this.tbInterval.Name = "tbInterval";
            this.tbInterval.Size = new System.Drawing.Size(114, 50);
            this.tbInterval.TabIndex = 17;
            this.tbInterval.Text = "0";
            // 
            // tbBody
            // 
            this.tbBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbBody.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBody.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbBody.Depth = 0;
            this.tbBody.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.tbBody.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbBody.Hint = "";
            this.tbBody.Location = new System.Drawing.Point(391, 175);
            this.tbBody.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbBody.Name = "tbBody";
            this.tbBody.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbBody.Size = new System.Drawing.Size(375, 100);
            this.tbBody.TabIndex = 5;
            this.tbBody.Text = "{ }";
            // 
            // tbValue
            // 
            this.tbValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbValue.Depth = 0;
            this.tbValue.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbValue.Hint = "Value";
            this.tbValue.Location = new System.Drawing.Point(587, 0);
            this.tbValue.MaxLength = 2048;
            this.tbValue.MouseState = MaterialSkin.MouseState.OUT;
            this.tbValue.Multiline = false;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(141, 50);
            this.tbValue.TabIndex = 15;
            this.tbValue.Text = "";
            // 
            // btnTest
            // 
            this.btnTest.AutoSize = false;
            this.btnTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTest.Depth = 0;
            this.btnTest.DrawShadows = true;
            this.btnTest.HighEmphasis = true;
            this.btnTest.Icon = global::RemindMe.Properties.Resources.lightningBolt;
            this.btnTest.Location = new System.Drawing.Point(171, 464);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTest.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(142, 36);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTest.UseAccentColor = false;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // cbOperator
            // 
            this.cbOperator.AutoResize = false;
            this.cbOperator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbOperator.Depth = 0;
            this.cbOperator.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbOperator.DropDownHeight = 174;
            this.cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOperator.DropDownWidth = 121;
            this.cbOperator.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbOperator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Hint = "Operator";
            this.cbOperator.IntegralHeight = false;
            this.cbOperator.ItemHeight = 43;
            this.cbOperator.Location = new System.Drawing.Point(476, 0);
            this.cbOperator.MaxDropDownItems = 4;
            this.cbOperator.MouseState = MaterialSkin.MouseState.OUT;
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(105, 49);
            this.cbOperator.TabIndex = 14;
            this.cbOperator.SelectedIndexChanged += new System.EventHandler(this.cbOperator_SelectedIndexChanged);
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = true;
            this.lblBody.Depth = 0;
            this.lblBody.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBody.Location = new System.Drawing.Point(391, 151);
            this.lblBody.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(93, 19);
            this.lblBody.TabIndex = 6;
            this.lblBody.Text = "Body (JSON)";
            // 
            // cbDataType
            // 
            this.cbDataType.AutoResize = false;
            this.cbDataType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbDataType.Depth = 0;
            this.cbDataType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbDataType.DropDownHeight = 174;
            this.cbDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataType.DropDownWidth = 121;
            this.cbDataType.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbDataType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbDataType.FormattingEnabled = true;
            this.cbDataType.Hint = "Data type";
            this.cbDataType.IntegralHeight = false;
            this.cbDataType.ItemHeight = 43;
            this.cbDataType.Items.AddRange(new object[] {
            "string",
            "double",
            "bool"});
            this.cbDataType.Location = new System.Drawing.Point(116, 0);
            this.cbDataType.MaxDropDownItems = 4;
            this.cbDataType.MouseState = MaterialSkin.MouseState.OUT;
            this.cbDataType.Name = "cbDataType";
            this.cbDataType.Size = new System.Drawing.Size(118, 49);
            this.cbDataType.TabIndex = 13;
            this.cbDataType.SelectedIndexChanged += new System.EventHandler(this.cbDataType_SelectedIndexChanged);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Depth = 0;
            this.lbl.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbl.Location = new System.Drawing.Point(18, 151);
            this.lbl.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(155, 19);
            this.lbl.TabIndex = 3;
            this.lbl.Text = "Other headers (JSON)";
            // 
            // materialTextBox2
            // 
            this.materialTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox2.Depth = 0;
            this.materialTextBox2.Enabled = false;
            this.materialTextBox2.Font = new System.Drawing.Font("Roboto", 12F);
            this.materialTextBox2.Hint = "Loop over property";
            this.materialTextBox2.Location = new System.Drawing.Point(772, 389);
            this.materialTextBox2.MaxLength = 2048;
            this.materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox2.Multiline = false;
            this.materialTextBox2.Name = "materialTextBox2";
            this.materialTextBox2.Size = new System.Drawing.Size(56, 50);
            this.materialTextBox2.TabIndex = 12;
            this.materialTextBox2.Text = "";
            this.materialTextBox2.Visible = false;
            // 
            // tbAccept
            // 
            this.tbAccept.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAccept.Depth = 0;
            this.tbAccept.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbAccept.Hint = "Accept Header \"application/json\",  etc";
            this.tbAccept.Location = new System.Drawing.Point(18, 94);
            this.tbAccept.MaxLength = 2048;
            this.tbAccept.MouseState = MaterialSkin.MouseState.OUT;
            this.tbAccept.Multiline = false;
            this.tbAccept.Name = "tbAccept";
            this.tbAccept.Size = new System.Drawing.Size(281, 50);
            this.tbAccept.TabIndex = 7;
            this.tbAccept.Text = "";
            // 
            // tbProperty
            // 
            this.tbProperty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProperty.Depth = 0;
            this.tbProperty.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbProperty.Hint = "Property ";
            this.tbProperty.Location = new System.Drawing.Point(240, 0);
            this.tbProperty.MaxLength = 2048;
            this.tbProperty.MouseState = MaterialSkin.MouseState.OUT;
            this.tbProperty.Multiline = false;
            this.tbProperty.Name = "tbProperty";
            this.tbProperty.Size = new System.Drawing.Size(230, 50);
            this.tbProperty.TabIndex = 11;
            this.tbProperty.Text = "";
            // 
            // tbHeaders
            // 
            this.tbHeaders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tbHeaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbHeaders.Depth = 0;
            this.tbHeaders.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.tbHeaders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tbHeaders.Hint = "";
            this.tbHeaders.Location = new System.Drawing.Point(18, 175);
            this.tbHeaders.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbHeaders.Name = "tbHeaders";
            this.tbHeaders.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.tbHeaders.Size = new System.Drawing.Size(748, 100);
            this.tbHeaders.TabIndex = 2;
            this.tbHeaders.Text = "{ }";
            // 
            // cbCondition
            // 
            this.cbCondition.AutoResize = false;
            this.cbCondition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbCondition.Depth = 0;
            this.cbCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbCondition.DropDownHeight = 174;
            this.cbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondition.DropDownWidth = 121;
            this.cbCondition.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbCondition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.Hint = "Condition";
            this.cbCondition.IntegralHeight = false;
            this.cbCondition.ItemHeight = 43;
            this.cbCondition.Items.AddRange(new object[] {
            "IF"});
            this.cbCondition.Location = new System.Drawing.Point(0, 0);
            this.cbCondition.MaxDropDownItems = 4;
            this.cbCondition.MouseState = MaterialSkin.MouseState.OUT;
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(110, 49);
            this.cbCondition.TabIndex = 10;
            // 
            // tbContentType
            // 
            this.tbContentType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbContentType.Depth = 0;
            this.tbContentType.Font = new System.Drawing.Font("Roboto", 12F);
            this.tbContentType.Hint = "Content-Type Header";
            this.tbContentType.Location = new System.Drawing.Point(305, 94);
            this.tbContentType.MaxLength = 2048;
            this.tbContentType.MouseState = MaterialSkin.MouseState.OUT;
            this.tbContentType.Multiline = false;
            this.tbContentType.Name = "tbContentType";
            this.tbContentType.Size = new System.Drawing.Size(226, 50);
            this.tbContentType.TabIndex = 8;
            this.tbContentType.Text = "";
            // 
            // cbType
            // 
            this.cbType.AutoResize = false;
            this.cbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbType.Depth = 0;
            this.cbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbType.DropDownHeight = 174;
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.DropDownWidth = 121;
            this.cbType.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbType.FormattingEnabled = true;
            this.cbType.Hint = "Type";
            this.cbType.IntegralHeight = false;
            this.cbType.ItemHeight = 43;
            this.cbType.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.cbType.Location = new System.Drawing.Point(657, 38);
            this.cbType.MaxDropDownItems = 4;
            this.cbType.MouseState = MaterialSkin.MouseState.OUT;
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(109, 49);
            this.cbType.TabIndex = 1;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.materialLabel2.Location = new System.Drawing.Point(23, 289);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(500, 19);
            this.materialLabel2.TabIndex = 9;
            this.materialLabel2.Text = "Rule (Split each property by a dot (\".\") ) The rules share an AND relation";
            // 
            // pnlConditions
            // 
            this.pnlConditions.AutoScroll = true;
            this.pnlConditions.Controls.Add(this.cbCondition);
            this.pnlConditions.Controls.Add(this.tbProperty);
            this.pnlConditions.Controls.Add(this.cbDataType);
            this.pnlConditions.Controls.Add(this.cbOperator);
            this.pnlConditions.Controls.Add(this.tbValue);
            this.pnlConditions.Location = new System.Drawing.Point(21, 318);
            this.pnlConditions.Name = "pnlConditions";
            this.pnlConditions.Size = new System.Drawing.Size(745, 137);
            this.pnlConditions.TabIndex = 136;
            // 
            // btnAddRow
            // 
            this.btnAddRow.AutoSize = false;
            this.btnAddRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddRow.Depth = 0;
            this.btnAddRow.DrawShadows = true;
            this.btnAddRow.HighEmphasis = true;
            this.btnAddRow.Icon = null;
            this.btnAddRow.Location = new System.Drawing.Point(741, 287);
            this.btnAddRow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddRow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(25, 25);
            this.btnAddRow.TabIndex = 137;
            this.btnAddRow.Text = "+";
            this.btnAddRow.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAddRow.UseAccentColor = false;
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.AutoSize = false;
            this.btnRemoveRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemoveRow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRemoveRow.Depth = 0;
            this.btnRemoveRow.DrawShadows = true;
            this.btnRemoveRow.HighEmphasis = true;
            this.btnRemoveRow.Icon = null;
            this.btnRemoveRow.Location = new System.Drawing.Point(711, 287);
            this.btnRemoveRow.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemoveRow.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(25, 25);
            this.btnRemoveRow.TabIndex = 138;
            this.btnRemoveRow.Text = "-";
            this.btnRemoveRow.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRemoveRow.UseAccentColor = false;
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // MUCHTTPRequest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnRemoveRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.pnlConditions);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tbInterval);
            this.Controls.Add(this.cbAfterPopup);
            this.Controls.Add(this.tbUrl);
            this.Controls.Add(this.tbBody);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblBody);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.materialTextBox2);
            this.Controls.Add(this.tbAccept);
            this.Controls.Add(this.tbHeaders);
            this.Controls.Add(this.tbContentType);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.materialLabel2);
            this.Name = "MUCHTTPRequest";
            this.Size = new System.Drawing.Size(777, 516);
            this.Load += new System.EventHandler(this.MUCHTTPRequest_Load);
            this.pnlConditions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox tbUrl;
        private MaterialSkin.Controls.MaterialComboBox cbType;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbHeaders;
        private MaterialSkin.Controls.MaterialLabel lbl;
        private MaterialSkin.Controls.MaterialButton btnTest;
        private MaterialSkin.Controls.MaterialMultiLineTextBox tbBody;
        private MaterialSkin.Controls.MaterialLabel lblBody;
        private MaterialSkin.Controls.MaterialTextBox tbAccept;
        private MaterialSkin.Controls.MaterialTextBox tbContentType;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialComboBox cbCondition;
        private MaterialSkin.Controls.MaterialTextBox tbProperty;
        private MaterialSkin.Controls.MaterialComboBox cbDataType;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private MaterialSkin.Controls.MaterialComboBox cbOperator;
        private MaterialSkin.Controls.MaterialTextBox tbValue;
        private MaterialSkin.Controls.MaterialTextBox tbInterval;
        private MaterialSkin.Controls.MaterialComboBox cbAfterPopup;
        private MaterialSkin.Controls.MaterialButton btnConfirm;
        private MaterialSkin.Controls.MaterialButton btnReset;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private System.Windows.Forms.Panel pnlConditions;
        private MaterialSkin.Controls.MaterialButton btnAddRow;
        private MaterialSkin.Controls.MaterialButton btnRemoveRow;
    }
}
