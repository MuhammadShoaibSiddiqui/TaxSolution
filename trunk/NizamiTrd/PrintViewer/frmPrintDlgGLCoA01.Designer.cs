namespace NizamiTrd
{
  partial class frmPrintDlgGLCoA01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintDlgGLCoA01));
            this.cboSelectRpt = new System.Windows.Forms.ComboBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTopLine1 = new System.Windows.Forms.Label();
            this.lblTopLine2 = new System.Windows.Forms.Label();
            this.panelFormTitle = new System.Windows.Forms.Panel();
            this.lblTopLine3 = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblIdStart = new System.Windows.Forms.Label();
            this.lblIdEnd = new System.Windows.Forms.Label();
            this.chkIncludeZeroTranDetail = new System.Windows.Forms.CheckBox();
            this.gBSortOrder = new System.Windows.Forms.GroupBox();
            this.rBtnOrdering = new System.Windows.Forms.RadioButton();
            this.rBtnAlphabetic = new System.Windows.Forms.RadioButton();
            this.rBtnNumeric = new System.Windows.Forms.RadioButton();
            this.mtextIdEnd = new System.Windows.Forms.MaskedTextBox();
            this.mtextIdStart = new System.Windows.Forms.MaskedTextBox();
            this.gBId = new System.Windows.Forms.GroupBox();
            this.gBDate = new System.Windows.Forms.GroupBox();
            this.btn_PinParentID = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gBOptions = new System.Windows.Forms.GroupBox();
            this.mtext = new System.Windows.Forms.MaskedTextBox();
            this.panelFormTitle.SuspendLayout();
            this.gBSortOrder.SuspendLayout();
            this.gBId.SuspendLayout();
            this.gBDate.SuspendLayout();
            this.gBOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSelectRpt
            // 
            this.cboSelectRpt.FormattingEnabled = true;
            this.cboSelectRpt.Location = new System.Drawing.Point(8, 89);
            this.cboSelectRpt.Margin = new System.Windows.Forms.Padding(4);
            this.cboSelectRpt.Name = "cboSelectRpt";
            this.cboSelectRpt.Size = new System.Drawing.Size(524, 24);
            this.cboSelectRpt.TabIndex = 0;
            this.cboSelectRpt.SelectedIndexChanged += new System.EventHandler(this.cboSelectRpt_SelectedIndexChanged);
            // 
            // btnPreview
            // 
            this.btnPreview.Image = global::NizamiTrd.Properties.Resources.BaBa_preview;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(257, 441);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 31);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "&View";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::NizamiTrd.Properties.Resources.Baba_FormExit16;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(443, 441);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 31);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "E&xit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = global::NizamiTrd.Properties.Resources.BaBa_clear;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(347, 441);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 31);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTopLine1
            // 
            this.lblTopLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblTopLine1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLine1.ForeColor = System.Drawing.Color.White;
            this.lblTopLine1.Location = new System.Drawing.Point(0, 0);
            this.lblTopLine1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTopLine1.Name = "lblTopLine1";
            this.lblTopLine1.Size = new System.Drawing.Size(547, 16);
            this.lblTopLine1.TabIndex = 16;
            this.lblTopLine1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTopLine2
            // 
            this.lblTopLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopLine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblTopLine2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLine2.ForeColor = System.Drawing.Color.White;
            this.lblTopLine2.Location = new System.Drawing.Point(0, 16);
            this.lblTopLine2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTopLine2.Name = "lblTopLine2";
            this.lblTopLine2.Size = new System.Drawing.Size(547, 15);
            this.lblTopLine2.TabIndex = 17;
            this.lblTopLine2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelFormTitle
            // 
            this.panelFormTitle.Controls.Add(this.lblTopLine3);
            this.panelFormTitle.Controls.Add(this.lblTopLine1);
            this.panelFormTitle.Controls.Add(this.lblTopLine2);
            this.panelFormTitle.Controls.Add(this.lblFormTitle);
            this.panelFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormTitle.Location = new System.Drawing.Point(0, 0);
            this.panelFormTitle.Margin = new System.Windows.Forms.Padding(4);
            this.panelFormTitle.Name = "panelFormTitle";
            this.panelFormTitle.Size = new System.Drawing.Size(547, 82);
            this.panelFormTitle.TabIndex = 19;
            // 
            // lblTopLine3
            // 
            this.lblTopLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTopLine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(208)))), ((int)(((byte)(222)))));
            this.lblTopLine3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLine3.ForeColor = System.Drawing.Color.White;
            this.lblTopLine3.Location = new System.Drawing.Point(0, 69);
            this.lblTopLine3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTopLine3.Name = "lblTopLine3";
            this.lblTopLine3.Size = new System.Drawing.Size(547, 10);
            this.lblTopLine3.TabIndex = 19;
            this.lblTopLine3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblFormTitle.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(94)))), ((int)(((byte)(129)))));
            this.lblFormTitle.Location = new System.Drawing.Point(3, 26);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(540, 43);
            this.lblFormTitle.TabIndex = 4;
            this.lblFormTitle.Text = "Print ID List M-Dtl One >>";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFormTitle.Click += new System.EventHandler(this.lblFormTitle_Click);
            this.lblFormTitle.DoubleClick += new System.EventHandler(this.lblFormTitle_DoubleClick);
            // 
            // lblIdStart
            // 
            this.lblIdStart.AutoSize = true;
            this.lblIdStart.Location = new System.Drawing.Point(28, 35);
            this.lblIdStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdStart.Name = "lblIdStart";
            this.lblIdStart.Size = new System.Drawing.Size(65, 17);
            this.lblIdStart.TabIndex = 22;
            this.lblIdStart.Text = "Starting :";
            // 
            // lblIdEnd
            // 
            this.lblIdEnd.AutoSize = true;
            this.lblIdEnd.Location = new System.Drawing.Point(37, 61);
            this.lblIdEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdEnd.Name = "lblIdEnd";
            this.lblIdEnd.Size = new System.Drawing.Size(56, 17);
            this.lblIdEnd.TabIndex = 23;
            this.lblIdEnd.Text = "Ending:";
            this.lblIdEnd.Click += new System.EventHandler(this.lblIDEnd_Click);
            // 
            // chkIncludeZeroTranDetail
            // 
            this.chkIncludeZeroTranDetail.AutoSize = true;
            this.chkIncludeZeroTranDetail.Location = new System.Drawing.Point(39, 27);
            this.chkIncludeZeroTranDetail.Margin = new System.Windows.Forms.Padding(4);
            this.chkIncludeZeroTranDetail.Name = "chkIncludeZeroTranDetail";
            this.chkIncludeZeroTranDetail.Size = new System.Drawing.Size(248, 21);
            this.chkIncludeZeroTranDetail.TabIndex = 4;
            this.chkIncludeZeroTranDetail.Text = "Include Zero Tran. Detail Records.";
            this.chkIncludeZeroTranDetail.UseVisualStyleBackColor = true;
            this.chkIncludeZeroTranDetail.CheckedChanged += new System.EventHandler(this.chkIncludeZeroTranDetail_CheckedChanged);
            // 
            // gBSortOrder
            // 
            this.gBSortOrder.Controls.Add(this.rBtnOrdering);
            this.gBSortOrder.Controls.Add(this.rBtnAlphabetic);
            this.gBSortOrder.Controls.Add(this.rBtnNumeric);
            this.gBSortOrder.Location = new System.Drawing.Point(8, 372);
            this.gBSortOrder.Margin = new System.Windows.Forms.Padding(4);
            this.gBSortOrder.Name = "gBSortOrder";
            this.gBSortOrder.Padding = new System.Windows.Forms.Padding(4);
            this.gBSortOrder.Size = new System.Drawing.Size(528, 59);
            this.gBSortOrder.TabIndex = 24;
            this.gBSortOrder.TabStop = false;
            this.gBSortOrder.Text = "Sort Order";
            // 
            // rBtnOrdering
            // 
            this.rBtnOrdering.AutoSize = true;
            this.rBtnOrdering.Location = new System.Drawing.Point(320, 27);
            this.rBtnOrdering.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnOrdering.Name = "rBtnOrdering";
            this.rBtnOrdering.Size = new System.Drawing.Size(85, 21);
            this.rBtnOrdering.TabIndex = 2;
            this.rBtnOrdering.TabStop = true;
            this.rBtnOrdering.Text = "&Ordering";
            this.rBtnOrdering.UseVisualStyleBackColor = true;
            // 
            // rBtnAlphabetic
            // 
            this.rBtnAlphabetic.AutoSize = true;
            this.rBtnAlphabetic.Location = new System.Drawing.Point(205, 27);
            this.rBtnAlphabetic.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnAlphabetic.Name = "rBtnAlphabetic";
            this.rBtnAlphabetic.Size = new System.Drawing.Size(95, 21);
            this.rBtnAlphabetic.TabIndex = 1;
            this.rBtnAlphabetic.TabStop = true;
            this.rBtnAlphabetic.Text = "&Alphabetic";
            this.rBtnAlphabetic.UseVisualStyleBackColor = true;
            // 
            // rBtnNumeric
            // 
            this.rBtnNumeric.AutoSize = true;
            this.rBtnNumeric.Location = new System.Drawing.Point(105, 27);
            this.rBtnNumeric.Margin = new System.Windows.Forms.Padding(4);
            this.rBtnNumeric.Name = "rBtnNumeric";
            this.rBtnNumeric.Size = new System.Drawing.Size(81, 21);
            this.rBtnNumeric.TabIndex = 0;
            this.rBtnNumeric.TabStop = true;
            this.rBtnNumeric.Text = "&Numeric";
            this.rBtnNumeric.UseVisualStyleBackColor = true;
            // 
            // mtextIdEnd
            // 
            this.mtextIdEnd.Location = new System.Drawing.Point(107, 59);
            this.mtextIdEnd.Margin = new System.Windows.Forms.Padding(4);
            this.mtextIdEnd.Mask = "000000";
            this.mtextIdEnd.Name = "mtextIdEnd";
            this.mtextIdEnd.Size = new System.Drawing.Size(257, 22);
            this.mtextIdEnd.TabIndex = 26;
            this.mtextIdEnd.DoubleClick += new System.EventHandler(this.mtextIdEnd_DoubleClick);
            this.mtextIdEnd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtextIdEnd_KeyDown);
            // 
            // mtextIdStart
            // 
            this.mtextIdStart.Location = new System.Drawing.Point(107, 30);
            this.mtextIdStart.Margin = new System.Windows.Forms.Padding(4);
            this.mtextIdStart.Mask = "000000";
            this.mtextIdStart.Name = "mtextIdStart";
            this.mtextIdStart.Size = new System.Drawing.Size(257, 22);
            this.mtextIdStart.TabIndex = 25;
            this.mtextIdStart.ValidatingType = typeof(int);
            this.mtextIdStart.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtextIdStart_MaskInputRejected);
            this.mtextIdStart.DoubleClick += new System.EventHandler(this.mtextIdStart_DoubleClick_1);
            this.mtextIdStart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtextIdStart_KeyDown);
            // 
            // gBId
            // 
            this.gBId.Controls.Add(this.lblIdStart);
            this.gBId.Controls.Add(this.mtextIdEnd);
            this.gBId.Controls.Add(this.lblIdEnd);
            this.gBId.Controls.Add(this.mtextIdStart);
            this.gBId.Location = new System.Drawing.Point(8, 212);
            this.gBId.Margin = new System.Windows.Forms.Padding(4);
            this.gBId.Name = "gBId";
            this.gBId.Padding = new System.Windows.Forms.Padding(4);
            this.gBId.Size = new System.Drawing.Size(525, 94);
            this.gBId.TabIndex = 27;
            this.gBId.TabStop = false;
            this.gBId.Text = "Id";
            // 
            // gBDate
            // 
            this.gBDate.Controls.Add(this.btn_PinParentID);
            this.gBDate.Controls.Add(this.dtpEnd);
            this.gBDate.Controls.Add(this.dtpStart);
            this.gBDate.Controls.Add(this.label1);
            this.gBDate.Controls.Add(this.label2);
            this.gBDate.Location = new System.Drawing.Point(8, 121);
            this.gBDate.Margin = new System.Windows.Forms.Padding(4);
            this.gBDate.Name = "gBDate";
            this.gBDate.Padding = new System.Windows.Forms.Padding(4);
            this.gBDate.Size = new System.Drawing.Size(525, 84);
            this.gBDate.TabIndex = 28;
            this.gBDate.TabStop = false;
            this.gBDate.Text = "Date";
            // 
            // btn_PinParentID
            // 
            this.btn_PinParentID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_PinParentID.Image = ((System.Drawing.Image)(resources.GetObject("btn_PinParentID.Image")));
            this.btn_PinParentID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_PinParentID.Location = new System.Drawing.Point(435, 44);
            this.btn_PinParentID.Margin = new System.Windows.Forms.Padding(4);
            this.btn_PinParentID.Name = "btn_PinParentID";
            this.btn_PinParentID.Size = new System.Drawing.Size(83, 31);
            this.btn_PinParentID.TabIndex = 45;
            this.btn_PinParentID.Text = "&Pin";
            this.btn_PinParentID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_PinParentID.UseVisualStyleBackColor = true;
            this.btn_PinParentID.Click += new System.EventHandler(this.btn_PinParentID_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(111, 52);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(251, 22);
            this.dtpEnd.TabIndex = 44;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(111, 24);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(251, 22);
            this.dtpStart.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Starting :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ending:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gBOptions
            // 
            this.gBOptions.Controls.Add(this.chkIncludeZeroTranDetail);
            this.gBOptions.Location = new System.Drawing.Point(8, 310);
            this.gBOptions.Margin = new System.Windows.Forms.Padding(4);
            this.gBOptions.Name = "gBOptions";
            this.gBOptions.Padding = new System.Windows.Forms.Padding(4);
            this.gBOptions.Size = new System.Drawing.Size(528, 59);
            this.gBOptions.TabIndex = 29;
            this.gBOptions.TabStop = false;
            this.gBOptions.Text = "Options";
            // 
            // mtext
            // 
            this.mtext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mtext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.mtext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.mtext.Location = new System.Drawing.Point(3, 465);
            this.mtext.Margin = new System.Windows.Forms.Padding(4);
            this.mtext.Name = "mtext";
            this.mtext.Size = new System.Drawing.Size(28, 22);
            this.mtext.TabIndex = 54;
            this.mtext.Visible = false;
            // 
            // frmPrintDlgGLCoA01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(547, 492);
            this.Controls.Add(this.mtext);
            this.Controls.Add(this.gBOptions);
            this.Controls.Add(this.gBDate);
            this.Controls.Add(this.gBId);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gBSortOrder);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.panelFormTitle);
            this.Controls.Add(this.cboSelectRpt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrintDlgGLCoA01";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "frmPrintDlgList";
            this.Load += new System.EventHandler(this.frmPrintDlgList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintDlgListMastDtlOne_KeyDown);
            this.panelFormTitle.ResumeLayout(false);
            this.gBSortOrder.ResumeLayout(false);
            this.gBSortOrder.PerformLayout();
            this.gBId.ResumeLayout(false);
            this.gBId.PerformLayout();
            this.gBDate.ResumeLayout(false);
            this.gBDate.PerformLayout();
            this.gBOptions.ResumeLayout(false);
            this.gBOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSelectRpt;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTopLine1;
        private System.Windows.Forms.Label lblTopLine2;
        private System.Windows.Forms.Panel panelFormTitle;
        private System.Windows.Forms.Label lblTopLine3;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblIdStart;
        private System.Windows.Forms.Label lblIdEnd;
        private System.Windows.Forms.CheckBox chkIncludeZeroTranDetail;
        private System.Windows.Forms.GroupBox gBSortOrder;
        private System.Windows.Forms.RadioButton rBtnOrdering;
        private System.Windows.Forms.RadioButton rBtnAlphabetic;
        private System.Windows.Forms.RadioButton rBtnNumeric;
        private System.Windows.Forms.MaskedTextBox mtextIdEnd;
        private System.Windows.Forms.MaskedTextBox mtextIdStart;
        private System.Windows.Forms.GroupBox gBId;
        private System.Windows.Forms.GroupBox gBDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.GroupBox gBOptions;
        private System.Windows.Forms.Button btn_PinParentID;
        private System.Windows.Forms.MaskedTextBox mtext;
    }
}