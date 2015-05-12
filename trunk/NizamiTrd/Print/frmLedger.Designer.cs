namespace TestFormApp.TestForm
{
    partial class frmLedger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msk_AccountID = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.msk_FromDate = new System.Windows.Forms.MaskedTextBox();
            this.msk_ToDate = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAcName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLedgerStatment = new System.Windows.Forms.TabPage();
            this.grdDetail = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voc_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDebit = new CSUST.Data.TNumEditDataGridViewColumn();
            this.colCredit = new CSUST.Data.TNumEditDataGridViewColumn();
            this.colBalance = new CSUST.Data.TNumEditDataGridViewColumn();
            this.tabTranSmry = new System.Windows.Forms.TabPage();
            this.grdSmry = new System.Windows.Forms.DataGridView();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.grdPersonalInfo = new System.Windows.Forms.DataGridView();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPostDateChq = new System.Windows.Forms.TabPage();
            this.grdPostDtdChq = new System.Windows.Forms.DataGridView();
            this.tabDishChq = new System.Windows.Forms.TabPage();
            this.grdDishChq = new System.Windows.Forms.DataGridView();
            this.pnlCalander = new System.Windows.Forms.Panel();
            this.btn_HideMonth = new System.Windows.Forms.Button();
            this.mCalendarMain = new System.Windows.Forms.MonthCalendar();
            this.lblTotalDebit = new System.Windows.Forms.Label();
            this.lblTotalCredit = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tNumEditDataGridViewColumn1 = new CSUST.Data.TNumEditDataGridViewColumn();
            this.tNumEditDataGridViewColumn2 = new CSUST.Data.TNumEditDataGridViewColumn();
            this.tNumEditDataGridViewColumn3 = new CSUST.Data.TNumEditDataGridViewColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_View = new System.Windows.Forms.Button();
            this.btn_ToDate = new System.Windows.Forms.Button();
            this.btn_FromDate = new System.Windows.Forms.Button();
            this.cachedCrystal_city1 = new TestFormApp.CachedCrystal_city();
            this.cachedCrystal_city2 = new TestFormApp.CachedCrystal_city();
            this.tabControl1.SuspendLayout();
            this.tabLedgerStatment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.tabTranSmry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSmry)).BeginInit();
            this.tabPersonalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonalInfo)).BeginInit();
            this.tabPostDateChq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPostDtdChq)).BeginInit();
            this.tabDishChq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDishChq)).BeginInit();
            this.pnlCalander.SuspendLayout();
            this.SuspendLayout();
            // 
            // msk_AccountID
            // 
            this.msk_AccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_AccountID.Location = new System.Drawing.Point(122, 12);
            this.msk_AccountID.Mask = "#-#-##-##-####";
            this.msk_AccountID.Name = "msk_AccountID";
            this.msk_AccountID.Size = new System.Drawing.Size(137, 20);
            this.msk_AccountID.TabIndex = 0;
            this.msk_AccountID.Text = "1203010002";
            this.msk_AccountID.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.msk_AccountID_MaskInputRejected);
            this.msk_AccountID.Validating += new System.ComponentModel.CancelEventHandler(this.mskValidating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account ID : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "From Date : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "To Date : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Phone # : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Credit Limit : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(432, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Account ID";
            // 
            // msk_FromDate
            // 
            this.msk_FromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_FromDate.Location = new System.Drawing.Point(123, 40);
            this.msk_FromDate.Mask = "00/00/0000";
            this.msk_FromDate.Name = "msk_FromDate";
            this.msk_FromDate.Size = new System.Drawing.Size(82, 20);
            this.msk_FromDate.TabIndex = 17;
            this.msk_FromDate.Text = "01012010";
            this.msk_FromDate.ValidatingType = typeof(System.DateTime);
            // 
            // msk_ToDate
            // 
            this.msk_ToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_ToDate.Location = new System.Drawing.Point(123, 69);
            this.msk_ToDate.Mask = "00/00/0000";
            this.msk_ToDate.Name = "msk_ToDate";
            this.msk_ToDate.Size = new System.Drawing.Size(82, 20);
            this.msk_ToDate.TabIndex = 19;
            this.msk_ToDate.Text = "30102012";
            this.msk_ToDate.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(432, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 18);
            this.label7.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(353, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Account ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(353, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Account ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(339, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "Op.Balance : ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(359, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Balance : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(322, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Account Name : ";
            // 
            // txtAcName
            // 
            this.txtAcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcName.Location = new System.Drawing.Point(432, 12);
            this.txtAcName.Name = "txtAcName";
            this.txtAcName.Size = new System.Drawing.Size(304, 20);
            this.txtAcName.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(432, 67);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(304, 18);
            this.label13.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(122, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(183, 18);
            this.label14.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(122, 124);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(183, 18);
            this.label15.TabIndex = 30;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 458);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(867, 22);
            this.statusBar.TabIndex = 31;
            this.statusBar.Text = "status Bar";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLedgerStatment);
            this.tabControl1.Controls.Add(this.tabTranSmry);
            this.tabControl1.Controls.Add(this.tabPersonalInfo);
            this.tabControl1.Controls.Add(this.tabPostDateChq);
            this.tabControl1.Controls.Add(this.tabDishChq);
            this.tabControl1.Location = new System.Drawing.Point(16, 161);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 264);
            this.tabControl1.TabIndex = 32;
            // 
            // tabLedgerStatment
            // 
            this.tabLedgerStatment.Controls.Add(this.grdDetail);
            this.tabLedgerStatment.Location = new System.Drawing.Point(4, 22);
            this.tabLedgerStatment.Name = "tabLedgerStatment";
            this.tabLedgerStatment.Padding = new System.Windows.Forms.Padding(3);
            this.tabLedgerStatment.Size = new System.Drawing.Size(831, 238);
            this.tabLedgerStatment.TabIndex = 0;
            this.tabLedgerStatment.Text = "Ledger Statement";
            this.tabLedgerStatment.UseVisualStyleBackColor = true;
            // 
            // grdDetail
            // 
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Voc_No,
            this.Description,
            this.colDebit,
            this.colCredit,
            this.colBalance});
            this.grdDetail.Location = new System.Drawing.Point(6, 6);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDetail.Size = new System.Drawing.Size(819, 226);
            this.grdDetail.TabIndex = 2;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Voc_No
            // 
            this.Voc_No.HeaderText = "Voucher #";
            this.Voc_No.Name = "Voc_No";
            // 
            // Description
            // 
            this.Description.HeaderText = "Desc";
            this.Description.Name = "Description";
            // 
            // colDebit
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "F0";
            this.colDebit.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDebit.HeaderText = "Debit";
            this.colDebit.Name = "colDebit";
            // 
            // colCredit
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "F0";
            this.colCredit.DefaultCellStyle = dataGridViewCellStyle2;
            this.colCredit.HeaderText = "Credit";
            this.colCredit.Name = "colCredit";
            // 
            // colBalance
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "F0";
            this.colBalance.DefaultCellStyle = dataGridViewCellStyle3;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            // 
            // tabTranSmry
            // 
            this.tabTranSmry.Controls.Add(this.grdSmry);
            this.tabTranSmry.Location = new System.Drawing.Point(4, 22);
            this.tabTranSmry.Name = "tabTranSmry";
            this.tabTranSmry.Padding = new System.Windows.Forms.Padding(3);
            this.tabTranSmry.Size = new System.Drawing.Size(831, 238);
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
            this.grdSmry.Size = new System.Drawing.Size(819, 214);
            this.grdSmry.TabIndex = 3;
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.grdPersonalInfo);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Size = new System.Drawing.Size(831, 238);
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
            this.grdPersonalInfo.Size = new System.Drawing.Size(633, 212);
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
            // tabPostDateChq
            // 
            this.tabPostDateChq.Controls.Add(this.grdPostDtdChq);
            this.tabPostDateChq.Location = new System.Drawing.Point(4, 22);
            this.tabPostDateChq.Name = "tabPostDateChq";
            this.tabPostDateChq.Size = new System.Drawing.Size(831, 238);
            this.tabPostDateChq.TabIndex = 3;
            this.tabPostDateChq.Text = "Post Dated Cheques";
            this.tabPostDateChq.UseVisualStyleBackColor = true;
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
            this.grdPostDtdChq.Size = new System.Drawing.Size(819, 214);
            this.grdPostDtdChq.TabIndex = 3;
            // 
            // tabDishChq
            // 
            this.tabDishChq.Controls.Add(this.grdDishChq);
            this.tabDishChq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDishChq.Location = new System.Drawing.Point(4, 22);
            this.tabDishChq.Name = "tabDishChq";
            this.tabDishChq.Size = new System.Drawing.Size(831, 238);
            this.tabDishChq.TabIndex = 4;
            this.tabDishChq.Text = "Dishonoured Cheques";
            this.tabDishChq.UseVisualStyleBackColor = true;
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
            this.grdDishChq.Size = new System.Drawing.Size(819, 214);
            this.grdDishChq.TabIndex = 3;
            // 
            // pnlCalander
            // 
            this.pnlCalander.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalander.Controls.Add(this.btn_HideMonth);
            this.pnlCalander.Controls.Add(this.mCalendarMain);
            this.pnlCalander.Location = new System.Drawing.Point(279, 38);
            this.pnlCalander.Name = "pnlCalander";
            this.pnlCalander.Size = new System.Drawing.Size(234, 215);
            this.pnlCalander.TabIndex = 33;
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
            // lblTotalDebit
            // 
            this.lblTotalDebit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDebit.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalDebit.Location = new System.Drawing.Point(603, 428);
            this.lblTotalDebit.Name = "lblTotalDebit";
            this.lblTotalDebit.Size = new System.Drawing.Size(118, 20);
            this.lblTotalDebit.TabIndex = 35;
            this.lblTotalDebit.Text = "0.00";
            this.lblTotalDebit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCredit.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalCredit.Location = new System.Drawing.Point(727, 428);
            this.lblTotalCredit.Name = "lblTotalCredit";
            this.lblTotalCredit.Size = new System.Drawing.Size(118, 20);
            this.lblTotalCredit.TabIndex = 36;
            this.lblTotalCredit.Text = "0.00";
            this.lblTotalCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Desc";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // tNumEditDataGridViewColumn1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F0";
            this.tNumEditDataGridViewColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.tNumEditDataGridViewColumn1.HeaderText = "Debit";
            this.tNumEditDataGridViewColumn1.Name = "tNumEditDataGridViewColumn1";
            // 
            // tNumEditDataGridViewColumn2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "F0";
            this.tNumEditDataGridViewColumn2.DefaultCellStyle = dataGridViewCellStyle5;
            this.tNumEditDataGridViewColumn2.HeaderText = "Credit";
            this.tNumEditDataGridViewColumn2.Name = "tNumEditDataGridViewColumn2";
            // 
            // tNumEditDataGridViewColumn3
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "F0";
            this.tNumEditDataGridViewColumn3.DefaultCellStyle = dataGridViewCellStyle6;
            this.tNumEditDataGridViewColumn3.HeaderText = "Balance";
            this.tNumEditDataGridViewColumn3.Name = "tNumEditDataGridViewColumn3";
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
            // btn_Print
            // 
            this.btn_Print.Image = global::TestFormApp.Properties.Resources.Printersmalest;
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.Location = new System.Drawing.Point(662, 92);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(89, 45);
            this.btn_Print.TabIndex = 38;
            this.btn_Print.Text = "&Print";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Image = global::TestFormApp.Properties.Resources.BaBa_FormExit;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(742, 147);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(74, 30);
            this.btn_Exit.TabIndex = 37;
            this.btn_Exit.Text = "E&xit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_View
            // 
            this.btn_View.Image = global::TestFormApp.Properties.Resources.BaBa_preview;
            this.btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View.Location = new System.Drawing.Point(662, 147);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(74, 30);
            this.btn_View.TabIndex = 34;
            this.btn_View.Text = "&View";
            this.btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btn_ToDate
            // 
            this.btn_ToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ToDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ToDate.Image = global::TestFormApp.Properties.Resources.BaBa_Calendar;
            this.btn_ToDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ToDate.Location = new System.Drawing.Point(211, 67);
            this.btn_ToDate.Name = "btn_ToDate";
            this.btn_ToDate.Size = new System.Drawing.Size(62, 26);
            this.btn_ToDate.TabIndex = 20;
            this.btn_ToDate.TabStop = false;
            this.btn_ToDate.Text = "&Month";
            this.btn_ToDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ToDate.UseVisualStyleBackColor = true;
            this.btn_ToDate.Click += new System.EventHandler(this.btn_ToDate_Click);
            // 
            // btn_FromDate
            // 
            this.btn_FromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FromDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_FromDate.Image = global::TestFormApp.Properties.Resources.BaBa_Calendar;
            this.btn_FromDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FromDate.Location = new System.Drawing.Point(211, 38);
            this.btn_FromDate.Name = "btn_FromDate";
            this.btn_FromDate.Size = new System.Drawing.Size(62, 26);
            this.btn_FromDate.TabIndex = 18;
            this.btn_FromDate.TabStop = false;
            this.btn_FromDate.Text = "&Month";
            this.btn_FromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FromDate.UseVisualStyleBackColor = true;
            this.btn_FromDate.Click += new System.EventHandler(this.btn_FromDate_Click);
            // 
            // frmLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 480);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lblTotalDebit);
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.pnlCalander);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtAcName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_ToDate);
            this.Controls.Add(this.msk_ToDate);
            this.Controls.Add(this.btn_FromDate);
            this.Controls.Add(this.msk_FromDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.msk_AccountID);
            this.Name = "frmLedger";
            this.Text = "Ledger Printing";
            this.tabControl1.ResumeLayout(false);
            this.tabLedgerStatment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.tabTranSmry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSmry)).EndInit();
            this.tabPersonalInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPersonalInfo)).EndInit();
            this.tabPostDateChq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPostDtdChq)).EndInit();
            this.tabDishChq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDishChq)).EndInit();
            this.pnlCalander.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox msk_AccountID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_FromDate;
        private System.Windows.Forms.MaskedTextBox msk_FromDate;
        private System.Windows.Forms.Button btn_ToDate;
        private System.Windows.Forms.MaskedTextBox msk_ToDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAcName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLedgerStatment;
        private System.Windows.Forms.TabPage tabTranSmry;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.TabPage tabPostDateChq;
        private System.Windows.Forms.TabPage tabDishChq;
        private System.Windows.Forms.DataGridView grdDetail;
        private System.Windows.Forms.DataGridView grdSmry;
        private System.Windows.Forms.DataGridView grdPostDtdChq;
        private System.Windows.Forms.DataGridView grdDishChq;
        private System.Windows.Forms.DataGridView grdPersonalInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel pnlCalander;
        private System.Windows.Forms.Button btn_HideMonth;
        private System.Windows.Forms.MonthCalendar mCalendarMain;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Label lblTotalDebit;
        private System.Windows.Forms.Label lblTotalCredit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voc_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private CSUST.Data.TNumEditDataGridViewColumn colDebit;
        private CSUST.Data.TNumEditDataGridViewColumn colCredit;
        private CSUST.Data.TNumEditDataGridViewColumn colBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn1;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn2;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Print;
        private CachedCrystal_city cachedCrystal_city1;
        private CachedCrystal_city cachedCrystal_city2;
    }
}