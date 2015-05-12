namespace TaxSolution
{
    partial class frmItemLedgerShop
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.msk_ItemID = new System.Windows.Forms.MaskedTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabItemLedger = new System.Windows.Forms.TabPage();
            this.grdDetail = new System.Windows.Forms.DataGridView();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lblOpBal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.msk_ToDate = new System.Windows.Forms.MaskedTextBox();
            this.msk_FromDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGodown = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ToDate = new System.Windows.Forms.Button();
            this.btn_FromDate = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_View = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.cboGodown = new System.Windows.Forms.ComboBox();
            this.cbo_UOM = new System.Windows.Forms.ComboBox();
            this.OptItemLedger = new System.Windows.Forms.RadioButton();
            this.OptGeneralItemLedger = new System.Windows.Forms.RadioButton();
            this.OptItemLedgerShopItem = new System.Windows.Forms.RadioButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tNumEditDataGridViewColumn3 = new CSUST.Data.TNumEditDataGridViewColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tNumEditDataGridViewColumn2 = new CSUST.Data.TNumEditDataGridViewColumn();
            this.tNumEditDataGridViewColumn1 = new CSUST.Data.TNumEditDataGridViewColumn();
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
            this.tabItemLedger.SuspendLayout();
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
            this.grdPostDtdChq.Size = new System.Drawing.Size(819, 209);
            this.grdPostDtdChq.TabIndex = 3;
            // 
            // lblTotalDebit
            // 
            this.lblTotalDebit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalDebit.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalDebit.Location = new System.Drawing.Point(596, 414);
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
            this.grdDishChq.Size = new System.Drawing.Size(819, 213);
            this.grdDishChq.TabIndex = 3;
            // 
            // tabDishChq
            // 
            this.tabDishChq.Controls.Add(this.grdDishChq);
            this.tabDishChq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDishChq.Location = new System.Drawing.Point(4, 22);
            this.tabDishChq.Name = "tabDishChq";
            this.tabDishChq.Size = new System.Drawing.Size(831, 225);
            this.tabDishChq.TabIndex = 4;
            this.tabDishChq.Text = "Dishonoured Cheques";
            this.tabDishChq.UseVisualStyleBackColor = true;
            // 
            // tabPostDateChq
            // 
            this.tabPostDateChq.Controls.Add(this.grdPostDtdChq);
            this.tabPostDateChq.Location = new System.Drawing.Point(4, 22);
            this.tabPostDateChq.Name = "tabPostDateChq";
            this.tabPostDateChq.Size = new System.Drawing.Size(831, 225);
            this.tabPostDateChq.TabIndex = 3;
            this.tabPostDateChq.Text = "Post Dated Cheques";
            this.tabPostDateChq.UseVisualStyleBackColor = true;
            // 
            // lblTotalCredit
            // 
            this.lblTotalCredit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCredit.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalCredit.Location = new System.Drawing.Point(720, 414);
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
            this.tabTranSmry.Size = new System.Drawing.Size(831, 225);
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
            this.grdSmry.Size = new System.Drawing.Size(819, 212);
            this.grdSmry.TabIndex = 3;
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.grdPersonalInfo);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Size = new System.Drawing.Size(831, 225);
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
            this.pnlCalander.Location = new System.Drawing.Point(287, 38);
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
            // msk_ItemID
            // 
            this.msk_ItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_ItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_ItemID.Location = new System.Drawing.Point(113, 11);
            this.msk_ItemID.Mask = "#######";
            this.msk_ItemID.Name = "msk_ItemID";
            this.msk_ItemID.Size = new System.Drawing.Size(97, 20);
            this.msk_ItemID.TabIndex = 1;
            this.msk_ItemID.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.msk_ItemID_MaskInputRejected);
            this.msk_ItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msk_ItemID_KeyDown);
            this.msk_ItemID.Leave += new System.EventHandler(this.msk_ItemID_Leave);
            this.msk_ItemID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.msk_ItemID_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabItemLedger);
            this.tabControl1.Controls.Add(this.tabTranSmry);
            this.tabControl1.Controls.Add(this.tabPersonalInfo);
            this.tabControl1.Controls.Add(this.tabPostDateChq);
            this.tabControl1.Controls.Add(this.tabDishChq);
            this.tabControl1.Location = new System.Drawing.Point(6, 160);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 251);
            this.tabControl1.TabIndex = 13;
            // 
            // tabItemLedger
            // 
            this.tabItemLedger.Controls.Add(this.grdDetail);
            this.tabItemLedger.Location = new System.Drawing.Point(4, 22);
            this.tabItemLedger.Name = "tabItemLedger";
            this.tabItemLedger.Padding = new System.Windows.Forms.Padding(3);
            this.tabItemLedger.Size = new System.Drawing.Size(831, 225);
            this.tabItemLedger.TabIndex = 0;
            this.tabItemLedger.Text = "Item Ledger";
            this.tabItemLedger.UseVisualStyleBackColor = true;
            // 
            // grdDetail
            // 
            this.grdDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetail.Location = new System.Drawing.Point(6, 6);
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdDetail.Size = new System.Drawing.Size(819, 214);
            this.grdDetail.TabIndex = 0;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 447);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(865, 22);
            this.statusBar.TabIndex = 56;
            this.statusBar.Text = "status Bar";
            // 
            // lblOpBal
            // 
            this.lblOpBal.BackColor = System.Drawing.Color.White;
            this.lblOpBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOpBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpBal.Location = new System.Drawing.Point(422, 66);
            this.lblOpBal.Name = "lblOpBal";
            this.lblOpBal.Size = new System.Drawing.Size(304, 18);
            this.lblOpBal.TabIndex = 53;
            this.lblOpBal.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(422, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(304, 18);
            this.label7.TabIndex = 51;
            this.label7.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(329, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 48;
            this.label10.Text = "Op.Balance : ";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(349, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 15);
            this.label11.TabIndex = 47;
            this.label11.Text = "Balance : ";
            this.label11.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(335, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 15);
            this.label12.TabIndex = 46;
            this.label12.Text = "Item Name : ";
            // 
            // msk_ToDate
            // 
            this.msk_ToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_ToDate.Location = new System.Drawing.Point(113, 68);
            this.msk_ToDate.Mask = "00/00/0000";
            this.msk_ToDate.Name = "msk_ToDate";
            this.msk_ToDate.Size = new System.Drawing.Size(96, 20);
            this.msk_ToDate.TabIndex = 5;
            this.msk_ToDate.Text = "30102012";
            this.msk_ToDate.ValidatingType = typeof(System.DateTime);
            // 
            // msk_FromDate
            // 
            this.msk_FromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_FromDate.Location = new System.Drawing.Point(113, 39);
            this.msk_FromDate.Mask = "00/00/0000";
            this.msk_FromDate.Name = "msk_FromDate";
            this.msk_FromDate.Size = new System.Drawing.Size(96, 20);
            this.msk_FromDate.TabIndex = 3;
            this.msk_FromDate.Text = "25082012";
            this.msk_FromDate.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(57, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "UOM : ";
            // 
            // lblGodown
            // 
            this.lblGodown.AutoSize = true;
            this.lblGodown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGodown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGodown.Location = new System.Drawing.Point(39, 101);
            this.lblGodown.Name = "lblGodown";
            this.lblGodown.Size = new System.Drawing.Size(67, 15);
            this.lblGodown.TabIndex = 6;
            this.lblGodown.Text = "Godown : ";
            this.lblGodown.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "To Date : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "From Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item ID : ";
            // 
            // btn_ToDate
            // 
            this.btn_ToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ToDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ToDate.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_ToDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ToDate.Location = new System.Drawing.Point(216, 66);
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
            this.btn_FromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FromDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_FromDate.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_FromDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FromDate.Location = new System.Drawing.Point(216, 37);
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
            this.btn_Exit.Location = new System.Drawing.Point(765, 129);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(74, 30);
            this.btn_Exit.TabIndex = 12;
            this.btn_Exit.Text = "E&xit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_View
            // 
            this.btn_View.Image = global::TaxSolution.Properties.Resources.preview_16x16;
            this.btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View.Location = new System.Drawing.Point(685, 129);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(74, 30);
            this.btn_View.TabIndex = 11;
            this.btn_View.Text = "&View";
            this.btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Image = global::TaxSolution.Properties.Resources.PrinterSmall_ico;
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.Location = new System.Drawing.Point(596, 128);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(83, 32);
            this.btn_Print.TabIndex = 10;
            this.btn_Print.Text = "&Print";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.Color.White;
            this.lblItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(422, 11);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(404, 21);
            this.lblItemName.TabIndex = 66;
            // 
            // cboGodown
            // 
            this.cboGodown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGodown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboGodown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGodown.FormattingEnabled = true;
            this.cboGodown.Location = new System.Drawing.Point(113, 96);
            this.cboGodown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboGodown.Name = "cboGodown";
            this.cboGodown.Size = new System.Drawing.Size(246, 24);
            this.cboGodown.TabIndex = 7;
            this.cboGodown.Visible = false;
            // 
            // cbo_UOM
            // 
            this.cbo_UOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_UOM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbo_UOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_UOM.FormattingEnabled = true;
            this.cbo_UOM.Location = new System.Drawing.Point(113, 126);
            this.cbo_UOM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbo_UOM.Name = "cbo_UOM";
            this.cbo_UOM.Size = new System.Drawing.Size(246, 24);
            this.cbo_UOM.TabIndex = 9;
            // 
            // OptItemLedger
            // 
            this.OptItemLedger.AutoSize = true;
            this.OptItemLedger.Checked = true;
            this.OptItemLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptItemLedger.Location = new System.Drawing.Point(574, 87);
            this.OptItemLedger.Name = "OptItemLedger";
            this.OptItemLedger.Size = new System.Drawing.Size(125, 17);
            this.OptItemLedger.TabIndex = 67;
            this.OptItemLedger.TabStop = true;
            this.OptItemLedger.Text = "Item Ledger Shop";
            this.OptItemLedger.UseVisualStyleBackColor = true;
            this.OptItemLedger.CheckedChanged += new System.EventHandler(this.OptItemLedger_CheckedChanged);
            this.OptItemLedger.Click += new System.EventHandler(this.OptItemLedger_Click);
            // 
            // OptGeneralItemLedger
            // 
            this.OptGeneralItemLedger.AutoSize = true;
            this.OptGeneralItemLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptGeneralItemLedger.Location = new System.Drawing.Point(710, 89);
            this.OptGeneralItemLedger.Name = "OptGeneralItemLedger";
            this.OptGeneralItemLedger.Size = new System.Drawing.Size(140, 17);
            this.OptGeneralItemLedger.TabIndex = 73;
            this.OptGeneralItemLedger.Text = "Item Ledger General";
            this.OptGeneralItemLedger.UseVisualStyleBackColor = true;
            this.OptGeneralItemLedger.Visible = false;
            // 
            // OptItemLedgerShopItem
            // 
            this.OptItemLedgerShopItem.AutoSize = true;
            this.OptItemLedgerShopItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptItemLedgerShopItem.Location = new System.Drawing.Point(573, 107);
            this.OptItemLedgerShopItem.Name = "OptItemLedgerShopItem";
            this.OptItemLedgerShopItem.Size = new System.Drawing.Size(129, 17);
            this.OptItemLedgerShopItem.TabIndex = 74;
            this.OptItemLedgerShopItem.Text = "Item Ledger Detail";
            this.OptItemLedgerShopItem.UseVisualStyleBackColor = true;
            this.OptItemLedgerShopItem.CheckedChanged += new System.EventHandler(this.OptItemLedgerShopItem_CheckedChanged);
            this.OptItemLedgerShopItem.Click += new System.EventHandler(this.OptItemLedgerShopItem_Click);
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
            // tNumEditDataGridViewColumn3
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "F0";
            this.tNumEditDataGridViewColumn3.DefaultCellStyle = dataGridViewCellStyle7;
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
            // tNumEditDataGridViewColumn2
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "F0";
            this.tNumEditDataGridViewColumn2.DefaultCellStyle = dataGridViewCellStyle8;
            this.tNumEditDataGridViewColumn2.HeaderText = "Credit";
            this.tNumEditDataGridViewColumn2.Name = "tNumEditDataGridViewColumn2";
            // 
            // tNumEditDataGridViewColumn1
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "F0";
            this.tNumEditDataGridViewColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.tNumEditDataGridViewColumn1.HeaderText = "Debit";
            this.tNumEditDataGridViewColumn1.Name = "tNumEditDataGridViewColumn1";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Desc";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // frmItemLedgerShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 469);
            this.Controls.Add(this.OptItemLedgerShopItem);
            this.Controls.Add(this.OptGeneralItemLedger);
            this.Controls.Add(this.OptItemLedger);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.btn_ToDate);
            this.Controls.Add(this.btn_FromDate);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.lblTotalDebit);
            this.Controls.Add(this.lblTotalCredit);
            this.Controls.Add(this.pnlCalander);
            this.Controls.Add(this.msk_ItemID);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.lblOpBal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.msk_ToDate);
            this.Controls.Add(this.msk_FromDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblGodown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboGodown);
            this.Controls.Add(this.cbo_UOM);
            this.KeyPreview = true;
            this.Name = "frmItemLedgerShop";
            this.Text = "Item Ledger Report (Shop)";
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
            this.tabItemLedger.ResumeLayout(false);
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
        private System.Windows.Forms.MaskedTextBox msk_ItemID;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn2;
        private CSUST.Data.TNumEditDataGridViewColumn tNumEditDataGridViewColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabItemLedger;
        private System.Windows.Forms.DataGridView grdDetail;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label lblOpBal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox msk_ToDate;
        private System.Windows.Forms.MaskedTextBox msk_FromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGodown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Button btn_ToDate;
        private System.Windows.Forms.Button btn_FromDate;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.ComboBox cboGodown;
        private System.Windows.Forms.ComboBox cbo_UOM;
        private System.Windows.Forms.RadioButton OptItemLedger;
        private System.Windows.Forms.RadioButton OptGeneralItemLedger;
        private System.Windows.Forms.RadioButton OptItemLedgerShopItem;
    }
}