namespace TaxSolution
{
  partial class frmAddress_Master
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btn_SaveNExit = new System.Windows.Forms.Button();
            this.contextMenuStripSDI_Master = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSDI_Master = new System.Windows.Forms.ToolStrip();
            this.toolStripMenuItemSDI_Master1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripMenuItemSDI_Master2 = new System.Windows.Forms.ToolStripLabel();
            this.chkIsDefault = new System.Windows.Forms.CheckBox();
            this.lblTopLine1 = new System.Windows.Forms.Label();
            this.lblTopLine2 = new System.Windows.Forms.Label();
            this.panelFormTitle = new System.Windows.Forms.Panel();
            this.lblTopLine3 = new System.Windows.Forms.Label();
            this.mtextID = new System.Windows.Forms.MaskedTextBox();
            this.lblBottomLine1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLblStatusTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblTotalText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblAlertTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblAlertText = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelOptionalButton = new System.Windows.Forms.Panel();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.lblContactPerson = new System.Windows.Forms.Label();
            this.textContactPerson = new System.Windows.Forms.TextBox();
            this.cboSalutation = new System.Windows.Forms.ComboBox();
            this.textAddress1 = new System.Windows.Forms.TextBox();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.textAddress2 = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.tabAddress = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboAddrType = new System.Windows.Forms.ComboBox();
            this.lblAddressType = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.lblProvince = new System.Windows.Forms.Label();
            this.textZip = new System.Windows.Forms.TextBox();
            this.lblZip = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textWeb = new System.Windows.Forms.TextBox();
            this.lblWeb = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.textFax = new System.Windows.Forms.TextBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.textMobile = new System.Windows.Forms.TextBox();
            this.lblCell = new System.Windows.Forms.Label();
            this.textExt = new System.Windows.Forms.TextBox();
            this.lblExt = new System.Windows.Forms.Label();
            this.textPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.mtextOrdering = new System.Windows.Forms.MaskedTextBox();
            this.lblOrdering = new System.Windows.Forms.Label();
            this.textAddressRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.textAddressRef = new System.Windows.Forms.TextBox();
            this.lblAddressRef = new System.Windows.Forms.Label();
            this.chkIsDisabled = new System.Windows.Forms.CheckBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.dGVAddress = new System.Windows.Forms.DataGridView();
            this.toolTipAddress = new System.Windows.Forms.ToolTip(this.components);
            this.lblTAddrUID = new System.Windows.Forms.Label();
            this.panelBottom.SuspendLayout();
            this.toolStripSDI_Master.SuspendLayout();
            this.panelFormTitle.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelOptionalButton.SuspendLayout();
            this.tabAddress.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(102, 11);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(60, 26);
            this.btn_Save.TabIndex = 1;
            this.btn_Save.Text = "&Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(142, 11);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(60, 26);
            this.btn_Clear.TabIndex = 2;
            this.btn_Clear.Text = "&Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Visible = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(223, 11);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(60, 26);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Exit.Location = new System.Drawing.Point(168, 11);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(60, 26);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Text = "E&xit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblFormTitle.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblFormTitle.Location = new System.Drawing.Point(316, 21);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(204, 35);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Address";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.Controls.Add(this.btn_SaveNExit);
            this.panelBottom.Controls.Add(this.btn_Save);
            this.panelBottom.Controls.Add(this.btn_Exit);
            this.panelBottom.Location = new System.Drawing.Point(292, 360);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(244, 40);
            this.panelBottom.TabIndex = 5;
            // 
            // btn_SaveNExit
            // 
            this.btn_SaveNExit.Location = new System.Drawing.Point(15, 11);
            this.btn_SaveNExit.Name = "btn_SaveNExit";
            this.btn_SaveNExit.Size = new System.Drawing.Size(81, 26);
            this.btn_SaveNExit.TabIndex = 0;
            this.btn_SaveNExit.Text = "Save &Exit ";
            this.btn_SaveNExit.UseVisualStyleBackColor = true;
            this.btn_SaveNExit.Click += new System.EventHandler(this.btn_SaveNExit_Click);
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
            this.toolStripSDI_Master.Size = new System.Drawing.Size(532, 25);
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
            // chkIsDefault
            // 
            this.chkIsDefault.AutoSize = true;
            this.chkIsDefault.Enabled = false;
            this.chkIsDefault.Location = new System.Drawing.Point(115, 108);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Size = new System.Drawing.Size(81, 17);
            this.chkIsDefault.TabIndex = 6;
            this.chkIsDefault.Text = "Is Default";
            this.chkIsDefault.UseVisualStyleBackColor = true;
            // 
            // lblTopLine1
            // 
            this.lblTopLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblTopLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLine1.ForeColor = System.Drawing.Color.White;
            this.lblTopLine1.Location = new System.Drawing.Point(0, 0);
            this.lblTopLine1.Name = "lblTopLine1";
            this.lblTopLine1.Size = new System.Drawing.Size(532, 13);
            this.lblTopLine1.TabIndex = 16;
            this.lblTopLine1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTopLine2
            // 
            this.lblTopLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(179)))), ((int)(((byte)(64)))));
            this.lblTopLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLine2.ForeColor = System.Drawing.Color.White;
            this.lblTopLine2.Location = new System.Drawing.Point(0, 13);
            this.lblTopLine2.Name = "lblTopLine2";
            this.lblTopLine2.Size = new System.Drawing.Size(532, 12);
            this.lblTopLine2.TabIndex = 17;
            this.lblTopLine2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelFormTitle
            // 
            this.panelFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFormTitle.Controls.Add(this.lblTopLine3);
            this.panelFormTitle.Controls.Add(this.lblTopLine1);
            this.panelFormTitle.Controls.Add(this.lblTopLine2);
            this.panelFormTitle.Controls.Add(this.lblFormTitle);
            this.panelFormTitle.Controls.Add(this.mtextID);
            this.panelFormTitle.Location = new System.Drawing.Point(0, 0);
            this.panelFormTitle.Name = "panelFormTitle";
            this.panelFormTitle.Size = new System.Drawing.Size(532, 67);
            this.panelFormTitle.TabIndex = 18;
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
            this.lblTopLine3.Size = new System.Drawing.Size(533, 8);
            this.lblTopLine3.TabIndex = 19;
            this.lblTopLine3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mtextID
            // 
            this.mtextID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtextID.Location = new System.Drawing.Point(12, 29);
            this.mtextID.Name = "mtextID";
            this.mtextID.Size = new System.Drawing.Size(24, 20);
            this.mtextID.TabIndex = 0;
            this.mtextID.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtextID_MaskInputRejected);
            this.mtextID.Enter += new System.EventHandler(this.mtextID_Enter);
            this.mtextID.Validating += new System.ComponentModel.CancelEventHandler(this.mtextID_Validating);
            // 
            // lblBottomLine1
            // 
            this.lblBottomLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBottomLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.lblBottomLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomLine1.ForeColor = System.Drawing.Color.Transparent;
            this.lblBottomLine1.Location = new System.Drawing.Point(-1, 403);
            this.lblBottomLine1.Name = "lblBottomLine1";
            this.lblBottomLine1.Size = new System.Drawing.Size(533, 8);
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
            this.toolStripStatuslblAlertText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 411);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(532, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLblStatusTitle
            // 
            this.toolStripStatusLblStatusTitle.Name = "toolStripStatusLblStatusTitle";
            this.toolStripStatusLblStatusTitle.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLblStatusTitle.Text = "Status:";
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
            // toolStripStatuslblAlertText
            // 
            this.toolStripStatuslblAlertText.AutoSize = false;
            this.toolStripStatuslblAlertText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatuslblAlertText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.toolStripStatuslblAlertText.Name = "toolStripStatuslblAlertText";
            this.toolStripStatuslblAlertText.Size = new System.Drawing.Size(250, 17);
            this.toolStripStatuslblAlertText.Text = "Ready";
            this.toolStripStatuslblAlertText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOptionalButton
            // 
            this.panelOptionalButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelOptionalButton.Controls.Add(this.btn_Clear);
            this.panelOptionalButton.Controls.Add(this.btn_Delete);
            this.panelOptionalButton.Controls.Add(this.btn_Modify);
            this.panelOptionalButton.Controls.Add(this.btn_New);
            this.panelOptionalButton.Location = new System.Drawing.Point(0, 360);
            this.panelOptionalButton.Name = "panelOptionalButton";
            this.panelOptionalButton.Size = new System.Drawing.Size(286, 40);
            this.panelOptionalButton.TabIndex = 22;
            // 
            // btn_Modify
            // 
            this.btn_Modify.Location = new System.Drawing.Point(76, 11);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(60, 26);
            this.btn_Modify.TabIndex = 1;
            this.btn_Modify.Text = "&Modify";
            this.btn_Modify.UseVisualStyleBackColor = true;
            this.btn_Modify.Visible = false;
            // 
            // btn_New
            // 
            this.btn_New.Location = new System.Drawing.Point(10, 11);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(60, 26);
            this.btn_New.TabIndex = 0;
            this.btn_New.Text = "&New";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Visible = false;
            // 
            // lblContactPerson
            // 
            this.lblContactPerson.Location = new System.Drawing.Point(20, 42);
            this.lblContactPerson.Name = "lblContactPerson";
            this.lblContactPerson.Size = new System.Drawing.Size(102, 13);
            this.lblContactPerson.TabIndex = 2;
            this.lblContactPerson.Text = "Contact Person :";
            this.lblContactPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textContactPerson
            // 
            this.textContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textContactPerson.Location = new System.Drawing.Point(203, 40);
            this.textContactPerson.Name = "textContactPerson";
            this.textContactPerson.Size = new System.Drawing.Size(301, 20);
            this.textContactPerson.TabIndex = 4;
            // 
            // cboSalutation
            // 
            this.cboSalutation.FormattingEnabled = true;
            this.cboSalutation.Location = new System.Drawing.Point(128, 39);
            this.cboSalutation.Name = "cboSalutation";
            this.cboSalutation.Size = new System.Drawing.Size(69, 21);
            this.cboSalutation.TabIndex = 3;
            // 
            // textAddress1
            // 
            this.textAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAddress1.Location = new System.Drawing.Point(127, 66);
            this.textAddress1.Name = "textAddress1";
            this.textAddress1.Size = new System.Drawing.Size(377, 20);
            this.textAddress1.TabIndex = 6;
            // 
            // lblAddress1
            // 
            this.lblAddress1.Location = new System.Drawing.Point(20, 68);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(102, 13);
            this.lblAddress1.TabIndex = 5;
            this.lblAddress1.Text = "Address Line 1 :";
            this.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textAddress2
            // 
            this.textAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAddress2.Location = new System.Drawing.Point(127, 92);
            this.textAddress2.Name = "textAddress2";
            this.textAddress2.Size = new System.Drawing.Size(377, 20);
            this.textAddress2.TabIndex = 8;
            // 
            // lblAddress2
            // 
            this.lblAddress2.Location = new System.Drawing.Point(20, 94);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(102, 13);
            this.lblAddress2.TabIndex = 7;
            this.lblAddress2.Text = "Address Line 2 :";
            this.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCity
            // 
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(127, 145);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(135, 21);
            this.cboCity.TabIndex = 12;
            // 
            // lblCity
            // 
            this.lblCity.Location = new System.Drawing.Point(20, 148);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(102, 13);
            this.lblCity.TabIndex = 11;
            this.lblCity.Text = "City :";
            this.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCountry
            // 
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(128, 118);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(134, 21);
            this.cboCountry.TabIndex = 10;
            this.cboCountry.SelectedIndexChanged += new System.EventHandler(this.cboCountry_SelectedIndexChanged);
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(20, 121);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(102, 13);
            this.lblCountry.TabIndex = 9;
            this.lblCountry.Text = "Country :";
            this.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabAddress
            // 
            this.tabAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabAddress.Controls.Add(this.tabPage1);
            this.tabAddress.Controls.Add(this.tabPage2);
            this.tabAddress.Controls.Add(this.tabPage3);
            this.tabAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabAddress.Location = new System.Drawing.Point(0, 100);
            this.tabAddress.Name = "tabAddress";
            this.tabAddress.SelectedIndex = 0;
            this.tabAddress.Size = new System.Drawing.Size(530, 204);
            this.tabAddress.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(222)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.cboAddrType);
            this.tabPage1.Controls.Add(this.lblAddressType);
            this.tabPage1.Controls.Add(this.cboState);
            this.tabPage1.Controls.Add(this.lblProvince);
            this.tabPage1.Controls.Add(this.textZip);
            this.tabPage1.Controls.Add(this.lblZip);
            this.tabPage1.Controls.Add(this.cboCountry);
            this.tabPage1.Controls.Add(this.lblContactPerson);
            this.tabPage1.Controls.Add(this.lblCountry);
            this.tabPage1.Controls.Add(this.textContactPerson);
            this.tabPage1.Controls.Add(this.cboCity);
            this.tabPage1.Controls.Add(this.cboSalutation);
            this.tabPage1.Controls.Add(this.lblCity);
            this.tabPage1.Controls.Add(this.lblAddress1);
            this.tabPage1.Controls.Add(this.textAddress2);
            this.tabPage1.Controls.Add(this.textAddress1);
            this.tabPage1.Controls.Add(this.lblAddress2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(522, 178);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Address";
            // 
            // cboAddrType
            // 
            this.cboAddrType.FormattingEnabled = true;
            this.cboAddrType.Location = new System.Drawing.Point(128, 15);
            this.cboAddrType.Name = "cboAddrType";
            this.cboAddrType.Size = new System.Drawing.Size(134, 21);
            this.cboAddrType.TabIndex = 1;
            // 
            // lblAddressType
            // 
            this.lblAddressType.Location = new System.Drawing.Point(20, 18);
            this.lblAddressType.Name = "lblAddressType";
            this.lblAddressType.Size = new System.Drawing.Size(102, 13);
            this.lblAddressType.TabIndex = 0;
            this.lblAddressType.Text = "Address Type :";
            this.lblAddressType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboState
            // 
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(369, 118);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(135, 21);
            this.cboState.TabIndex = 14;
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.cboState_SelectedIndexChanged);
            // 
            // lblProvince
            // 
            this.lblProvince.Location = new System.Drawing.Point(275, 121);
            this.lblProvince.Name = "lblProvince";
            this.lblProvince.Size = new System.Drawing.Size(88, 13);
            this.lblProvince.TabIndex = 13;
            this.lblProvince.Text = "State/Province :";
            this.lblProvince.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textZip
            // 
            this.textZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textZip.Location = new System.Drawing.Point(369, 146);
            this.textZip.Name = "textZip";
            this.textZip.Size = new System.Drawing.Size(135, 20);
            this.textZip.TabIndex = 16;
            // 
            // lblZip
            // 
            this.lblZip.Location = new System.Drawing.Point(268, 148);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(95, 13);
            this.lblZip.TabIndex = 15;
            this.lblZip.Text = "Zip/Postal Code :";
            this.lblZip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(222)))));
            this.tabPage2.Controls.Add(this.textWeb);
            this.tabPage2.Controls.Add(this.lblWeb);
            this.tabPage2.Controls.Add(this.textEmail);
            this.tabPage2.Controls.Add(this.lblEmail);
            this.tabPage2.Controls.Add(this.textFax);
            this.tabPage2.Controls.Add(this.lblFax);
            this.tabPage2.Controls.Add(this.textMobile);
            this.tabPage2.Controls.Add(this.lblCell);
            this.tabPage2.Controls.Add(this.textExt);
            this.tabPage2.Controls.Add(this.lblExt);
            this.tabPage2.Controls.Add(this.textPhone);
            this.tabPage2.Controls.Add(this.lblPhone);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(522, 178);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contact No.";
            // 
            // textWeb
            // 
            this.textWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textWeb.Location = new System.Drawing.Point(103, 103);
            this.textWeb.Name = "textWeb";
            this.textWeb.Size = new System.Drawing.Size(377, 20);
            this.textWeb.TabIndex = 48;
            // 
            // lblWeb
            // 
            this.lblWeb.Location = new System.Drawing.Point(2, 105);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(95, 13);
            this.lblWeb.TabIndex = 47;
            this.lblWeb.Text = "Web/URL :";
            this.lblWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textEmail
            // 
            this.textEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textEmail.Location = new System.Drawing.Point(103, 77);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(377, 20);
            this.textEmail.TabIndex = 46;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(2, 79);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(95, 13);
            this.lblEmail.TabIndex = 45;
            this.lblEmail.Text = "Email :";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textFax
            // 
            this.textFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textFax.Location = new System.Drawing.Point(345, 53);
            this.textFax.Name = "textFax";
            this.textFax.Size = new System.Drawing.Size(135, 20);
            this.textFax.TabIndex = 44;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(244, 55);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(95, 13);
            this.lblFax.TabIndex = 43;
            this.lblFax.Text = "Fax :";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textMobile
            // 
            this.textMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textMobile.Location = new System.Drawing.Point(103, 51);
            this.textMobile.Name = "textMobile";
            this.textMobile.Size = new System.Drawing.Size(135, 20);
            this.textMobile.TabIndex = 42;
            // 
            // lblCell
            // 
            this.lblCell.Location = new System.Drawing.Point(2, 53);
            this.lblCell.Name = "lblCell";
            this.lblCell.Size = new System.Drawing.Size(95, 13);
            this.lblCell.TabIndex = 41;
            this.lblCell.Text = "Cell / Mobile :";
            this.lblCell.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textExt
            // 
            this.textExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textExt.Location = new System.Drawing.Point(345, 25);
            this.textExt.Name = "textExt";
            this.textExt.Size = new System.Drawing.Size(135, 20);
            this.textExt.TabIndex = 40;
            // 
            // lblExt
            // 
            this.lblExt.Location = new System.Drawing.Point(244, 27);
            this.lblExt.Name = "lblExt";
            this.lblExt.Size = new System.Drawing.Size(95, 13);
            this.lblExt.TabIndex = 39;
            this.lblExt.Text = "Ext :";
            this.lblExt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textPhone
            // 
            this.textPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPhone.Location = new System.Drawing.Point(103, 25);
            this.textPhone.Name = "textPhone";
            this.textPhone.Size = new System.Drawing.Size(135, 20);
            this.textPhone.TabIndex = 38;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(2, 27);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(95, 13);
            this.lblPhone.TabIndex = 37;
            this.lblPhone.Text = "Phone :";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(222)))));
            this.tabPage3.Controls.Add(this.mtextOrdering);
            this.tabPage3.Controls.Add(this.lblOrdering);
            this.tabPage3.Controls.Add(this.textAddressRemarks);
            this.tabPage3.Controls.Add(this.lblRemarks);
            this.tabPage3.Controls.Add(this.textAddressRef);
            this.tabPage3.Controls.Add(this.lblAddressRef);
            this.tabPage3.Controls.Add(this.chkIsDisabled);
            this.tabPage3.Controls.Add(this.chkIsDefault);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(522, 178);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Status";
            // 
            // mtextOrdering
            // 
            this.mtextOrdering.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtextOrdering.Location = new System.Drawing.Point(115, 82);
            this.mtextOrdering.Mask = "0";
            this.mtextOrdering.Name = "mtextOrdering";
            this.mtextOrdering.Size = new System.Drawing.Size(88, 20);
            this.mtextOrdering.TabIndex = 5;
            // 
            // lblOrdering
            // 
            this.lblOrdering.Location = new System.Drawing.Point(14, 84);
            this.lblOrdering.Name = "lblOrdering";
            this.lblOrdering.Size = new System.Drawing.Size(95, 13);
            this.lblOrdering.TabIndex = 4;
            this.lblOrdering.Text = "Ordering :";
            this.lblOrdering.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textAddressRemarks
            // 
            this.textAddressRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAddressRemarks.Location = new System.Drawing.Point(115, 57);
            this.textAddressRemarks.Name = "textAddressRemarks";
            this.textAddressRemarks.Size = new System.Drawing.Size(368, 20);
            this.textAddressRemarks.TabIndex = 3;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(14, 59);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(95, 13);
            this.lblRemarks.TabIndex = 2;
            this.lblRemarks.Text = "Remarks :";
            this.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textAddressRef
            // 
            this.textAddressRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textAddressRef.Location = new System.Drawing.Point(115, 31);
            this.textAddressRef.Name = "textAddressRef";
            this.textAddressRef.Size = new System.Drawing.Size(368, 20);
            this.textAddressRef.TabIndex = 1;
            // 
            // lblAddressRef
            // 
            this.lblAddressRef.Location = new System.Drawing.Point(14, 33);
            this.lblAddressRef.Name = "lblAddressRef";
            this.lblAddressRef.Size = new System.Drawing.Size(95, 13);
            this.lblAddressRef.TabIndex = 0;
            this.lblAddressRef.Text = "Address Ref. :";
            this.lblAddressRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsDisabled
            // 
            this.chkIsDisabled.AutoSize = true;
            this.chkIsDisabled.Location = new System.Drawing.Point(115, 126);
            this.chkIsDisabled.Name = "chkIsDisabled";
            this.chkIsDisabled.Size = new System.Drawing.Size(89, 17);
            this.chkIsDisabled.TabIndex = 7;
            this.chkIsDisabled.Text = "Is Disabled";
            this.chkIsDisabled.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Navy;
            this.lblTitle.Location = new System.Drawing.Point(99, 72);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(428, 20);
            this.lblTitle.TabIndex = 38;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblID
            // 
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(0, 72);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(93, 20);
            this.lblID.TabIndex = 39;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dGVAddress
            // 
            this.dGVAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVAddress.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(222)))));
            this.dGVAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVAddress.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(222)))));
            this.dGVAddress.Location = new System.Drawing.Point(3, 308);
            this.dGVAddress.Margin = new System.Windows.Forms.Padding(1);
            this.dGVAddress.Name = "dGVAddress";
            this.dGVAddress.RowHeadersVisible = false;
            this.dGVAddress.Size = new System.Drawing.Size(529, 11);
            this.dGVAddress.TabIndex = 40;
            // 
            // lblTAddrUID
            // 
            this.lblTAddrUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTAddrUID.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTAddrUID.Location = new System.Drawing.Point(3, 325);
            this.lblTAddrUID.Name = "lblTAddrUID";
            this.lblTAddrUID.Size = new System.Drawing.Size(125, 22);
            this.lblTAddrUID.TabIndex = 71;
            this.lblTAddrUID.Text = "0";
            this.lblTAddrUID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmAddress_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(532, 433);
            this.ContextMenuStrip = this.contextMenuStripSDI_Master;
            this.Controls.Add(this.lblTAddrUID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.dGVAddress);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelOptionalButton);
            this.Controls.Add(this.tabAddress);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelFormTitle);
            this.Controls.Add(this.toolStripSDI_Master);
            this.Controls.Add(this.lblBottomLine1);
            this.Controls.Add(this.panelBottom);
            this.KeyPreview = true;
            this.Name = "frmAddress_Master";
            this.Text = "frmAddress_Master";
            this.Load += new System.EventHandler(this.frmAddress_Master_Load);
            this.panelBottom.ResumeLayout(false);
            this.toolStripSDI_Master.ResumeLayout(false);
            this.toolStripSDI_Master.PerformLayout();
            this.panelFormTitle.ResumeLayout(false);
            this.panelFormTitle.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelOptionalButton.ResumeLayout(false);
            this.tabAddress.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btn_Save;
    private System.Windows.Forms.Button btn_Clear;
    private System.Windows.Forms.Button btn_Delete;
    private System.Windows.Forms.Button btn_Exit;
    private System.Windows.Forms.Label lblFormTitle;
    private System.Windows.Forms.Panel panelBottom;
    private System.Windows.Forms.ContextMenuStrip contextMenuStripSDI_Master;
    private System.Windows.Forms.ToolStrip toolStripSDI_Master;
    private System.Windows.Forms.ToolStripLabel toolStripMenuItemSDI_Master1;
    private System.Windows.Forms.ToolStripLabel toolStripMenuItemSDI_Master2;
    private System.Windows.Forms.CheckBox chkIsDefault;
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
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslblAlertText;
    private System.Windows.Forms.Panel panelOptionalButton;
    private System.Windows.Forms.MaskedTextBox mtextID;
    private System.Windows.Forms.Label lblContactPerson;
    private System.Windows.Forms.TextBox textContactPerson;
    private System.Windows.Forms.ComboBox cboSalutation;
    private System.Windows.Forms.TextBox textAddress1;
    private System.Windows.Forms.Label lblAddress1;
    private System.Windows.Forms.TextBox textAddress2;
    private System.Windows.Forms.Label lblAddress2;
    private System.Windows.Forms.ComboBox cboCity;
    private System.Windows.Forms.Label lblCity;
    private System.Windows.Forms.ComboBox cboCountry;
    private System.Windows.Forms.Label lblCountry;
    private System.Windows.Forms.TabControl tabAddress;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.ComboBox cboState;
    private System.Windows.Forms.Label lblProvince;
    private System.Windows.Forms.TextBox textZip;
    private System.Windows.Forms.Label lblZip;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TextBox textExt;
    private System.Windows.Forms.Label lblExt;
    private System.Windows.Forms.TextBox textPhone;
    private System.Windows.Forms.Label lblPhone;
    private System.Windows.Forms.TextBox textWeb;
    private System.Windows.Forms.Label lblWeb;
    private System.Windows.Forms.TextBox textEmail;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox textFax;
    private System.Windows.Forms.Label lblFax;
    private System.Windows.Forms.TextBox textMobile;
    private System.Windows.Forms.Label lblCell;
    private System.Windows.Forms.TabPage tabPage3;
    private System.Windows.Forms.TextBox textAddressRemarks;
    private System.Windows.Forms.Label lblRemarks;
    private System.Windows.Forms.TextBox textAddressRef;
    private System.Windows.Forms.Label lblAddressRef;
    private System.Windows.Forms.CheckBox chkIsDisabled;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblID;
    private System.Windows.Forms.DataGridView dGVAddress;
    private System.Windows.Forms.ToolTip toolTipAddress;
    private System.Windows.Forms.Button btn_New;
    private System.Windows.Forms.Button btn_Modify;
    private System.Windows.Forms.Label lblOrdering;
    private System.Windows.Forms.MaskedTextBox mtextOrdering;
    private System.Windows.Forms.ComboBox cboAddrType;
    private System.Windows.Forms.Label lblAddressType;
    private System.Windows.Forms.Button btn_SaveNExit;
    private System.Windows.Forms.Label lblTAddrUID;
  }
}