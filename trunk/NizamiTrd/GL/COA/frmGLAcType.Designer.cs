namespace TestFormApp.GL.COA
{
    partial class frmGLAcType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGLAcType));
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
            this.panelBottom = new System.Windows.Forms.Panel();
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
            this.lblTopLine3 = new System.Windows.Forms.Label();
            this.lblBottomLine1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLblStatusTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblTotalText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblAlertTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatuslblAlertText = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelOptionalButton = new System.Windows.Forms.Panel();
            this.toolTipSDI = new System.Windows.Forms.ToolTip(this.components);
            this.mtextOrdering = new System.Windows.Forms.MaskedTextBox();
            this.lblOrdering = new System.Windows.Forms.Label();
            this.gBAcNature = new System.Windows.Forms.GroupBox();
            this.rBtn_BalanceSheet = new System.Windows.Forms.RadioButton();
            this.rBtn_Revenue = new System.Windows.Forms.RadioButton();
            this.gBBalanceSide = new System.Windows.Forms.GroupBox();
            this.rBtn_Credit = new System.Windows.Forms.RadioButton();
            this.rBtn_Debit = new System.Windows.Forms.RadioButton();
            this.panelBottom.SuspendLayout();
            this.toolStripSDI_Master.SuspendLayout();
            this.panelFormTitle.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gBAcNature.SuspendLayout();
            this.gBBalanceSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(37, 11);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(60, 26);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "&Save";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_Clear.Image")));
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(103, 11);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(60, 26);
            this.btn_Clear.TabIndex = 1;
            this.btn_Clear.Text = "&Clear";
            this.btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("btn_Delete.Image")));
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.Location = new System.Drawing.Point(169, 11);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(60, 26);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(254, 11);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(60, 26);
            this.btn_Exit.TabIndex = 3;
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
            this.lblFormTitle.Size = new System.Drawing.Size(223, 35);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Form ID";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(61, 75);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 7;
            this.lblID.Text = "ID :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(52, 101);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(33, 13);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Title :";
            // 
            // lblST
            // 
            this.lblST.AutoSize = true;
            this.lblST.Location = new System.Drawing.Point(24, 127);
            this.lblST.Name = "lblST";
            this.lblST.Size = new System.Drawing.Size(61, 13);
            this.lblST.TabIndex = 9;
            this.lblST.Text = "Short Title :";
            // 
            // textTitle
            // 
            this.textTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTitle.Location = new System.Drawing.Point(91, 99);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(317, 20);
            this.textTitle.TabIndex = 1;
            this.toolTipSDI.SetToolTip(this.textTitle, "Title or Name Alphanumeric characters Max Length =");
            // 
            // textST
            // 
            this.textST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textST.Location = new System.Drawing.Point(91, 125);
            this.textST.Name = "textST";
            this.textST.Size = new System.Drawing.Size(88, 20);
            this.textST.TabIndex = 2;
            this.toolTipSDI.SetToolTip(this.textST, "Short Name Alphanumeric Charactrs Max Length =");
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.Controls.Add(this.btn_Clear);
            this.panelBottom.Controls.Add(this.btn_Save);
            this.panelBottom.Controls.Add(this.btn_Delete);
            this.panelBottom.Controls.Add(this.btn_Exit);
            this.panelBottom.Location = new System.Drawing.Point(225, 293);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(330, 40);
            this.panelBottom.TabIndex = 5;
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
            this.chkIsDisabled.Location = new System.Drawing.Point(91, 287);
            this.chkIsDisabled.Name = "chkIsDisabled";
            this.chkIsDisabled.Size = new System.Drawing.Size(78, 17);
            this.chkIsDisabled.TabIndex = 4;
            this.chkIsDisabled.Text = "Is Disabled";
            this.toolTipSDI.SetToolTip(this.chkIsDisabled, "When Checked, ID is Disabled, Un-Checked, ID is Active");
            this.chkIsDisabled.UseVisualStyleBackColor = true;
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.AutoSize = true;
            this.chkIsDefault.Enabled = false;
            this.chkIsDefault.Location = new System.Drawing.Point(91, 310);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Size = new System.Drawing.Size(71, 17);
            this.chkIsDefault.TabIndex = 5;
            this.chkIsDefault.Text = "Is Default";
            this.chkIsDefault.UseVisualStyleBackColor = true;
            // 
            // mtextID
            // 
            this.mtextID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtextID.Location = new System.Drawing.Point(91, 73);
            this.mtextID.Name = "mtextID";
            this.mtextID.Size = new System.Drawing.Size(88, 20);
            this.mtextID.TabIndex = 0;
            this.toolTipSDI.SetToolTip(this.mtextID, "ID or Code Number. Only Numeric characters allowed. Format: ");
            this.mtextID.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtextID_MaskInputRejected);
            this.mtextID.DoubleClick += new System.EventHandler(this.mtextID_DoubleClick);
            this.mtextID.Enter += new System.EventHandler(this.mtextID_Enter);
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
            this.panelFormTitle.Controls.Add(this.lblTopLine3);
            this.panelFormTitle.Controls.Add(this.lblTopLine1);
            this.panelFormTitle.Controls.Add(this.lblTopLine2);
            this.panelFormTitle.Controls.Add(this.lblFormTitle);
            this.panelFormTitle.Location = new System.Drawing.Point(0, 0);
            this.panelFormTitle.Name = "panelFormTitle";
            this.panelFormTitle.Size = new System.Drawing.Size(551, 67);
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
            this.lblBottomLine1.Location = new System.Drawing.Point(-1, 336);
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
            this.toolStripStatuslblAlertText});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
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
            this.panelOptionalButton.Location = new System.Drawing.Point(0, 293);
            this.panelOptionalButton.Name = "panelOptionalButton";
            this.panelOptionalButton.Size = new System.Drawing.Size(20, 40);
            this.panelOptionalButton.TabIndex = 22;
            // 
            // mtextOrdering
            // 
            this.mtextOrdering.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtextOrdering.Location = new System.Drawing.Point(91, 151);
            this.mtextOrdering.Name = "mtextOrdering";
            this.mtextOrdering.Size = new System.Drawing.Size(88, 20);
            this.mtextOrdering.TabIndex = 3;
            this.toolTipSDI.SetToolTip(this.mtextOrdering, "Ordering Or Sequence: Priority to appear in View/Combo Box, Only Numeric characte" +
        "rs allowed. Format: ");
            // 
            // lblOrdering
            // 
            this.lblOrdering.AutoSize = true;
            this.lblOrdering.Location = new System.Drawing.Point(32, 153);
            this.lblOrdering.Name = "lblOrdering";
            this.lblOrdering.Size = new System.Drawing.Size(53, 13);
            this.lblOrdering.TabIndex = 24;
            this.lblOrdering.Text = "Ordering :";
            // 
            // gBAcNature
            // 
            this.gBAcNature.Controls.Add(this.rBtn_Revenue);
            this.gBAcNature.Controls.Add(this.rBtn_BalanceSheet);
            this.gBAcNature.Location = new System.Drawing.Point(91, 177);
            this.gBAcNature.Name = "gBAcNature";
            this.gBAcNature.Size = new System.Drawing.Size(231, 49);
            this.gBAcNature.TabIndex = 25;
            this.gBAcNature.TabStop = false;
            this.gBAcNature.Text = "Account Nature";
            // 
            // rBtn_BalanceSheet
            // 
            this.rBtn_BalanceSheet.AutoSize = true;
            this.rBtn_BalanceSheet.Location = new System.Drawing.Point(44, 19);
            this.rBtn_BalanceSheet.Name = "rBtn_BalanceSheet";
            this.rBtn_BalanceSheet.Size = new System.Drawing.Size(95, 17);
            this.rBtn_BalanceSheet.TabIndex = 26;
            this.rBtn_BalanceSheet.TabStop = true;
            this.rBtn_BalanceSheet.Text = "Balance Sheet";
            this.rBtn_BalanceSheet.UseVisualStyleBackColor = true;
            // 
            // rBtn_Revenue
            // 
            this.rBtn_Revenue.AutoSize = true;
            this.rBtn_Revenue.Location = new System.Drawing.Point(145, 19);
            this.rBtn_Revenue.Name = "rBtn_Revenue";
            this.rBtn_Revenue.Size = new System.Drawing.Size(69, 17);
            this.rBtn_Revenue.TabIndex = 27;
            this.rBtn_Revenue.TabStop = true;
            this.rBtn_Revenue.Text = "Revenue";
            this.rBtn_Revenue.UseVisualStyleBackColor = true;
            // 
            // gBBalanceSide
            // 
            this.gBBalanceSide.Controls.Add(this.rBtn_Credit);
            this.gBBalanceSide.Controls.Add(this.rBtn_Debit);
            this.gBBalanceSide.Location = new System.Drawing.Point(91, 232);
            this.gBBalanceSide.Name = "gBBalanceSide";
            this.gBBalanceSide.Size = new System.Drawing.Size(231, 49);
            this.gBBalanceSide.TabIndex = 26;
            this.gBBalanceSide.TabStop = false;
            this.gBBalanceSide.Text = "Natural Balance Side";
            // 
            // rBtn_Credit
            // 
            this.rBtn_Credit.AutoSize = true;
            this.rBtn_Credit.Location = new System.Drawing.Point(145, 19);
            this.rBtn_Credit.Name = "rBtn_Credit";
            this.rBtn_Credit.Size = new System.Drawing.Size(55, 17);
            this.rBtn_Credit.TabIndex = 27;
            this.rBtn_Credit.TabStop = true;
            this.rBtn_Credit.Text = "Credid";
            this.rBtn_Credit.UseVisualStyleBackColor = true;
            // 
            // rBtn_Debit
            // 
            this.rBtn_Debit.AutoSize = true;
            this.rBtn_Debit.Location = new System.Drawing.Point(44, 19);
            this.rBtn_Debit.Name = "rBtn_Debit";
            this.rBtn_Debit.Size = new System.Drawing.Size(50, 17);
            this.rBtn_Debit.TabIndex = 26;
            this.rBtn_Debit.TabStop = true;
            this.rBtn_Debit.Text = "Debit";
            this.rBtn_Debit.UseVisualStyleBackColor = true;
            // 
            // frmAcType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(551, 366);
            this.ContextMenuStrip = this.contextMenuStripSDI_Master;
            this.Controls.Add(this.gBBalanceSide);
            this.Controls.Add(this.gBAcNature);
            this.Controls.Add(this.mtextOrdering);
            this.Controls.Add(this.lblOrdering);
            this.Controls.Add(this.panelOptionalButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelFormTitle);
            this.Controls.Add(this.toolStripSDI_Master);
            this.Controls.Add(this.mtextID);
            this.Controls.Add(this.lblBottomLine1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.textST);
            this.Controls.Add(this.chkIsDefault);
            this.Controls.Add(this.chkIsDisabled);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.lblST);
            this.Controls.Add(this.lblTitle);
            this.KeyPreview = true;
            this.Name = "frmAcType";
            this.Text = "frmAcType";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSDI_Master_FormClosing);
            this.Load += new System.EventHandler(this.frmSDI_Master_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSDI_Master_KeyDown);
            this.panelBottom.ResumeLayout(false);
            this.toolStripSDI_Master.ResumeLayout(false);
            this.toolStripSDI_Master.PerformLayout();
            this.panelFormTitle.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gBAcNature.ResumeLayout(false);
            this.gBAcNature.PerformLayout();
            this.gBBalanceSide.ResumeLayout(false);
            this.gBBalanceSide.PerformLayout();
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
    private System.Windows.Forms.Panel panelBottom;
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
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatuslblAlertText;
    private System.Windows.Forms.Panel panelOptionalButton;
    private System.Windows.Forms.ToolTip toolTipSDI;
    private System.Windows.Forms.Label lblOrdering;
    private System.Windows.Forms.MaskedTextBox mtextOrdering;
    private System.Windows.Forms.GroupBox gBAcNature;
    private System.Windows.Forms.RadioButton rBtn_Revenue;
    private System.Windows.Forms.RadioButton rBtn_BalanceSheet;
    private System.Windows.Forms.GroupBox gBBalanceSide;
    private System.Windows.Forms.RadioButton rBtn_Credit;
    private System.Windows.Forms.RadioButton rBtn_Debit;
  }
}