namespace TaxSolution
{
    partial class frmGRN
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtManualDoc = new System.Windows.Forms.TextBox();
            this.grdVoucher = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.msk_VocDate = new System.Windows.Forms.MaskedTextBox();
            this.btn_Month = new System.Windows.Forms.Button();
            this.pnlCalander = new System.Windows.Forms.Panel();
            this.btn_HideMonth = new System.Windows.Forms.Button();
            this.mCalendarMain = new System.Windows.Forms.MonthCalendar();
            this.btn_SaveNContinue = new System.Windows.Forms.Button();
            this.btn_View = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContract = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.msk_VocMasterGLID = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblVocCodeName = new System.Windows.Forms.Label();
            this.sSMaster = new System.Windows.Forms.StatusStrip();
            this.tSlblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.textAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.tTMDtl = new System.Windows.Forms.ToolTip(this.components);
            this.pnlVocTran = new System.Windows.Forms.Panel();
            this.lblTotalInput = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbo_UOM = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.cboGodown = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCredit = new CSUST.Data.TNumEditBox();
            this.txtDebit = new CSUST.Data.TNumEditBox();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.txtItemID = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalQty = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.chk_Edit = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdVoucher)).BeginInit();
            this.pnlCalander.SuspendLayout();
            this.sSMaster.SuspendLayout();
            this.pnlVocTran.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtManualDoc
            // 
            this.txtManualDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManualDoc.Location = new System.Drawing.Point(98, 12);
            this.txtManualDoc.Name = "txtManualDoc";
            this.txtManualDoc.Size = new System.Drawing.Size(168, 20);
            this.txtManualDoc.TabIndex = 0;
            this.txtManualDoc.TextChanged += new System.EventHandler(this.txtManualDoc_TextChanged);
            this.txtManualDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManualDoc_KeyDown);
            // 
            // grdVoucher
            // 
            this.grdVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVoucher.Location = new System.Drawing.Point(9, 114);
            this.grdVoucher.Name = "grdVoucher";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grdVoucher.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdVoucher.Size = new System.Drawing.Size(807, 215);
            this.grdVoucher.TabIndex = 0;
            this.grdVoucher.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVoucher_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Voucher # : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(325, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date : ";
            // 
            // msk_VocDate
            // 
            this.msk_VocDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_VocDate.Location = new System.Drawing.Point(377, 13);
            this.msk_VocDate.Mask = "00/00/0000";
            this.msk_VocDate.Name = "msk_VocDate";
            this.msk_VocDate.Size = new System.Drawing.Size(96, 20);
            this.msk_VocDate.TabIndex = 18;
            this.msk_VocDate.Text = "01012010";
            this.msk_VocDate.ValidatingType = typeof(System.DateTime);
            // 
            // btn_Month
            // 
            this.btn_Month.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Month.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_Month.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Month.Location = new System.Drawing.Point(494, 8);
            this.btn_Month.Name = "btn_Month";
            this.btn_Month.Size = new System.Drawing.Size(62, 26);
            this.btn_Month.TabIndex = 19;
            this.btn_Month.TabStop = false;
            this.btn_Month.Text = "&Month";
            this.btn_Month.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Month.UseVisualStyleBackColor = true;
            this.btn_Month.Click += new System.EventHandler(this.btn_FromDate_Click);
            // 
            // pnlCalander
            // 
            this.pnlCalander.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalander.Controls.Add(this.btn_HideMonth);
            this.pnlCalander.Controls.Add(this.mCalendarMain);
            this.pnlCalander.Location = new System.Drawing.Point(562, 12);
            this.pnlCalander.Name = "pnlCalander";
            this.pnlCalander.Size = new System.Drawing.Size(234, 215);
            this.pnlCalander.TabIndex = 34;
            this.pnlCalander.Visible = false;
            // 
            // btn_HideMonth
            // 
            this.btn_HideMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_HideMonth.Location = new System.Drawing.Point(188, 187);
            this.btn_HideMonth.Name = "btn_HideMonth";
            this.btn_HideMonth.Size = new System.Drawing.Size(38, 24);
            this.btn_HideMonth.TabIndex = 18;
            this.btn_HideMonth.Text = "&Hide";
            this.btn_HideMonth.UseVisualStyleBackColor = true;
            this.btn_HideMonth.Click += new System.EventHandler(this.btn_HideMonth_Click);
            // 
            // mCalendarMain
            // 
            this.mCalendarMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mCalendarMain.Location = new System.Drawing.Point(4, 16);
            this.mCalendarMain.Margin = new System.Windows.Forms.Padding(0);
            this.mCalendarMain.Name = "mCalendarMain";
            this.mCalendarMain.TabIndex = 19;
            this.mCalendarMain.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mCalendarMain_DateChanged);
            // 
            // btn_SaveNContinue
            // 
            this.btn_SaveNContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveNContinue.Image = global::TaxSolution.Properties.Resources.saveHS;
            this.btn_SaveNContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SaveNContinue.Location = new System.Drawing.Point(444, 359);
            this.btn_SaveNContinue.Name = "btn_SaveNContinue";
            this.btn_SaveNContinue.Size = new System.Drawing.Size(74, 25);
            this.btn_SaveNContinue.TabIndex = 37;
            this.btn_SaveNContinue.Text = "Continu&e";
            this.btn_SaveNContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SaveNContinue.UseVisualStyleBackColor = true;
            // 
            // btn_View
            // 
            this.btn_View.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_View.Image = global::TaxSolution.Properties.Resources.x_preview_16x16;
            this.btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View.Location = new System.Drawing.Point(666, 359);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(74, 25);
            this.btn_View.TabIndex = 40;
            this.btn_View.Text = "&View";
            this.btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View.UseVisualStyleBackColor = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Image = global::TaxSolution.Properties.Resources.FormExit;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(742, 359);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(74, 25);
            this.btn_Exit.TabIndex = 41;
            this.btn_Exit.Text = "E&xit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click_1);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.Image = global::TaxSolution.Properties.Resources.ico_delete;
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.Location = new System.Drawing.Point(592, 359);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(74, 25);
            this.btn_Delete.TabIndex = 39;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.Image = global::TaxSolution.Properties.Resources.BaBa_clear;
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(518, 359);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(74, 25);
            this.btn_Clear.TabIndex = 38;
            this.btn_Clear.Text = "&Clear";
            this.btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Image = global::TaxSolution.Properties.Resources.saveHS;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(368, 359);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(74, 25);
            this.btn_Save.TabIndex = 36;
            this.btn_Save.Text = "&Save";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Contract # : ";
            // 
            // txtContract
            // 
            this.txtContract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContract.Location = new System.Drawing.Point(98, 37);
            this.txtContract.Name = "txtContract";
            this.txtContract.Size = new System.Drawing.Size(168, 20);
            this.txtContract.TabIndex = 43;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Supplier : ";
            // 
            // msk_VocMasterGLID
            // 
            this.msk_VocMasterGLID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_VocMasterGLID.Location = new System.Drawing.Point(98, 63);
            this.msk_VocMasterGLID.Mask = "#-#-##-##-####";
            this.msk_VocMasterGLID.Name = "msk_VocMasterGLID";
            this.msk_VocMasterGLID.Size = new System.Drawing.Size(132, 20);
            this.msk_VocMasterGLID.TabIndex = 45;
            this.msk_VocMasterGLID.Text = "1203010002";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Name : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Type : ";
            // 
            // txtType
            // 
            this.txtType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtType.Location = new System.Drawing.Point(98, 88);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(55, 20);
            this.txtType.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(319, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Detail : ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(377, 89);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(304, 20);
            this.txtRemarks.TabIndex = 51;
            // 
            // lblVocCodeName
            // 
            this.lblVocCodeName.BackColor = System.Drawing.Color.White;
            this.lblVocCodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVocCodeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVocCodeName.Location = new System.Drawing.Point(377, 62);
            this.lblVocCodeName.Name = "lblVocCodeName";
            this.lblVocCodeName.Size = new System.Drawing.Size(304, 21);
            this.lblVocCodeName.TabIndex = 52;
            // 
            // sSMaster
            // 
            this.sSMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSlblUser,
            this.tStextUser,
            this.tSlblStatus,
            this.tStextStatus,
            this.tSlblTotal,
            this.tStextTotal,
            this.tSlblAlert,
            this.textAlert});
            this.sSMaster.Location = new System.Drawing.Point(0, 390);
            this.sSMaster.Name = "sSMaster";
            this.sSMaster.Size = new System.Drawing.Size(822, 22);
            this.sSMaster.TabIndex = 140;
            this.sSMaster.Text = "statusStrip1";
            this.sSMaster.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sSMaster_ItemClicked);
            // 
            // tSlblUser
            // 
            this.tSlblUser.Name = "tSlblUser";
            this.tSlblUser.Size = new System.Drawing.Size(33, 17);
            this.tSlblUser.Text = "User:";
            // 
            // tStextUser
            // 
            this.tStextUser.AutoSize = false;
            this.tStextUser.Name = "tStextUser";
            this.tStextUser.Size = new System.Drawing.Size(70, 17);
            this.tStextUser.Text = "User...";
            this.tStextUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tSlblStatus
            // 
            this.tSlblStatus.Name = "tSlblStatus";
            this.tSlblStatus.Size = new System.Drawing.Size(42, 17);
            this.tSlblStatus.Text = "Status:";
            this.tSlblStatus.ToolTipText = "Status of this form: Read = Ready to Accept ID, New = ID is new, Modify = Updatin" +
    "g/Modifying an existing ID\' s data";
            // 
            // tStextStatus
            // 
            this.tStextStatus.AutoSize = false;
            this.tStextStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStextStatus.ForeColor = System.Drawing.Color.Teal;
            this.tStextStatus.Name = "tStextStatus";
            this.tStextStatus.Size = new System.Drawing.Size(75, 17);
            this.tStextStatus.Text = "Ready";
            this.tStextStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tSlblTotal
            // 
            this.tSlblTotal.Name = "tSlblTotal";
            this.tSlblTotal.Size = new System.Drawing.Size(40, 17);
            this.tSlblTotal.Text = "Total :";
            this.tSlblTotal.ToolTipText = "Total Number of Records already saved";
            // 
            // tStextTotal
            // 
            this.tStextTotal.AutoSize = false;
            this.tStextTotal.ForeColor = System.Drawing.Color.Teal;
            this.tStextTotal.Name = "tStextTotal";
            this.tStextTotal.Size = new System.Drawing.Size(50, 17);
            this.tStextTotal.Text = "0";
            this.tStextTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tSlblAlert
            // 
            this.tSlblAlert.AutoSize = false;
            this.tSlblAlert.Name = "tSlblAlert";
            this.tSlblAlert.Size = new System.Drawing.Size(40, 17);
            this.tSlblAlert.Text = "Alert :";
            this.tSlblAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textAlert
            // 
            this.textAlert.AutoSize = false;
            this.textAlert.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.textAlert.Name = "textAlert";
            this.textAlert.Size = new System.Drawing.Size(500, 17);
            this.textAlert.Text = "Ready";
            this.textAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlVocTran
            // 
            this.pnlVocTran.BackgroundImage = global::TaxSolution.Properties.Resources.d;
            this.pnlVocTran.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlVocTran.Controls.Add(this.lblTotalInput);
            this.pnlVocTran.Controls.Add(this.label13);
            this.pnlVocTran.Controls.Add(this.cbo_UOM);
            this.pnlVocTran.Controls.Add(this.label24);
            this.pnlVocTran.Controls.Add(this.cboGodown);
            this.pnlVocTran.Controls.Add(this.label12);
            this.pnlVocTran.Controls.Add(this.btn_Add);
            this.pnlVocTran.Controls.Add(this.label10);
            this.pnlVocTran.Controls.Add(this.label9);
            this.pnlVocTran.Controls.Add(this.label8);
            this.pnlVocTran.Controls.Add(this.label11);
            this.pnlVocTran.Controls.Add(this.txtCredit);
            this.pnlVocTran.Controls.Add(this.txtDebit);
            this.pnlVocTran.Controls.Add(this.txtNarration);
            this.pnlVocTran.Controls.Add(this.lblItemName);
            this.pnlVocTran.Controls.Add(this.txtItemID);
            this.pnlVocTran.Controls.Add(this.label14);
            this.pnlVocTran.Location = new System.Drawing.Point(159, 88);
            this.pnlVocTran.Name = "pnlVocTran";
            this.pnlVocTran.Size = new System.Drawing.Size(549, 252);
            this.pnlVocTran.TabIndex = 141;
            this.pnlVocTran.Visible = false;
            this.pnlVocTran.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlVocTran_Paint);
            // 
            // lblTotalInput
            // 
            this.lblTotalInput.BackColor = System.Drawing.Color.White;
            this.lblTotalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInput.Location = new System.Drawing.Point(132, 216);
            this.lblTotalInput.Name = "lblTotalInput";
            this.lblTotalInput.Size = new System.Drawing.Size(157, 21);
            this.lblTotalInput.TabIndex = 144;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(69, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 143;
            this.label13.Text = "Total : ";
            // 
            // cbo_UOM
            // 
            this.cbo_UOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_UOM.FormattingEnabled = true;
            this.cbo_UOM.Location = new System.Drawing.Point(132, 103);
            this.cbo_UOM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_UOM.Name = "cbo_UOM";
            this.cbo_UOM.Size = new System.Drawing.Size(246, 24);
            this.cbo_UOM.TabIndex = 142;
            this.cbo_UOM.SelectedIndexChanged += new System.EventHandler(this.cbo_UOM_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(71, 106);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 16);
            this.label24.TabIndex = 141;
            this.label24.Text = "UOM : ";
            // 
            // cboGodown
            // 
            this.cboGodown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGodown.FormattingEnabled = true;
            this.cboGodown.Location = new System.Drawing.Point(132, 18);
            this.cboGodown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboGodown.Name = "cboGodown";
            this.cboGodown.Size = new System.Drawing.Size(246, 24);
            this.cboGodown.TabIndex = 140;
            this.cboGodown.SelectedIndexChanged += new System.EventHandler(this.cboGodown_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(37, 21);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 139;
            this.label12.Text = "Godown # : ";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.Image = global::TaxSolution.Properties.Resources.x_preview_16x16;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(436, 210);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(74, 25);
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "&Add";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(82, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 138;
            this.label10.Text = "Qty : ";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(72, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 137;
            this.label9.Text = "Rate : ";
            this.label9.Visible = false;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 136;
            this.label8.Text = "Description : ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(64, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 16);
            this.label11.TabIndex = 135;
            this.label11.Text = "Name : ";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtCredit
            // 
            this.txtCredit.DecimalLength = 2;
            this.txtCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredit.Location = new System.Drawing.Point(132, 189);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(157, 22);
            this.txtCredit.TabIndex = 4;
            this.txtCredit.Text = "0.00";
            this.txtCredit.TextChanged += new System.EventHandler(this.txtCredit_TextChanged);
            // 
            // txtDebit
            // 
            this.txtDebit.DecimalLength = 2;
            this.txtDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebit.Location = new System.Drawing.Point(132, 161);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Size = new System.Drawing.Size(157, 22);
            this.txtDebit.TabIndex = 3;
            this.txtDebit.Text = "0.00";
            this.txtDebit.Visible = false;
            this.txtDebit.TextChanged += new System.EventHandler(this.txtDebit_TextChanged);
            // 
            // txtNarration
            // 
            this.txtNarration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarration.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.Location = new System.Drawing.Point(132, 133);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(388, 22);
            this.txtNarration.TabIndex = 2;
            this.txtNarration.TextChanged += new System.EventHandler(this.txtNarration_TextChanged);
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.Color.White;
            this.lblItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(132, 76);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(388, 21);
            this.lblItemName.TabIndex = 1;
            this.lblItemName.Click += new System.EventHandler(this.lblItemName_Click);
            // 
            // txtItemID
            // 
            this.txtItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemID.Location = new System.Drawing.Point(132, 48);
            this.txtItemID.Mask = "#####";
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.Size = new System.Drawing.Size(137, 22);
            this.txtItemID.TabIndex = 0;
            this.txtItemID.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtItemID_MaskInputRejected);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(56, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 16);
            this.label14.TabIndex = 4;
            this.label14.Text = "Code # : ";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // lblTotalQty
            // 
            this.lblTotalQty.BackColor = System.Drawing.Color.White;
            this.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalQty.Location = new System.Drawing.Point(464, 335);
            this.lblTotalQty.Name = "lblTotalQty";
            this.lblTotalQty.Size = new System.Drawing.Size(165, 21);
            this.lblTotalQty.TabIndex = 143;
            this.lblTotalQty.Click += new System.EventHandler(this.lblTotalQty_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.White;
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(645, 335);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(165, 21);
            this.lblTotalAmount.TabIndex = 142;
            this.lblTotalAmount.Click += new System.EventHandler(this.lblTotalAmount_Click);
            // 
            // chk_Edit
            // 
            this.chk_Edit.AutoSize = true;
            this.chk_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chk_Edit.Location = new System.Drawing.Point(17, 340);
            this.chk_Edit.Name = "chk_Edit";
            this.chk_Edit.Size = new System.Drawing.Size(48, 17);
            this.chk_Edit.TabIndex = 144;
            this.chk_Edit.Text = "&Edit";
            this.chk_Edit.UseVisualStyleBackColor = true;
            // 
            // frmGRN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 412);
            this.Controls.Add(this.chk_Edit);
            this.Controls.Add(this.pnlCalander);
            this.Controls.Add(this.lblTotalQty);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.pnlVocTran);
            this.Controls.Add(this.sSMaster);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.msk_VocMasterGLID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContract);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grdVoucher);
            this.Controls.Add(this.btn_SaveNContinue);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.btn_Month);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.msk_VocDate);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.txtManualDoc);
            this.Controls.Add(this.lblVocCodeName);
            this.KeyPreview = true;
            this.Name = "frmGRN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRN Entry";
            this.Load += new System.EventHandler(this.frmVoc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVoc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdVoucher)).EndInit();
            this.pnlCalander.ResumeLayout(false);
            this.sSMaster.ResumeLayout(false);
            this.sSMaster.PerformLayout();
            this.pnlVocTran.ResumeLayout(false);
            this.pnlVocTran.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtManualDoc;
        private System.Windows.Forms.DataGridView grdVoucher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox msk_VocDate;
        private System.Windows.Forms.Button btn_Month;
        private System.Windows.Forms.Panel pnlCalander;
        private System.Windows.Forms.Button btn_HideMonth;
        private System.Windows.Forms.MonthCalendar mCalendarMain;
        private System.Windows.Forms.Button btn_SaveNContinue;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtContract;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox msk_VocMasterGLID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblVocCodeName;
        private System.Windows.Forms.StatusStrip sSMaster;
        private System.Windows.Forms.ToolStripStatusLabel tSlblUser;
        private System.Windows.Forms.ToolStripStatusLabel tStextUser;
        private System.Windows.Forms.ToolStripStatusLabel tSlblStatus;
        private System.Windows.Forms.ToolStripStatusLabel tStextStatus;
        private System.Windows.Forms.ToolStripStatusLabel tSlblTotal;
        private System.Windows.Forms.ToolStripStatusLabel tStextTotal;
        private System.Windows.Forms.ToolStripStatusLabel tSlblAlert;
        private System.Windows.Forms.ToolStripStatusLabel textAlert;
        private System.Windows.Forms.ToolTip tTMDtl;
        private System.Windows.Forms.Panel pnlVocTran;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private CSUST.Data.TNumEditBox txtCredit;
        private CSUST.Data.TNumEditBox txtDebit;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.MaskedTextBox txtItemID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboGodown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbo_UOM;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblTotalQty;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotalInput;
        private System.Windows.Forms.CheckBox chk_Edit;
    }
}