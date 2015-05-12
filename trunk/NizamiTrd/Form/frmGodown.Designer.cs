namespace TaxSolution
{
    partial class frmGodown
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblST = new System.Windows.Forms.Label();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.textST = new System.Windows.Forms.TextBox();
            this.contextMenuStripSDI_Master = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSDI_Master = new System.Windows.Forms.ToolStrip();
            this.toolStripMenuItemSDI_Master1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripMenuItemSDI_Master2 = new System.Windows.Forms.ToolStripLabel();
            this.chkIsDisabled = new System.Windows.Forms.CheckBox();
            this.chkIsDefault = new System.Windows.Forms.CheckBox();
            this.mtextID = new System.Windows.Forms.MaskedTextBox();
            this.lblTopLine1 = new System.Windows.Forms.Label();
            this.lblTopLine2 = new System.Windows.Forms.Label();
            this.panelFormTitle = new System.Windows.Forms.Panel();
            this.mtext = new System.Windows.Forms.MaskedTextBox();
            this.lblTopLine3 = new System.Windows.Forms.Label();
            this.lblBottomLine1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLblStatusTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblTotalText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblAlertTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.textAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipSDI = new System.Windows.Forms.ToolTip(this.components);
            this.mtextOrdering = new System.Windows.Forms.MaskedTextBox();
            this.mtextGLID = new System.Windows.Forms.MaskedTextBox();
            this.lblOrdering = new System.Windows.Forms.Label();
            this.lblFromID = new System.Windows.Forms.Label();
            this.lblAcTitle = new System.Windows.Forms.Label();
            this.toolStripSDI_Master.SuspendLayout();
            this.panelFormTitle.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(287, 216);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(60, 25);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "&Save";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(349, 216);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(60, 25);
            this.btn_Clear.TabIndex = 8;
            this.btn_Clear.Text = "&Clear";
            this.btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.Location = new System.Drawing.Point(410, 216);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(60, 25);
            this.btn_Delete.TabIndex = 9;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(480, 216);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(60, 25);
            this.btn_Exit.TabIndex = 10;
            this.btn_Exit.Text = "E&xit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblFormTitle.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.lblFormTitle.Location = new System.Drawing.Point(316, 21);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(234, 35);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Godown ID >>>";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(64, 84);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 7;
            this.lblID.Text = "ID :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(55, 109);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 13);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Title :";
            // 
            // lblST
            // 
            this.lblST.AutoSize = true;
            this.lblST.Location = new System.Drawing.Point(27, 134);
            this.lblST.Name = "lblST";
            this.lblST.Size = new System.Drawing.Size(61, 13);
            this.lblST.TabIndex = 9;
            this.lblST.Text = "Short Title :";
            // 
            // textTitle
            // 
            this.textTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTitle.Location = new System.Drawing.Point(94, 104);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(434, 20);
            this.textTitle.TabIndex = 1;
            this.toolTipSDI.SetToolTip(this.textTitle, "Title or Name Alphanumeric characters Max Length =");
            // 
            // textST
            // 
            this.textST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textST.Location = new System.Drawing.Point(94, 129);
            this.textST.Name = "textST";
            this.textST.Size = new System.Drawing.Size(88, 20);
            this.textST.TabIndex = 2;
            this.toolTipSDI.SetToolTip(this.textST, "Short Name Alphanumeric Charactrs Max Length =");
            // 
            // contextMenuStripSDI_Master
            // 
            this.contextMenuStripSDI_Master.Name = "contextMenuStripSDI_Master";
            this.contextMenuStripSDI_Master.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStripSDI_Master
            // 
            this.toolStripSDI_Master.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSDI_Master.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSDI_Master1,
            this.toolStripMenuItemSDI_Master2});
            this.toolStripSDI_Master.Location = new System.Drawing.Point(0, 0);
            this.toolStripSDI_Master.Name = "toolStripSDI_Master";
            this.toolStripSDI_Master.Size = new System.Drawing.Size(551, 25);
            this.toolStripSDI_Master.TabIndex = 12;
            this.toolStripSDI_Master.Text = "toolStrip1";
            // 
            // toolStripMenuItemSDI_Master1
            // 
            this.toolStripMenuItemSDI_Master1.Name = "toolStripMenuItemSDI_Master1";
            this.toolStripMenuItemSDI_Master1.Size = new System.Drawing.Size(45, 22);
            this.toolStripMenuItemSDI_Master1.Text = "Next ID";
            this.toolStripMenuItemSDI_Master1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripMenuItemSDI_Master2
            // 
            this.toolStripMenuItemSDI_Master2.Name = "toolStripMenuItemSDI_Master2";
            this.toolStripMenuItemSDI_Master2.Size = new System.Drawing.Size(42, 22);
            this.toolStripMenuItemSDI_Master2.Text = "Last ID";
            this.toolStripMenuItemSDI_Master2.Click += new System.EventHandler(this.toolStripMenuItemSDI_Master2_Click);
            // 
            // chkIsDisabled
            // 
            this.chkIsDisabled.AutoSize = true;
            this.chkIsDisabled.Location = new System.Drawing.Point(94, 206);
            this.chkIsDisabled.Name = "chkIsDisabled";
            this.chkIsDisabled.Size = new System.Drawing.Size(78, 17);
            this.chkIsDisabled.TabIndex = 5;
            this.chkIsDisabled.Text = "Is Disabled";
            this.toolTipSDI.SetToolTip(this.chkIsDisabled, "When Checked, ID is Disabled, Un-Checked, ID is Active");
            this.chkIsDisabled.UseVisualStyleBackColor = true;
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.AutoSize = true;
            this.chkIsDefault.Enabled = false;
            this.chkIsDefault.Location = new System.Drawing.Point(94, 233);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Size = new System.Drawing.Size(71, 17);
            this.chkIsDefault.TabIndex = 6;
            this.chkIsDefault.Text = "Is Default";
            this.chkIsDefault.UseVisualStyleBackColor = true;
            // 
            // mtextID
            // 
            this.mtextID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtextID.Location = new System.Drawing.Point(94, 79);
            this.mtextID.Name = "mtextID";
            this.mtextID.Size = new System.Drawing.Size(88, 20);
            this.mtextID.TabIndex = 0;
            this.toolTipSDI.SetToolTip(this.mtextID, "ID or Code Number. Only Numeric characters allowed. Format: ");
            this.mtextID.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtextID_MaskInputRejected);
            this.mtextID.DoubleClick += new System.EventHandler(this.mtextID_DoubleClick);
            this.mtextID.Enter += new System.EventHandler(this.mtextID_Enter);
            this.mtextID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtextID_KeyDown);
            this.mtextID.Validating += new System.ComponentModel.CancelEventHandler(this.mtextID_Validating);
            // 
            // lblTopLine1
            // 
            this.lblTopLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblTopLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLine1.ForeColor = System.Drawing.Color.White;
            this.lblTopLine1.Location = new System.Drawing.Point(0, 0);
            this.lblTopLine1.Name = "lblTopLine1";
            this.lblTopLine1.Size = new System.Drawing.Size(551, 13);
            this.lblTopLine1.TabIndex = 16;
            this.lblTopLine1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTopLine2
            // 
            this.lblTopLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopLine2.BackColor = System.Drawing.Color.White;
            this.lblTopLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLine2.ForeColor = System.Drawing.Color.White;
            this.lblTopLine2.Location = new System.Drawing.Point(0, 13);
            this.lblTopLine2.Name = "lblTopLine2";
            this.lblTopLine2.Size = new System.Drawing.Size(551, 8);
            this.lblTopLine2.TabIndex = 17;
            this.lblTopLine2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelFormTitle
            // 
            this.panelFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFormTitle.Controls.Add(this.mtext);
            this.panelFormTitle.Controls.Add(this.lblTopLine3);
            this.panelFormTitle.Controls.Add(this.lblTopLine1);
            this.panelFormTitle.Controls.Add(this.lblTopLine2);
            this.panelFormTitle.Controls.Add(this.lblFormTitle);
            this.panelFormTitle.Location = new System.Drawing.Point(0, 0);
            this.panelFormTitle.Name = "panelFormTitle";
            this.panelFormTitle.Size = new System.Drawing.Size(551, 67);
            this.panelFormTitle.TabIndex = 18;
            // 
            // mtext
            // 
            this.mtext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtext.Location = new System.Drawing.Point(4, 26);
            this.mtext.Name = "mtext";
            this.mtext.Size = new System.Drawing.Size(13, 20);
            this.mtext.TabIndex = 20;
            this.toolTipSDI.SetToolTip(this.mtext, "ID or Code Number. Only Numeric characters allowed. Format: ");
            this.mtext.Visible = false;
            // 
            // lblTopLine3
            // 
            this.lblTopLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopLine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(222)))));
            this.lblTopLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLine3.ForeColor = System.Drawing.Color.White;
            this.lblTopLine3.Location = new System.Drawing.Point(3, 56);
            this.lblTopLine3.Name = "lblTopLine3";
            this.lblTopLine3.Size = new System.Drawing.Size(552, 8);
            this.lblTopLine3.TabIndex = 19;
            this.lblTopLine3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblBottomLine1
            // 
            this.lblBottomLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBottomLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.lblBottomLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomLine1.ForeColor = System.Drawing.Color.White;
            this.lblBottomLine1.Location = new System.Drawing.Point(-1, 269);
            this.lblBottomLine1.Name = "lblBottomLine1";
            this.lblBottomLine1.Size = new System.Drawing.Size(552, 8);
            this.lblBottomLine1.TabIndex = 20;
            this.lblBottomLine1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLblStatusTitle,
            this.toolStripStatuslblStatusText,
            this.toolStripStatuslblTotal,
            this.toolStripStatuslblTotalText,
            this.toolStripStatuslblAlertTitle,
            this.textAlert});
            this.statusStrip1.Location = new System.Drawing.Point(0, 277);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(551, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLblStatusTitle
            // 
            this.toolStripStatusLblStatusTitle.Name = "toolStripStatusLblStatusTitle";
            this.toolStripStatusLblStatusTitle.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLblStatusTitle.Text = "Status:";
            this.toolStripStatusLblStatusTitle.ToolTipText = "Status of this form: Read = Ready to Accept ID, New = ID is new, Modify = Updatin" +
    "g/Modifying an existing ID\' s data";
            // 
            // toolStripStatuslblStatusText
            // 
            this.toolStripStatuslblStatusText.AutoSize = false;
            this.toolStripStatuslblStatusText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatuslblStatusText.ForeColor = System.Drawing.Color.Teal;
            this.toolStripStatuslblStatusText.Name = "toolStripStatuslblStatusText";
            this.toolStripStatuslblStatusText.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatuslblStatusText.Text = "Ready";
            this.toolStripStatuslblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatuslblTotal
            // 
            this.toolStripStatuslblTotal.Name = "toolStripStatuslblTotal";
            this.toolStripStatuslblTotal.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatuslblTotal.Text = "Total :";
            this.toolStripStatuslblTotal.ToolTipText = "Total Number of Records already saved";
            // 
            // toolStripStatuslblTotalText
            // 
            this.toolStripStatuslblTotalText.AutoSize = false;
            this.toolStripStatuslblTotalText.ForeColor = System.Drawing.Color.Teal;
            this.toolStripStatuslblTotalText.Name = "toolStripStatuslblTotalText";
            this.toolStripStatuslblTotalText.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatuslblTotalText.Text = "0";
            this.toolStripStatuslblTotalText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatuslblAlertTitle
            // 
            this.toolStripStatuslblAlertTitle.AutoSize = false;
            this.toolStripStatuslblAlertTitle.Name = "toolStripStatuslblAlertTitle";
            this.toolStripStatuslblAlertTitle.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatuslblAlertTitle.Text = "Alert :";
            this.toolStripStatuslblAlertTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatuslblAlertTitle.Click += new System.EventHandler(this.toolStripStatuslblAlertTitle_Click);
            // 
            // textAlert
            // 
            this.textAlert.AutoSize = false;
            this.textAlert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.textAlert.Name = "textAlert";
            this.textAlert.Size = new System.Drawing.Size(250, 17);
            this.textAlert.Text = "Ready";
            this.textAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mtextOrdering
            // 
            this.mtextOrdering.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtextOrdering.Location = new System.Drawing.Point(94, 154);
            this.mtextOrdering.Name = "mtextOrdering";
            this.mtextOrdering.Size = new System.Drawing.Size(88, 20);
            this.mtextOrdering.TabIndex = 3;
            this.toolTipSDI.SetToolTip(this.mtextOrdering, "Ordering Or Sequence: Priority to appear in View/Combo Box, Only Numeric characte" +
        "rs allowed. Format: ");
            // 
            // mtextGLID
            // 
            this.mtextGLID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtextGLID.Location = new System.Drawing.Point(94, 179);
            this.mtextGLID.Name = "mtextGLID";
            this.mtextGLID.Size = new System.Drawing.Size(140, 20);
            this.mtextGLID.TabIndex = 4;
            this.toolTipSDI.SetToolTip(this.mtextGLID, "ID or Code Number. Only Numeric characters allowed. Format: ");
            this.mtextGLID.DoubleClick += new System.EventHandler(this.mtFromID_DoubleClick);
            this.mtextGLID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtextGLID_KeyDown);
            this.mtextGLID.Validating += new System.ComponentModel.CancelEventHandler(this.mtFromID_Validating);
            // 
            // lblOrdering
            // 
            this.lblOrdering.AutoSize = true;
            this.lblOrdering.Location = new System.Drawing.Point(35, 159);
            this.lblOrdering.Name = "lblOrdering";
            this.lblOrdering.Size = new System.Drawing.Size(53, 13);
            this.lblOrdering.TabIndex = 24;
            this.lblOrdering.Text = "Ordering :";
            // 
            // lblFromID
            // 
            this.lblFromID.AutoSize = true;
            this.lblFromID.Location = new System.Drawing.Point(47, 186);
            this.lblFromID.Name = "lblFromID";
            this.lblFromID.Size = new System.Drawing.Size(41, 13);
            this.lblFromID.TabIndex = 26;
            this.lblFromID.Text = "GL ID :";
            // 
            // lblAcTitle
            // 
            this.lblAcTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAcTitle.Location = new System.Drawing.Point(247, 179);
            this.lblAcTitle.Name = "lblAcTitle";
            this.lblAcTitle.Size = new System.Drawing.Size(292, 20);
            this.lblAcTitle.TabIndex = 27;
            // 
            // frmGodown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(551, 299);
            this.ContextMenuStrip = this.contextMenuStripSDI_Master;
            this.Controls.Add(this.lblAcTitle);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.mtextOrdering);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.panelFormTitle);
            this.Controls.Add(this.lblFromID);
            this.Controls.Add(this.mtextGLID);
            this.Controls.Add(this.lblOrdering);
            this.Controls.Add(this.toolStripSDI_Master);
            this.Controls.Add(this.mtextID);
            this.Controls.Add(this.lblBottomLine1);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.textST);
            this.Controls.Add(this.chkIsDisabled);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblST);
            this.Controls.Add(this.chkIsDefault);
            this.KeyPreview = true;
            this.Name = "frmGodown";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSDI_Master_FormClosing);
            this.Load += new System.EventHandler(this.frmSDI_Master_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSDI_Master_KeyDown);
            this.toolStripSDI_Master.ResumeLayout(false);
            this.toolStripSDI_Master.PerformLayout();
            this.panelFormTitle.ResumeLayout(false);
            this.panelFormTitle.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btn_Save;
    private System.Windows.Forms.Button btn_Clear;
    private System.Windows.Forms.Button btn_Delete;
    private System.Windows.Forms.Button btn_Exit;
    private System.Windows.Forms.Label lblFormTitle;
    private System.Windows.Forms.Label lblID;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblST;
    private System.Windows.Forms.TextBox textTitle;
    private System.Windows.Forms.TextBox textST;
    private System.Windows.Forms.ContextMenuStrip contextMenuStripSDI_Master;
    private System.Windows.Forms.ToolStrip toolStripSDI_Master;
    private System.Windows.Forms.ToolStripLabel toolStripMenuItemSDI_Master1;
    private System.Windows.Forms.ToolStripLabel toolStripMenuItemSDI_Master2;
    private System.Windows.Forms.CheckBox chkIsDisabled;
    private System.Windows.Forms.CheckBox chkIsDefault;
    private System.Windows.Forms.MaskedTextBox mtextID;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label lblTopLine1;
    private System.Windows.Forms.Label lblTopLine2;
    private System.Windows.Forms.Panel panelFormTitle;
    private System.Windows.Forms.Label lblTopLine3;
    private System.Windows.Forms.Label lblBottomLine1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblStatusTitle;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslblStatusText;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslblTotal;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslblTotalText;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslblAlertTitle;
    private System.Windows.Forms.ToolStripStatusLabel textAlert;
    private System.Windows.Forms.ToolTip toolTipSDI;
    private System.Windows.Forms.Label lblOrdering;
    private System.Windows.Forms.MaskedTextBox mtextOrdering;
    private System.Windows.Forms.MaskedTextBox mtextGLID;
    private System.Windows.Forms.Label lblFromID;
    private System.Windows.Forms.Label lblAcTitle;
    private System.Windows.Forms.MaskedTextBox mtext;
  }
}