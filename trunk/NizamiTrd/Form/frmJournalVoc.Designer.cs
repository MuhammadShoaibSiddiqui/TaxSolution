namespace TaxSolution
{
    partial class frmJournalVoc
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
            this.lblDocID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalDr = new System.Windows.Forms.Label();
            this.lblTotalCr = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.btn_FocusGrid = new System.Windows.Forms.Button();
            this.tTMDtl = new System.Windows.Forms.ToolTip(this.components);
            this.pnlVocTran = new System.Windows.Forms.Panel();
            this.btn_PinIDCr = new System.Windows.Forms.Button();
            this.btn_PinIDDr = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAcID = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.lblAccountName = new System.Windows.Forms.Label();
            this.msk_AccountID = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mMsk_AccountID = new System.Windows.Forms.MaskedTextBox();
            this.sSMaster = new System.Windows.Forms.StatusStrip();
            this.tSlblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tStextTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSlblAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.textAlert = new System.Windows.Forms.ToolStripStatusLabel();
            this.chk_Edit = new System.Windows.Forms.CheckBox();
            this.txtCredit = new CSUST.Data.TNumEditBox();
            this.txtDebit = new CSUST.Data.TNumEditBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdVoucher)).BeginInit();
            this.pnlCalander.SuspendLayout();
            this.pnlVocTran.SuspendLayout();
            this.sSMaster.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtManualDoc
            // 
            this.txtManualDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtManualDoc.Location = new System.Drawing.Point(177, 28);
            this.txtManualDoc.Name = "txtManualDoc";
            this.txtManualDoc.Size = new System.Drawing.Size(168, 20);
            this.txtManualDoc.TabIndex = 0;
            this.txtManualDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManualDoc_KeyDown);
            this.txtManualDoc.Leave += new System.EventHandler(this.txtManualDoc_Leave);
            this.txtManualDoc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtManualDoc_MouseDoubleClick);
            this.txtManualDoc.Validating += new System.ComponentModel.CancelEventHandler(this.txtManualDoc_Validating);
            // 
            // grdVoucher
            // 
            this.grdVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVoucher.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVoucher.Location = new System.Drawing.Point(9, 56);
            this.grdVoucher.Name = "grdVoucher";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.grdVoucher.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdVoucher.Size = new System.Drawing.Size(791, 292);
            this.grdVoucher.TabIndex = 2;
            this.grdVoucher.Enter += new System.EventHandler(this.grdVoucher_Enter);
            this.grdVoucher.Leave += new System.EventHandler(this.grdVoucher_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Voucher # : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(362, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date : ";
            // 
            // msk_VocDate
            // 
            this.msk_VocDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_VocDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_VocDate.Location = new System.Drawing.Point(414, 29);
            this.msk_VocDate.Mask = "00/00/0000";
            this.msk_VocDate.Name = "msk_VocDate";
            this.msk_VocDate.Size = new System.Drawing.Size(82, 20);
            this.msk_VocDate.TabIndex = 1;
            this.msk_VocDate.Text = "01012010";
            this.msk_VocDate.ValidatingType = typeof(System.DateTime);
            this.msk_VocDate.Leave += new System.EventHandler(this.msk_VocDate_Leave);
            // 
            // btn_Month
            // 
            this.btn_Month.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Month.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_Month.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Month.Location = new System.Drawing.Point(502, 24);
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
            this.pnlCalander.Location = new System.Drawing.Point(570, 34);
            this.pnlCalander.Name = "pnlCalander";
            this.pnlCalander.Size = new System.Drawing.Size(237, 215);
            this.pnlCalander.TabIndex = 34;
            this.pnlCalander.Visible = false;
            // 
            // btn_HideMonth
            // 
            this.btn_HideMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_HideMonth.Location = new System.Drawing.Point(191, 187);
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
            this.btn_SaveNContinue.Location = new System.Drawing.Point(425, 408);
            this.btn_SaveNContinue.Name = "btn_SaveNContinue";
            this.btn_SaveNContinue.Size = new System.Drawing.Size(74, 25);
            this.btn_SaveNContinue.TabIndex = 5;
            this.btn_SaveNContinue.Text = "Continu&e";
            this.btn_SaveNContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SaveNContinue.UseVisualStyleBackColor = true;
            this.btn_SaveNContinue.Click += new System.EventHandler(this.btn_SaveNContinue_Click);
            // 
            // btn_View
            // 
            this.btn_View.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_View.Image = global::TaxSolution.Properties.Resources.x_preview_16x16;
            this.btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View.Location = new System.Drawing.Point(647, 408);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(74, 25);
            this.btn_View.TabIndex = 8;
            this.btn_View.Text = "&View";
            this.btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.CausesValidation = false;
            this.btn_Exit.Image = global::TaxSolution.Properties.Resources.FormExit;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(723, 408);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(74, 25);
            this.btn_Exit.TabIndex = 9;
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
            this.btn_Delete.Location = new System.Drawing.Point(573, 408);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(74, 25);
            this.btn_Delete.TabIndex = 7;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.Image = global::TaxSolution.Properties.Resources.BaBa_clear;
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(499, 408);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(74, 25);
            this.btn_Clear.TabIndex = 6;
            this.btn_Clear.Text = "&Clear";
            this.btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Image = global::TaxSolution.Properties.Resources.saveHS;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(349, 408);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(74, 25);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "&Save";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(579, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Auto ID : ";
            // 
            // lblDocID
            // 
            this.lblDocID.BackColor = System.Drawing.Color.White;
            this.lblDocID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDocID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocID.Location = new System.Drawing.Point(647, 23);
            this.lblDocID.Name = "lblDocID";
            this.lblDocID.Size = new System.Drawing.Size(77, 21);
            this.lblDocID.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(539, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 131;
            this.label4.Text = "Total Debit : ";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(537, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 131;
            this.label5.Text = "Total Credit : ";
            // 
            // lblTotalDr
            // 
            this.lblTotalDr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDr.BackColor = System.Drawing.Color.White;
            this.lblTotalDr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalDr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDr.Location = new System.Drawing.Point(627, 351);
            this.lblTotalDr.Name = "lblTotalDr";
            this.lblTotalDr.Size = new System.Drawing.Size(167, 21);
            this.lblTotalDr.TabIndex = 132;
            this.lblTotalDr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCr
            // 
            this.lblTotalCr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCr.BackColor = System.Drawing.Color.White;
            this.lblTotalCr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalCr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCr.Location = new System.Drawing.Point(627, 380);
            this.lblTotalCr.Name = "lblTotalCr";
            this.lblTotalCr.Size = new System.Drawing.Size(167, 21);
            this.lblTotalCr.TabIndex = 133;
            this.lblTotalCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRemarks
            // 
            this.lblRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarks.Location = new System.Drawing.Point(25, 359);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(68, 13);
            this.lblRemarks.TabIndex = 135;
            this.lblRemarks.Text = "Remarks : ";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRemarks.Location = new System.Drawing.Point(96, 356);
            this.txtRemarks.MaxLength = 50;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(426, 20);
            this.txtRemarks.TabIndex = 3;
            this.txtRemarks.TextChanged += new System.EventHandler(this.txtRemarks_TextChanged);
            // 
            // btn_FocusGrid
            // 
            this.btn_FocusGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_FocusGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_FocusGrid.Location = new System.Drawing.Point(12, 408);
            this.btn_FocusGrid.Name = "btn_FocusGrid";
            this.btn_FocusGrid.Size = new System.Drawing.Size(12, 10);
            this.btn_FocusGrid.TabIndex = 136;
            this.btn_FocusGrid.Text = "&g";
            this.btn_FocusGrid.UseVisualStyleBackColor = true;
            this.btn_FocusGrid.Click += new System.EventHandler(this.btn_FocusGrid_Click);
            // 
            // pnlVocTran
            // 
            this.pnlVocTran.BackgroundImage = global::TaxSolution.Properties.Resources.d;
            this.pnlVocTran.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlVocTran.Controls.Add(this.btn_PinIDCr);
            this.pnlVocTran.Controls.Add(this.btn_PinIDDr);
            this.pnlVocTran.Controls.Add(this.label12);
            this.pnlVocTran.Controls.Add(this.lblAcID);
            this.pnlVocTran.Controls.Add(this.btn_Add);
            this.pnlVocTran.Controls.Add(this.label10);
            this.pnlVocTran.Controls.Add(this.label9);
            this.pnlVocTran.Controls.Add(this.label8);
            this.pnlVocTran.Controls.Add(this.label7);
            this.pnlVocTran.Controls.Add(this.txtCredit);
            this.pnlVocTran.Controls.Add(this.txtDebit);
            this.pnlVocTran.Controls.Add(this.txtNarration);
            this.pnlVocTran.Controls.Add(this.lblAccountName);
            this.pnlVocTran.Controls.Add(this.msk_AccountID);
            this.pnlVocTran.Controls.Add(this.label6);
            this.pnlVocTran.Location = new System.Drawing.Point(110, 105);
            this.pnlVocTran.Name = "pnlVocTran";
            this.pnlVocTran.Size = new System.Drawing.Size(537, 190);
            this.pnlVocTran.TabIndex = 137;
            this.pnlVocTran.Visible = false;
            // 
            // btn_PinIDCr
            // 
            this.btn_PinIDCr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PinIDCr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PinIDCr.Location = new System.Drawing.Point(304, 138);
            this.btn_PinIDCr.Name = "btn_PinIDCr";
            this.btn_PinIDCr.Size = new System.Drawing.Size(80, 26);
            this.btn_PinIDCr.TabIndex = 146;
            this.btn_PinIDCr.Text = "&Pin";
            this.btn_PinIDCr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PinIDCr.UseVisualStyleBackColor = true;
            this.btn_PinIDCr.Click += new System.EventHandler(this.btn_PinIDCr_Click);
            // 
            // btn_PinIDDr
            // 
            this.btn_PinIDDr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PinIDDr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PinIDDr.Location = new System.Drawing.Point(304, 111);
            this.btn_PinIDDr.Name = "btn_PinIDDr";
            this.btn_PinIDDr.Size = new System.Drawing.Size(80, 26);
            this.btn_PinIDDr.TabIndex = 145;
            this.btn_PinIDDr.Text = "&Pin";
            this.btn_PinIDDr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PinIDDr.UseVisualStyleBackColor = true;
            this.btn_PinIDDr.Click += new System.EventHandler(this.btn_PinIDDr_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(305, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 141;
            this.label12.Text = "ID # : ";
            this.label12.Visible = false;
            // 
            // lblAcID
            // 
            this.lblAcID.BackColor = System.Drawing.Color.White;
            this.lblAcID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAcID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcID.Location = new System.Drawing.Point(355, 31);
            this.lblAcID.Name = "lblAcID";
            this.lblAcID.Size = new System.Drawing.Size(81, 21);
            this.lblAcID.TabIndex = 140;
            this.lblAcID.Visible = false;
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.Image = global::TaxSolution.Properties.Resources.x_preview_16x16;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.Location = new System.Drawing.Point(424, 148);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(74, 25);
            this.btn_Add.TabIndex = 139;
            this.btn_Add.Text = "&Add";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(78, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 138;
            this.label10.Text = "Credit : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(81, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 137;
            this.label9.Text = "Debit : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(47, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 136;
            this.label8.Text = "Description : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 135;
            this.label7.Text = "Account Name : ";
            // 
            // txtNarration
            // 
            this.txtNarration.Location = new System.Drawing.Point(140, 87);
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(388, 20);
            this.txtNarration.TabIndex = 132;
            // 
            // lblAccountName
            // 
            this.lblAccountName.BackColor = System.Drawing.Color.White;
            this.lblAccountName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountName.Location = new System.Drawing.Point(140, 58);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(388, 21);
            this.lblAccountName.TabIndex = 131;
            // 
            // msk_AccountID
            // 
            this.msk_AccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_AccountID.Location = new System.Drawing.Point(141, 31);
            this.msk_AccountID.Mask = "#-#-##-##-####";
            this.msk_AccountID.Name = "msk_AccountID";
            this.msk_AccountID.Size = new System.Drawing.Size(137, 20);
            this.msk_AccountID.TabIndex = 46;
            this.msk_AccountID.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.msk_AccountID_MaskInputRejected);
            this.msk_AccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msk_AccountID_KeyDown);
            this.msk_AccountID.Leave += new System.EventHandler(this.msk_AccountID_Leave);
            this.msk_AccountID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.msk_AccountID_MouseDoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Account ID : ";
            // 
            // mMsk_AccountID
            // 
            this.mMsk_AccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mMsk_AccountID.Location = new System.Drawing.Point(551, 0);
            this.mMsk_AccountID.Name = "mMsk_AccountID";
            this.mMsk_AccountID.Size = new System.Drawing.Size(137, 20);
            this.mMsk_AccountID.TabIndex = 138;
            this.mMsk_AccountID.Text = "1203010002";
            this.mMsk_AccountID.Visible = false;
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
            this.sSMaster.Location = new System.Drawing.Point(0, 447);
            this.sSMaster.Name = "sSMaster";
            this.sSMaster.Size = new System.Drawing.Size(806, 22);
            this.sSMaster.TabIndex = 139;
            this.sSMaster.Text = "statusStrip1";
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
            // chk_Edit
            // 
            this.chk_Edit.AutoSize = true;
            this.chk_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.chk_Edit.Location = new System.Drawing.Point(28, 384);
            this.chk_Edit.Name = "chk_Edit";
            this.chk_Edit.Size = new System.Drawing.Size(48, 17);
            this.chk_Edit.TabIndex = 140;
            this.chk_Edit.Text = "&Edit";
            this.chk_Edit.UseVisualStyleBackColor = true;
            this.chk_Edit.Click += new System.EventHandler(this.chk_Edit_Click);
            // 
            // txtCredit
            // 
            this.txtCredit.DecimalLength = 2;
            this.txtCredit.Location = new System.Drawing.Point(140, 139);
            this.txtCredit.Name = "txtCredit";
            this.txtCredit.Size = new System.Drawing.Size(157, 20);
            this.txtCredit.TabIndex = 134;
            this.txtCredit.Text = "0.00";
            // 
            // txtDebit
            // 
            this.txtDebit.DecimalLength = 2;
            this.txtDebit.Location = new System.Drawing.Point(140, 113);
            this.txtDebit.Name = "txtDebit";
            this.txtDebit.Size = new System.Drawing.Size(157, 20);
            this.txtDebit.TabIndex = 133;
            this.txtDebit.Text = "0.00";
            this.txtDebit.Leave += new System.EventHandler(this.txtDebit_Leave);
            // 
            // frmJournalVoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 469);
            this.Controls.Add(this.chk_Edit);
            this.Controls.Add(this.sSMaster);
            this.Controls.Add(this.mMsk_AccountID);
            this.Controls.Add(this.pnlCalander);
            this.Controls.Add(this.pnlVocTran);
            this.Controls.Add(this.btn_FocusGrid);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblTotalCr);
            this.Controls.Add(this.lblTotalDr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDocID);
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
            this.KeyPreview = true;
            this.Name = "frmJournalVoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Journal Voucher Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmJournalVoc_FormClosing);
            this.Load += new System.EventHandler(this.frmJournalVoc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmJournalVoc_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdVoucher)).EndInit();
            this.pnlCalander.ResumeLayout(false);
            this.pnlVocTran.ResumeLayout(false);
            this.pnlVocTran.PerformLayout();
            this.sSMaster.ResumeLayout(false);
            this.sSMaster.PerformLayout();
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
        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalDr;
        private System.Windows.Forms.Label lblTotalCr;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btn_FocusGrid;
        private System.Windows.Forms.ToolTip tTMDtl;
        private System.Windows.Forms.Panel pnlVocTran;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox msk_AccountID;
        private System.Windows.Forms.Label lblAccountName;
        private System.Windows.Forms.TextBox txtNarration;
        private CSUST.Data.TNumEditBox txtDebit;
        private CSUST.Data.TNumEditBox txtCredit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.MaskedTextBox mMsk_AccountID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAcID;
        private System.Windows.Forms.StatusStrip sSMaster;
        private System.Windows.Forms.ToolStripStatusLabel tSlblUser;
        private System.Windows.Forms.ToolStripStatusLabel tStextUser;
        private System.Windows.Forms.ToolStripStatusLabel tSlblStatus;
        private System.Windows.Forms.ToolStripStatusLabel tStextStatus;
        private System.Windows.Forms.ToolStripStatusLabel tSlblTotal;
        private System.Windows.Forms.ToolStripStatusLabel tStextTotal;
        private System.Windows.Forms.ToolStripStatusLabel tSlblAlert;
        private System.Windows.Forms.ToolStripStatusLabel textAlert;
        private System.Windows.Forms.CheckBox chk_Edit;
        private System.Windows.Forms.Button btn_PinIDDr;
        private System.Windows.Forms.Button btn_PinIDCr;
    }
}