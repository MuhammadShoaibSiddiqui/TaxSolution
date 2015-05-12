namespace TaxSolution
{
    partial class frmPeriodGroup
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
            this.btn_HideMonth = new System.Windows.Forms.Button();
            this.grdPostDtdChq = new System.Windows.Forms.DataGridView();
            this.lblTotalDebit = new System.Windows.Forms.Label();
            this.grdDishChq = new System.Windows.Forms.DataGridView();
            this.tabDishChq = new System.Windows.Forms.TabPage();
            this.tabPostDateChq = new System.Windows.Forms.TabPage();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.tabTranSmry = new System.Windows.Forms.TabPage();
            this.grdSmry = new System.Windows.Forms.DataGridView();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.grdPersonalInfo = new System.Windows.Forms.DataGridView();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCalander = new System.Windows.Forms.Panel();
            this.mCalendarMain = new System.Windows.Forms.MonthCalendar();
            this.msk_AccountID = new System.Windows.Forms.MaskedTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLedgerStatment = new System.Windows.Forms.TabPage();
            this.grdDetail = new System.Windows.Forms.DataGridView();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtAcName = new System.Windows.Forms.TextBox();
            this.lblOpBal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.msk_ToDate = new System.Windows.Forms.MaskedTextBox();
            this.msk_FromDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.optBal = new System.Windows.Forms.RadioButton();
            this.OptDetail = new System.Windows.Forms.RadioButton();
            this.OptComp = new System.Windows.Forms.RadioButton();
            this.optAging = new System.Windows.Forms.RadioButton();
            this.OptCompBal = new System.Windows.Forms.RadioButton();
            this.optCOA = new System.Windows.Forms.RadioButton();
            this.OptTrial = new System.Windows.Forms.RadioButton();
            this.OptTrialOp = new System.Windows.Forms.RadioButton();
            this.optWithoutOpBal = new System.Windows.Forms.RadioButton();
            this.optCOA_Addr = new System.Windows.Forms.RadioButton();
            this.optCustAddr = new System.Windows.Forms.RadioButton();
            this.optCOA_Group = new System.Windows.Forms.RadioButton();
            this.optCOA_Detail = new System.Windows.Forms.RadioButton();
            this.optAgingGLCode = new System.Windows.Forms.RadioButton();
            this.OptTrialComplete = new System.Windows.Forms.RadioButton();
            this.OptTrialGroup = new System.Windows.Forms.RadioButton();
            this.btn_ToDate = new System.Windows.Forms.Button();
            this.btn_FromDate = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_View = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdPostDtdChq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDishChq)).BeginInit();
            this.tabDishChq.SuspendLayout();
            this.tabPostDateChq.SuspendLayout();
            this.tabTranSmry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSmry)).BeginInit();
            this.tabPersonalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonalInfo)).BeginInit();
            this.pnlCalander.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabLedgerStatment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
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
            // grdPostDtdChq
            // 
            this.grdPostDtdChq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPostDtdChq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPostDtdChq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPostDtdChq.Location = new System.Drawing.Point(6, 6);
            this.grdPostDtdChq.Name = "grdPostDtdChq";
            this.grdPostDtdChq.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdPostDtdChq.RowTemplate.Height = 24;
            this.grdPostDtdChq.Size = new System.Drawing.Size(819, 209);
            this.grdPostDtdChq.TabIndex = 3;
            // 
            // lblTotalDebit
            // 
            this.lblTotalDebit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDebit.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalDebit.Location = new System.Drawing.Point(596, 457);
            this.lblTotalDebit.Name = "lblTotalDebit";
            this.lblTotalDebit.Size = new System.Drawing.Size(118, 20);
            this.lblTotalDebit.TabIndex = 59;
            this.lblTotalDebit.Text = "0.00";
            this.lblTotalDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdDishChq
            // 
            this.grdDishChq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDishChq.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDishChq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDishChq.Location = new System.Drawing.Point(6, 6);
            this.grdDishChq.Name = "grdDishChq";
            this.grdDishChq.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDishChq.RowTemplate.Height = 24;
            this.grdDishChq.Size = new System.Drawing.Size(819, 213);
            this.grdDishChq.TabIndex = 3;
            // 
            // tabDishChq
            // 
            this.tabDishChq.Controls.Add(this.grdDishChq);
            this.tabDishChq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDishChq.Location = new System.Drawing.Point(4, 22);
            this.tabDishChq.Name = "tabDishChq";
            this.tabDishChq.Size = new System.Drawing.Size(831, 185);
            this.tabDishChq.TabIndex = 4;
            this.tabDishChq.Text = "Dishonoured Cheques";
            this.tabDishChq.UseVisualStyleBackColor = true;
            // 
            // tabPostDateChq
            // 
            this.tabPostDateChq.Controls.Add(this.grdPostDtdChq);
            this.tabPostDateChq.Location = new System.Drawing.Point(4, 22);
            this.tabPostDateChq.Name = "tabPostDateChq";
            this.tabPostDateChq.Size = new System.Drawing.Size(831, 185);
            this.tabPostDateChq.TabIndex = 3;
            this.tabPostDateChq.Text = "Post Dated Cheques";
            this.tabPostDateChq.UseVisualStyleBackColor = true;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCredit.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalCredit.Location = new System.Drawing.Point(720, 457);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(118, 20);
            this.lblTotalCredit.TabIndex = 60;
            this.lblTotalCredit.Text = "0.00";
            this.lblTotalCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabTranSmry
            // 
            this.tabTranSmry.Controls.Add(this.grdSmry);
            this.tabTranSmry.Location = new System.Drawing.Point(4, 22);
            this.tabTranSmry.Name = "tabTranSmry";
            this.tabTranSmry.Padding = new System.Windows.Forms.Padding(3);
            this.tabTranSmry.Size = new System.Drawing.Size(831, 185);
            this.tabTranSmry.TabIndex = 1;
            this.tabTranSmry.Text = "Transaction Summary";
            this.tabTranSmry.UseVisualStyleBackColor = true;
            // 
            // grdSmry
            // 
            this.grdSmry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSmry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdSmry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSmry.Location = new System.Drawing.Point(6, 6);
            this.grdSmry.Name = "grdSmry";
            this.grdSmry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdSmry.RowTemplate.Height = 24;
            this.grdSmry.Size = new System.Drawing.Size(819, 212);
            this.grdSmry.TabIndex = 3;
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.grdPersonalInfo);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Size = new System.Drawing.Size(831, 185);
            this.tabPersonalInfo.TabIndex = 2;
            this.tabPersonalInfo.Text = "Personal Information";
            this.tabPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // grdPersonalInfo
            // 
            this.grdPersonalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPersonalInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPersonalInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPersonalInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Info,
            this.Detail});
            this.grdPersonalInfo.Location = new System.Drawing.Point(71, 6);
            this.grdPersonalInfo.Name = "grdPersonalInfo";
            this.grdPersonalInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdPersonalInfo.RowTemplate.Height = 24;
            this.grdPersonalInfo.Size = new System.Drawing.Size(633, 199);
            this.grdPersonalInfo.TabIndex = 3;
            // 
            // Info
            // 
            this.Info.Frozen = true;
            this.Info.HeaderText = "Type";
            this.Info.Name = "Info";
            this.Info.Width = 150;
            // 
            // Detail
            // 
            this.Detail.HeaderText = "Detail Information";
            this.Detail.Name = "Detail";
            this.Detail.Width = 500;
            // 
            // pnlCalander
            // 
            this.pnlCalander.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalander.Controls.Add(this.btn_HideMonth);
            this.pnlCalander.Controls.Add(this.mCalendarMain);
            this.pnlCalander.Location = new System.Drawing.Point(128, 94);
            this.pnlCalander.Name = "pnlCalander";
            this.pnlCalander.Size = new System.Drawing.Size(234, 215);
            this.pnlCalander.TabIndex = 58;
            this.pnlCalander.Visible = false;
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
            // msk_AccountID
            // 
            this.msk_AccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_AccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_AccountID.Location = new System.Drawing.Point(164, 11);
            this.msk_AccountID.Mask = "#-#-##-##-####";
            this.msk_AccountID.Name = "msk_AccountID";
            this.msk_AccountID.Size = new System.Drawing.Size(137, 20);
            this.msk_AccountID.TabIndex = 37;
            this.msk_AccountID.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.msk_AccountID_MaskInputRejected);
            this.msk_AccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msk_AccountID_KeyDown);
            this.msk_AccountID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.msk_AccountID_MouseDoubleClick);
            this.msk_AccountID.Validating += new System.ComponentModel.CancelEventHandler(this.mskValidating);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLedgerStatment);
            this.tabControl1.Controls.Add(this.tabTranSmry);
            this.tabControl1.Controls.Add(this.tabPersonalInfo);
            this.tabControl1.Controls.Add(this.tabPostDateChq);
            this.tabControl1.Controls.Add(this.tabDishChq);
            this.tabControl1.Location = new System.Drawing.Point(6, 243);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 211);
            this.tabControl1.TabIndex = 57;
            // 
            // tabLedgerStatment
            // 
            this.tabLedgerStatment.Controls.Add(this.grdDetail);
            this.tabLedgerStatment.Location = new System.Drawing.Point(4, 22);
            this.tabLedgerStatment.Name = "tabLedgerStatment";
            this.tabLedgerStatment.Padding = new System.Windows.Forms.Padding(3);
            this.tabLedgerStatment.Size = new System.Drawing.Size(831, 185);
            this.tabLedgerStatment.TabIndex = 0;
            this.tabLedgerStatment.Text = "Ledger Statement";
            this.tabLedgerStatment.UseVisualStyleBackColor = true;
            // 
            // grdDetail
            // 
            this.grdDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetail.Location = new System.Drawing.Point(6, 6);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDetail.RowTemplate.Height = 24;
            this.grdDetail.Size = new System.Drawing.Size(819, 214);
            this.grdDetail.TabIndex = 2;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 490);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(865, 22);
            this.statusBar.TabIndex = 56;
            this.statusBar.Text = "status Bar";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(164, 123);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(183, 18);
            this.label15.TabIndex = 55;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(164, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(183, 18);
            this.label14.TabIndex = 54;
            // 
            // txtAcName
            // 
            this.txtAcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcName.Location = new System.Drawing.Point(474, 11);
            this.txtAcName.Name = "txtAcName";
            this.txtAcName.Size = new System.Drawing.Size(304, 20);
            this.txtAcName.TabIndex = 52;
            // 
            // lblOpBal
            // 
            this.lblOpBal.BackColor = System.Drawing.Color.White;
            this.lblOpBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOpBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpBal.Location = new System.Drawing.Point(474, 66);
            this.lblOpBal.Name = "lblOpBal";
            this.lblOpBal.Size = new System.Drawing.Size(304, 18);
            this.lblOpBal.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(474, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 18);
            this.label7.TabIndex = 51;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(381, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 48;
            this.label10.Text = "Op.Balance : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(401, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 47;
            this.label11.Text = "Balance : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(364, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 15);
            this.label12.TabIndex = 46;
            this.label12.Text = "Account Name : ";
            // 
            // msk_ToDate
            // 
            this.msk_ToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_ToDate.Location = new System.Drawing.Point(165, 68);
            this.msk_ToDate.Mask = "00/00/0000";
            this.msk_ToDate.Name = "msk_ToDate";
            this.msk_ToDate.Size = new System.Drawing.Size(82, 20);
            this.msk_ToDate.TabIndex = 45;
            this.msk_ToDate.Text = "30102012";
            this.msk_ToDate.ValidatingType = typeof(System.DateTime);
            // 
            // msk_FromDate
            // 
            this.msk_FromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_FromDate.Location = new System.Drawing.Point(165, 39);
            this.msk_FromDate.Mask = "00/00/0000";
            this.msk_FromDate.Name = "msk_FromDate";
            this.msk_FromDate.Size = new System.Drawing.Size(82, 20);
            this.msk_FromDate.TabIndex = 44;
            this.msk_FromDate.Text = "25082012";
            this.msk_FromDate.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(73, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Credit Limit : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "Phone # : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 40;
            this.label3.Text = "To Date : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "From Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Group Account ID : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // optBal
            // 
            this.optBal.AutoSize = true;
            this.optBal.Checked = true;
            this.optBal.Location = new System.Drawing.Point(474, 88);
            this.optBal.Margin = new System.Windows.Forms.Padding(2);
            this.optBal.Name = "optBal";
            this.optBal.Size = new System.Drawing.Size(64, 17);
            this.optBal.TabIndex = 66;
            this.optBal.TabStop = true;
            this.optBal.Text = "Balance";
            this.optBal.UseVisualStyleBackColor = true;
            // 
            // OptDetail
            // 
            this.OptDetail.AutoSize = true;
            this.OptDetail.Location = new System.Drawing.Point(768, 88);
            this.OptDetail.Margin = new System.Windows.Forms.Padding(2);
            this.OptDetail.Name = "OptDetail";
            this.OptDetail.Size = new System.Drawing.Size(52, 17);
            this.OptDetail.TabIndex = 67;
            this.OptDetail.Text = "Detail";
            this.OptDetail.UseVisualStyleBackColor = true;
            this.OptDetail.Visible = false;
            // 
            // OptComp
            // 
            this.OptComp.AutoSize = true;
            this.OptComp.Location = new System.Drawing.Point(637, 155);
            this.OptComp.Margin = new System.Windows.Forms.Padding(2);
            this.OptComp.Name = "OptComp";
            this.OptComp.Size = new System.Drawing.Size(85, 17);
            this.OptComp.TabIndex = 68;
            this.OptComp.Text = "Month Comp";
            this.OptComp.UseVisualStyleBackColor = true;
            this.OptComp.Visible = false;
            // 
            // optAging
            // 
            this.optAging.AutoSize = true;
            this.optAging.Location = new System.Drawing.Point(768, 110);
            this.optAging.Margin = new System.Windows.Forms.Padding(2);
            this.optAging.Name = "optAging";
            this.optAging.Size = new System.Drawing.Size(52, 17);
            this.optAging.TabIndex = 69;
            this.optAging.Text = "Aging";
            this.optAging.UseVisualStyleBackColor = true;
            this.optAging.Visible = false;
            // 
            // OptCompBal
            // 
            this.OptCompBal.AutoSize = true;
            this.OptCompBal.Location = new System.Drawing.Point(637, 110);
            this.OptCompBal.Margin = new System.Windows.Forms.Padding(2);
            this.OptCompBal.Name = "OptCompBal";
            this.OptCompBal.Size = new System.Drawing.Size(127, 17);
            this.OptCompBal.TabIndex = 70;
            this.OptCompBal.Text = "Month Comp Balance";
            this.OptCompBal.UseVisualStyleBackColor = true;
            this.OptCompBal.Visible = false;
            // 
            // optCOA
            // 
            this.optCOA.AutoSize = true;
            this.optCOA.Location = new System.Drawing.Point(637, 88);
            this.optCOA.Margin = new System.Windows.Forms.Padding(2);
            this.optCOA.Name = "optCOA";
            this.optCOA.Size = new System.Drawing.Size(110, 17);
            this.optCOA.TabIndex = 71;
            this.optCOA.Text = "Chart of Accounts";
            this.optCOA.UseVisualStyleBackColor = true;
            this.optCOA.Visible = false;
            // 
            // OptTrial
            // 
            this.OptTrial.AutoSize = true;
            this.OptTrial.Location = new System.Drawing.Point(381, 89);
            this.OptTrial.Margin = new System.Windows.Forms.Padding(2);
            this.OptTrial.Name = "OptTrial";
            this.OptTrial.Size = new System.Drawing.Size(87, 17);
            this.OptTrial.TabIndex = 72;
            this.OptTrial.Text = "Trial Balance";
            this.OptTrial.UseVisualStyleBackColor = true;
            this.OptTrial.Visible = false;
            // 
            // OptTrialOp
            // 
            this.OptTrialOp.AutoSize = true;
            this.OptTrialOp.Location = new System.Drawing.Point(381, 110);
            this.OptTrialOp.Margin = new System.Windows.Forms.Padding(2);
            this.OptTrialOp.Name = "OptTrialOp";
            this.OptTrialOp.Size = new System.Drawing.Size(130, 17);
            this.OptTrialOp.TabIndex = 73;
            this.OptTrialOp.Text = "Trial Balance Opening";
            this.OptTrialOp.UseVisualStyleBackColor = true;
            this.OptTrialOp.Visible = false;
            // 
            // optWithoutOpBal
            // 
            this.optWithoutOpBal.AutoSize = true;
            this.optWithoutOpBal.Location = new System.Drawing.Point(542, 89);
            this.optWithoutOpBal.Margin = new System.Windows.Forms.Padding(2);
            this.optWithoutOpBal.Name = "optWithoutOpBal";
            this.optWithoutOpBal.Size = new System.Drawing.Size(97, 17);
            this.optWithoutOpBal.TabIndex = 74;
            this.optWithoutOpBal.Text = "Without Op.Bal";
            this.optWithoutOpBal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optWithoutOpBal.UseVisualStyleBackColor = true;
            // 
            // optCOA_Addr
            // 
            this.optCOA_Addr.AutoSize = true;
            this.optCOA_Addr.Location = new System.Drawing.Point(419, 198);
            this.optCOA_Addr.Margin = new System.Windows.Forms.Padding(2);
            this.optCOA_Addr.Name = "optCOA_Addr";
            this.optCOA_Addr.Size = new System.Drawing.Size(157, 17);
            this.optCOA_Addr.TabIndex = 75;
            this.optCOA_Addr.Text = "Chart of Accounts (Address)";
            this.optCOA_Addr.UseVisualStyleBackColor = true;
            this.optCOA_Addr.Visible = false;
            // 
            // optCustAddr
            // 
            this.optCustAddr.AutoSize = true;
            this.optCustAddr.Location = new System.Drawing.Point(419, 177);
            this.optCustAddr.Margin = new System.Windows.Forms.Padding(2);
            this.optCustAddr.Name = "optCustAddr";
            this.optCustAddr.Size = new System.Drawing.Size(110, 17);
            this.optCustAddr.TabIndex = 76;
            this.optCustAddr.Text = "Customer Address";
            this.optCustAddr.UseVisualStyleBackColor = true;
            this.optCustAddr.Visible = false;
            // 
            // optCOA_Group
            // 
            this.optCOA_Group.AutoSize = true;
            this.optCOA_Group.Location = new System.Drawing.Point(533, 177);
            this.optCOA_Group.Margin = new System.Windows.Forms.Padding(2);
            this.optCOA_Group.Name = "optCOA_Group";
            this.optCOA_Group.Size = new System.Drawing.Size(148, 17);
            this.optCOA_Group.TabIndex = 77;
            this.optCOA_Group.Text = "Chart of Accounts (Group)";
            this.optCOA_Group.UseVisualStyleBackColor = true;
            this.optCOA_Group.Visible = false;
            // 
            // optCOA_Detail
            // 
            this.optCOA_Detail.AutoSize = true;
            this.optCOA_Detail.Location = new System.Drawing.Point(685, 177);
            this.optCOA_Detail.Margin = new System.Windows.Forms.Padding(2);
            this.optCOA_Detail.Name = "optCOA_Detail";
            this.optCOA_Detail.Size = new System.Drawing.Size(146, 17);
            this.optCOA_Detail.TabIndex = 78;
            this.optCOA_Detail.Text = "Chart of Accounts (Detail)";
            this.optCOA_Detail.UseVisualStyleBackColor = true;
            this.optCOA_Detail.Visible = false;
            // 
            // optAgingGLCode
            // 
            this.optAgingGLCode.AutoSize = true;
            this.optAgingGLCode.Location = new System.Drawing.Point(768, 156);
            this.optAgingGLCode.Margin = new System.Windows.Forms.Padding(2);
            this.optAgingGLCode.Name = "optAgingGLCode";
            this.optAgingGLCode.Size = new System.Drawing.Size(97, 17);
            this.optAgingGLCode.TabIndex = 79;
            this.optAgingGLCode.Text = "Aging GL Code";
            this.optAgingGLCode.UseVisualStyleBackColor = true;
            this.optAgingGLCode.Visible = false;
            // 
            // OptTrialComplete
            // 
            this.OptTrialComplete.AutoSize = true;
            this.OptTrialComplete.Location = new System.Drawing.Point(381, 131);
            this.OptTrialComplete.Margin = new System.Windows.Forms.Padding(2);
            this.OptTrialComplete.Name = "OptTrialComplete";
            this.OptTrialComplete.Size = new System.Drawing.Size(134, 17);
            this.OptTrialComplete.TabIndex = 80;
            this.OptTrialComplete.Text = "Trial Balance Complete";
            this.OptTrialComplete.UseVisualStyleBackColor = true;
            this.OptTrialComplete.Visible = false;
            // 
            // OptTrialGroup
            // 
            this.OptTrialGroup.AutoSize = true;
            this.OptTrialGroup.Location = new System.Drawing.Point(381, 152);
            this.OptTrialGroup.Margin = new System.Windows.Forms.Padding(2);
            this.OptTrialGroup.Name = "OptTrialGroup";
            this.OptTrialGroup.Size = new System.Drawing.Size(119, 17);
            this.OptTrialGroup.TabIndex = 81;
            this.OptTrialGroup.Text = "Trial Balance Group";
            this.OptTrialGroup.UseVisualStyleBackColor = true;
            this.OptTrialGroup.Visible = false;
            // 
            // btn_ToDate
            // 
            this.btn_ToDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_ToDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ToDate.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_ToDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ToDate.Location = new System.Drawing.Point(253, 68);
            this.btn_ToDate.Name = "btn_ToDate";
            this.btn_ToDate.Size = new System.Drawing.Size(62, 26);
            this.btn_ToDate.TabIndex = 65;
            this.btn_ToDate.TabStop = false;
            this.btn_ToDate.Text = "&Month";
            this.btn_ToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ToDate.UseVisualStyleBackColor = true;
            this.btn_ToDate.Click += new System.EventHandler(this.btn_ToDate_Click);
            // 
            // btn_FromDate
            // 
            this.btn_FromDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_FromDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_FromDate.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_FromDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FromDate.Location = new System.Drawing.Point(253, 39);
            this.btn_FromDate.Name = "btn_FromDate";
            this.btn_FromDate.Size = new System.Drawing.Size(62, 26);
            this.btn_FromDate.TabIndex = 64;
            this.btn_FromDate.TabStop = false;
            this.btn_FromDate.Text = "&Month";
            this.btn_FromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FromDate.UseVisualStyleBackColor = true;
            this.btn_FromDate.Click += new System.EventHandler(this.btn_FromDate_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Image = global::TaxSolution.Properties.Resources.FormExit;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(765, 207);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(74, 30);
            this.btn_Exit.TabIndex = 63;
            this.btn_Exit.Text = "E&xit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_View
            // 
            this.btn_View.Image = global::TaxSolution.Properties.Resources.preview_16x16;
            this.btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View.Location = new System.Drawing.Point(685, 207);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(74, 30);
            this.btn_View.TabIndex = 62;
            this.btn_View.Text = "&View";
            this.btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Image = global::TaxSolution.Properties.Resources.PrinterSmall_ico;
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.Location = new System.Drawing.Point(596, 206);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(83, 32);
            this.btn_Print.TabIndex = 61;
            this.btn_Print.Text = "&Print";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Detail Information";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 500;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Type";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Detail Information";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 500;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Desc";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // frmPeriodGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 512);
            this.Controls.Add(this.OptTrialGroup);
            this.Controls.Add(this.OptTrialComplete);
            this.Controls.Add(this.optAgingGLCode);
            this.Controls.Add(this.optCOA_Detail);
            this.Controls.Add(this.optCOA_Group);
            this.Controls.Add(this.optCustAddr);
            this.Controls.Add(this.optCOA_Addr);
            this.Controls.Add(this.optWithoutOpBal);
            this.Controls.Add(this.OptTrialOp);
            this.Controls.Add(this.OptTrial);
            this.Controls.Add(this.optCOA);
            this.Controls.Add(this.OptCompBal);
            this.Controls.Add(this.optAging);
            this.Controls.Add(this.OptComp);
            this.Controls.Add(this.OptDetail);
            this.Controls.Add(this.optBal);
            this.Controls.Add(this.btn_ToDate);
            this.Controls.Add(this.btn_FromDate);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.lblTotalDebit);
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.pnlCalander);
            this.Controls.Add(this.msk_AccountID);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtAcName);
            this.Controls.Add(this.lblOpBal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.msk_ToDate);
            this.Controls.Add(this.msk_FromDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPeriodGroup";
            this.Text = "Period Wise Group Report";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLedger_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLedger_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdPostDtdChq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDishChq)).EndInit();
            this.tabDishChq.ResumeLayout(false);
            this.tabPostDateChq.ResumeLayout(false);
            this.tabTranSmry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSmry)).EndInit();
            this.tabPersonalInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonalInfo)).EndInit();
            this.pnlCalander.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabLedgerStatment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_HideMonth;
        private System.Windows.Forms.DataGridView grdPostDtdChq;
        private System.Windows.Forms.Label lblTotalDebit;
        private System.Windows.Forms.DataGridView grdDishChq;
        private System.Windows.Forms.TabPage tabDishChq;
        private System.Windows.Forms.TabPage tabPostDateChq;
        private System.Windows.Forms.Label lblTotalCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.TabPage tabTranSmry;
        private System.Windows.Forms.DataGridView grdSmry;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.DataGridView grdPersonalInfo;
        private System.Windows.Forms.Panel pnlCalander;
        private System.Windows.Forms.MonthCalendar mCalendarMain;
        private System.Windows.Forms.MaskedTextBox msk_AccountID;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn2;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLedgerStatment;
        private System.Windows.Forms.DataGridView grdDetail;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtAcName;
        private System.Windows.Forms.Label lblOpBal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox msk_ToDate;
        private System.Windows.Forms.MaskedTextBox msk_FromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Button btn_ToDate;
        private System.Windows.Forms.Button btn_FromDate;
        private System.Windows.Forms.RadioButton optBal;
        private System.Windows.Forms.RadioButton OptDetail;
        private System.Windows.Forms.RadioButton OptComp;
        private System.Windows.Forms.RadioButton optAging;
        private System.Windows.Forms.RadioButton OptCompBal;
        private System.Windows.Forms.RadioButton optCOA;
        private System.Windows.Forms.RadioButton OptTrial;
        private System.Windows.Forms.RadioButton OptTrialOp;
        private System.Windows.Forms.RadioButton optWithoutOpBal;
        private System.Windows.Forms.RadioButton optCOA_Addr;
        private System.Windows.Forms.RadioButton optCustAddr;
        private System.Windows.Forms.RadioButton optCOA_Group;
        private System.Windows.Forms.RadioButton optCOA_Detail;
        private System.Windows.Forms.RadioButton optAgingGLCode;
        private System.Windows.Forms.RadioButton OptTrialComplete;
        private System.Windows.Forms.RadioButton OptTrialGroup;
    }
}