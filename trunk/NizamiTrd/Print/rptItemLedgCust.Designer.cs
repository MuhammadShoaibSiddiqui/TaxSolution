namespace TaxSolution
{
    partial class rptItemLedgCust
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
            this.pnlCalander = new System.Windows.Forms.Panel();
            this.mCalendarMain = new System.Windows.Forms.MonthCalendar();
            this.msk_ItemID = new System.Windows.Forms.MaskedTextBox();
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
            this.btn_ToDate = new System.Windows.Forms.Button();
            this.btn_FromDate = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_View = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.OptItemLedger = new System.Windows.Forms.RadioButton();
            this.OptStock = new System.Windows.Forms.RadioButton();
            this.optVocPrint = new System.Windows.Forms.RadioButton();
            this.optSummary = new System.Windows.Forms.RadioButton();
            this.OptStockDtl = new System.Windows.Forms.RadioButton();
            this.OptUnitLedger = new System.Windows.Forms.RadioButton();
            this.OptItemLedgerShop = new System.Windows.Forms.RadioButton();
            this.OptItemLedgerShopItem = new System.Windows.Forms.RadioButton();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.txtManualDoc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.msk_AccountID = new System.Windows.Forms.MaskedTextBox();
            this.txtAcName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.optDetail = new System.Windows.Forms.RadioButton();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboItemGroup = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optSale = new System.Windows.Forms.RadioButton();
            this.optGRN = new System.Windows.Forms.RadioButton();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.optSaleCust = new System.Windows.Forms.RadioButton();
            this.optGRNVend = new System.Windows.Forms.RadioButton();
            this.pnlCalander.SuspendLayout();
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
            // pnlCalander
            // 
            this.pnlCalander.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalander.Controls.Add(this.btn_HideMonth);
            this.pnlCalander.Controls.Add(this.mCalendarMain);
            this.pnlCalander.Location = new System.Drawing.Point(563, 120);
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
            this.msk_ItemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_ItemID.Location = new System.Drawing.Point(157, 16);
            this.msk_ItemID.Mask = "#######";
            this.msk_ItemID.Name = "msk_ItemID";
            this.msk_ItemID.Size = new System.Drawing.Size(97, 26);
            this.msk_ItemID.TabIndex = 1;
            this.msk_ItemID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msk_ItemID_KeyDown);
            this.msk_ItemID.Leave += new System.EventHandler(this.msk_ItemID_Leave);
            this.msk_ItemID.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.msk_ItemID_MouseDoubleClick);
            // 
            // lblOpBal
            // 
            this.lblOpBal.BackColor = System.Drawing.Color.White;
            this.lblOpBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOpBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpBal.Location = new System.Drawing.Point(624, 67);
            this.lblOpBal.Name = "lblOpBal";
            this.lblOpBal.Size = new System.Drawing.Size(96, 18);
            this.lblOpBal.TabIndex = 53;
            this.lblOpBal.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(624, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 18);
            this.label7.TabIndex = 51;
            this.label7.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(531, 67);
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
            this.label11.Location = new System.Drawing.Point(551, 42);
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
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(38, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 22);
            this.label12.TabIndex = 2;
            this.label12.Text = "Item Name : ";
            // 
            // msk_ToDate
            // 
            this.msk_ToDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_ToDate.Location = new System.Drawing.Point(157, 301);
            this.msk_ToDate.Mask = "00/00/0000";
            this.msk_ToDate.Name = "msk_ToDate";
            this.msk_ToDate.Size = new System.Drawing.Size(111, 26);
            this.msk_ToDate.TabIndex = 19;
            this.msk_ToDate.Text = "30102012";
            this.msk_ToDate.ValidatingType = typeof(System.DateTime);
            // 
            // msk_FromDate
            // 
            this.msk_FromDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_FromDate.Location = new System.Drawing.Point(157, 272);
            this.msk_FromDate.Mask = "00/00/0000";
            this.msk_FromDate.Name = "msk_FromDate";
            this.msk_FromDate.Size = new System.Drawing.Size(111, 26);
            this.msk_FromDate.TabIndex = 17;
            this.msk_FromDate.Text = "25082012";
            this.msk_FromDate.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(57, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 22);
            this.label5.TabIndex = 12;
            this.label5.Text = "Province : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(63, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Country : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(61, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 18;
            this.label3.Text = "To Date : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(40, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 16;
            this.label2.Text = "From Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(65, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item ID : ";
            // 
            // btn_ToDate
            // 
            this.btn_ToDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ToDate.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_ToDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ToDate.Location = new System.Drawing.Point(271, 301);
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
            this.btn_FromDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_FromDate.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_FromDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FromDate.Location = new System.Drawing.Point(271, 272);
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
            this.btn_Exit.Location = new System.Drawing.Point(283, 405);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(74, 30);
            this.btn_Exit.TabIndex = 24;
            this.btn_Exit.Text = "E&xit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_View
            // 
            this.btn_View.Image = global::TaxSolution.Properties.Resources.preview_16x16;
            this.btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View.Location = new System.Drawing.Point(203, 405);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(74, 30);
            this.btn_View.TabIndex = 23;
            this.btn_View.Text = "&View";
            this.btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View.UseVisualStyleBackColor = true;
            this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.Image = global::TaxSolution.Properties.Resources.PrinterSmall_ico;
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.Location = new System.Drawing.Point(114, 404);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(83, 32);
            this.btn_Print.TabIndex = 22;
            this.btn_Print.Text = "&Print";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.BackColor = System.Drawing.Color.White;
            this.lblItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblItemName.Location = new System.Drawing.Point(157, 48);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(307, 23);
            this.lblItemName.TabIndex = 3;
            // 
            // cboCountry
            // 
            this.cboCountry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(157, 172);
            this.cboCountry.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(305, 28);
            this.cboCountry.TabIndex = 11;
            // 
            // cboProvince
            // 
            this.cboProvince.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboProvince.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(157, 205);
            this.cboProvince.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(305, 28);
            this.cboProvince.TabIndex = 13;
            // 
            // OptItemLedger
            // 
            this.OptItemLedger.AutoSize = true;
            this.OptItemLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptItemLedger.Location = new System.Drawing.Point(678, 89);
            this.OptItemLedger.Name = "OptItemLedger";
            this.OptItemLedger.Size = new System.Drawing.Size(125, 17);
            this.OptItemLedger.TabIndex = 67;
            this.OptItemLedger.Text = "Item Ledger Shop";
            this.OptItemLedger.UseVisualStyleBackColor = true;
            this.OptItemLedger.Visible = false;
            // 
            // OptStock
            // 
            this.OptStock.AutoSize = true;
            this.OptStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptStock.Location = new System.Drawing.Point(678, 107);
            this.OptStock.Name = "OptStock";
            this.OptStock.Size = new System.Drawing.Size(100, 17);
            this.OptStock.TabIndex = 68;
            this.OptStock.Text = "Stock Report";
            this.OptStock.UseVisualStyleBackColor = true;
            this.OptStock.Visible = false;
            // 
            // optVocPrint
            // 
            this.optVocPrint.AutoSize = true;
            this.optVocPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.optVocPrint.Location = new System.Drawing.Point(547, 179);
            this.optVocPrint.Name = "optVocPrint";
            this.optVocPrint.Size = new System.Drawing.Size(80, 17);
            this.optVocPrint.TabIndex = 69;
            this.optVocPrint.Text = "Day Book";
            this.optVocPrint.UseVisualStyleBackColor = true;
            this.optVocPrint.Visible = false;
            // 
            // optSummary
            // 
            this.optSummary.AutoSize = true;
            this.optSummary.Checked = true;
            this.optSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.optSummary.Location = new System.Drawing.Point(157, 342);
            this.optSummary.Name = "optSummary";
            this.optSummary.Size = new System.Drawing.Size(90, 20);
            this.optSummary.TabIndex = 20;
            this.optSummary.TabStop = true;
            this.optSummary.Text = "Summary";
            this.optSummary.UseVisualStyleBackColor = true;
            // 
            // OptStockDtl
            // 
            this.OptStockDtl.AutoSize = true;
            this.OptStockDtl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptStockDtl.Location = new System.Drawing.Point(546, 158);
            this.OptStockDtl.Name = "OptStockDtl";
            this.OptStockDtl.Size = new System.Drawing.Size(137, 17);
            this.OptStockDtl.TabIndex = 71;
            this.OptStockDtl.Text = "Stock Detail Report";
            this.OptStockDtl.UseVisualStyleBackColor = true;
            this.OptStockDtl.Visible = false;
            // 
            // OptUnitLedger
            // 
            this.OptUnitLedger.AutoSize = true;
            this.OptUnitLedger.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptUnitLedger.Location = new System.Drawing.Point(547, 135);
            this.OptUnitLedger.Name = "OptUnitLedger";
            this.OptUnitLedger.Size = new System.Drawing.Size(148, 17);
            this.OptUnitLedger.TabIndex = 72;
            this.OptUnitLedger.Text = "Unit Inventory Ledger";
            this.OptUnitLedger.UseVisualStyleBackColor = true;
            this.OptUnitLedger.Visible = false;
            // 
            // OptItemLedgerShop
            // 
            this.OptItemLedgerShop.AutoSize = true;
            this.OptItemLedgerShop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptItemLedgerShop.Location = new System.Drawing.Point(544, 90);
            this.OptItemLedgerShop.Name = "OptItemLedgerShop";
            this.OptItemLedgerShop.Size = new System.Drawing.Size(125, 17);
            this.OptItemLedgerShop.TabIndex = 73;
            this.OptItemLedgerShop.Text = "Item Ledger Shop";
            this.OptItemLedgerShop.UseVisualStyleBackColor = true;
            this.OptItemLedgerShop.Visible = false;
            // 
            // OptItemLedgerShopItem
            // 
            this.OptItemLedgerShopItem.AutoSize = true;
            this.OptItemLedgerShopItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.OptItemLedgerShopItem.Location = new System.Drawing.Point(543, 110);
            this.OptItemLedgerShopItem.Name = "OptItemLedgerShopItem";
            this.OptItemLedgerShopItem.Size = new System.Drawing.Size(129, 17);
            this.OptItemLedgerShopItem.TabIndex = 74;
            this.OptItemLedgerShopItem.Text = "Item Ledger Detail";
            this.OptItemLedgerShopItem.UseVisualStyleBackColor = true;
            this.OptItemLedgerShopItem.Visible = false;
            this.OptItemLedgerShopItem.CheckedChanged += new System.EventHandler(this.OptItemLedgerShopItem_CheckedChanged);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 445);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(789, 22);
            this.statusBar.TabIndex = 56;
            this.statusBar.Text = "status Bar";
            // 
            // txtManualDoc
            // 
            this.txtManualDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtManualDoc.Location = new System.Drawing.Point(551, 3);
            this.txtManualDoc.Name = "txtManualDoc";
            this.txtManualDoc.Size = new System.Drawing.Size(208, 26);
            this.txtManualDoc.TabIndex = 0;
            this.txtManualDoc.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(474, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 22);
            this.label6.TabIndex = 76;
            this.label6.Text = "Document # : ";
            this.label6.Visible = false;
            // 
            // msk_AccountID
            // 
            this.msk_AccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msk_AccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.msk_AccountID.Location = new System.Drawing.Point(157, 110);
            this.msk_AccountID.Mask = "#-#-##-##-####";
            this.msk_AccountID.Name = "msk_AccountID";
            this.msk_AccountID.Size = new System.Drawing.Size(158, 26);
            this.msk_AccountID.TabIndex = 7;
            this.msk_AccountID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msk_AccountID_KeyDown);
            this.msk_AccountID.Validating += new System.ComponentModel.CancelEventHandler(this.msk_AccountID_Validating);
            // 
            // txtAcName
            // 
            this.txtAcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAcName.Location = new System.Drawing.Point(157, 140);
            this.txtAcName.Name = "txtAcName";
            this.txtAcName.Size = new System.Drawing.Size(305, 26);
            this.txtAcName.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(8, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 22);
            this.label8.TabIndex = 8;
            this.label8.Text = "Account Name : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label9.Location = new System.Drawing.Point(35, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 22);
            this.label9.TabIndex = 6;
            this.label9.Text = "Account ID : ";
            // 
            // cboCity
            // 
            this.cboCity.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(157, 238);
            this.cboCity.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(305, 28);
            this.cboCity.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label13.Location = new System.Drawing.Point(95, 241);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 22);
            this.label13.TabIndex = 14;
            this.label13.Text = "City : ";
            // 
            // optDetail
            // 
            this.optDetail.AutoSize = true;
            this.optDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.optDetail.Location = new System.Drawing.Point(157, 369);
            this.optDetail.Name = "optDetail";
            this.optDetail.Size = new System.Drawing.Size(67, 20);
            this.optDetail.TabIndex = 21;
            this.optDetail.Text = "Detail";
            this.optDetail.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dateTimePicker1.Location = new System.Drawing.Point(358, 284);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(154, 26);
            this.dateTimePicker1.TabIndex = 84;
            // 
            // cboItemGroup
            // 
            this.cboItemGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboItemGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cboItemGroup.FormattingEnabled = true;
            this.cboItemGroup.Location = new System.Drawing.Point(157, 76);
            this.cboItemGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboItemGroup.Name = "cboItemGroup";
            this.cboItemGroup.Size = new System.Drawing.Size(305, 28);
            this.cboItemGroup.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label14.Location = new System.Drawing.Point(34, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 22);
            this.label14.TabIndex = 4;
            this.label14.Text = "Item Group : ";
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
            // optSale
            // 
            this.optSale.AutoSize = true;
            this.optSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.optSale.Location = new System.Drawing.Point(358, 342);
            this.optSale.Name = "optSale";
            this.optSale.Size = new System.Drawing.Size(109, 20);
            this.optSale.TabIndex = 85;
            this.optSale.Text = "Sale Report";
            this.optSale.UseVisualStyleBackColor = true;
            // 
            // optGRN
            // 
            this.optGRN.AutoSize = true;
            this.optGRN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.optGRN.Location = new System.Drawing.Point(358, 369);
            this.optGRN.Name = "optGRN";
            this.optGRN.Size = new System.Drawing.Size(142, 20);
            this.optGRN.TabIndex = 86;
            this.optGRN.Text = "Purchase Report";
            this.optGRN.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Image = global::TaxSolution.Properties.Resources.BaBa_clear;
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(22, 410);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(74, 25);
            this.btn_Clear.TabIndex = 87;
            this.btn_Clear.Text = "&Clear";
            this.btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // optSaleCust
            // 
            this.optSaleCust.AutoSize = true;
            this.optSaleCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.optSaleCust.Location = new System.Drawing.Point(506, 343);
            this.optSaleCust.Name = "optSaleCust";
            this.optSaleCust.Size = new System.Drawing.Size(161, 20);
            this.optSaleCust.TabIndex = 88;
            this.optSaleCust.Text = "Sale Customer/Item";
            this.optSaleCust.UseVisualStyleBackColor = true;
            // 
            // optGRNVend
            // 
            this.optGRNVend.AutoSize = true;
            this.optGRNVend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.optGRNVend.Location = new System.Drawing.Point(506, 369);
            this.optGRNVend.Name = "optGRNVend";
            this.optGRNVend.Size = new System.Drawing.Size(142, 20);
            this.optGRNVend.TabIndex = 89;
            this.optGRNVend.Text = "Purchase Report";
            this.optGRNVend.UseVisualStyleBackColor = true;
            // 
            // rptItemLedgCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 467);
            this.Controls.Add(this.optGRNVend);
            this.Controls.Add(this.optSaleCust);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.optGRN);
            this.Controls.Add(this.optSale);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboItemGroup);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.optDetail);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboCity);
            this.Controls.Add(this.msk_AccountID);
            this.Controls.Add(this.txtAcName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtManualDoc);
            this.Controls.Add(this.pnlCalander);
            this.Controls.Add(this.OptItemLedgerShopItem);
            this.Controls.Add(this.OptItemLedgerShop);
            this.Controls.Add(this.OptUnitLedger);
            this.Controls.Add(this.OptStockDtl);
            this.Controls.Add(this.optSummary);
            this.Controls.Add(this.optVocPrint);
            this.Controls.Add(this.OptStock);
            this.Controls.Add(this.OptItemLedger);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.btn_ToDate);
            this.Controls.Add(this.btn_FromDate);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.msk_ItemID);
            this.Controls.Add(this.statusBar);
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
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.cboProvince);
            this.KeyPreview = true;
            this.Name = "rptItemLedgCust";
            this.Text = "Analysis Report";
            this.Load += new System.EventHandler(this.frmLedger_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLedger_KeyDown);
            this.pnlCalander.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_HideMonth;
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
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.ComboBox cboProvince;
        private System.Windows.Forms.RadioButton OptItemLedger;
        private System.Windows.Forms.RadioButton OptStock;
        private System.Windows.Forms.RadioButton optVocPrint;
        private System.Windows.Forms.RadioButton optSummary;
        private System.Windows.Forms.RadioButton OptStockDtl;
        private System.Windows.Forms.RadioButton OptUnitLedger;
        private System.Windows.Forms.RadioButton OptItemLedgerShop;
        private System.Windows.Forms.RadioButton OptItemLedgerShopItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.TextBox txtManualDoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox msk_AccountID;
        private System.Windows.Forms.TextBox txtAcName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton optDetail;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboItemGroup;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton optSale;
        private System.Windows.Forms.RadioButton optGRN;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.RadioButton optSaleCust;
        private System.Windows.Forms.RadioButton optGRNVend;
    }
}