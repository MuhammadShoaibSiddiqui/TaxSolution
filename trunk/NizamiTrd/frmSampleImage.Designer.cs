namespace TaxSolution
{
    partial class frmSampleImage
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
            this.btn_SaveNContinue = new System.Windows.Forms.Button();
            this.btn_View = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.pnlCalander = new System.Windows.Forms.Panel();
            this.btn_HideMonth = new System.Windows.Forms.Button();
            this.mCalendarMain = new System.Windows.Forms.MonthCalendar();
            this.btn_FromDate = new System.Windows.Forms.Button();
            this.pnlCalander.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SaveNContinue
            // 
            this.btn_SaveNContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SaveNContinue.Image = global::TaxSolution.Properties.Resources.saveHS;
            this.btn_SaveNContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SaveNContinue.Location = new System.Drawing.Point(99, 12);
            this.btn_SaveNContinue.Name = "btn_SaveNContinue";
            this.btn_SaveNContinue.Size = new System.Drawing.Size(74, 25);
            this.btn_SaveNContinue.TabIndex = 43;
            this.btn_SaveNContinue.Text = "Continu&e";
            this.btn_SaveNContinue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SaveNContinue.UseVisualStyleBackColor = true;
            // 
            // btn_View
            // 
            this.btn_View.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_View.Image = global::TaxSolution.Properties.Resources.x_preview_16x16;
            this.btn_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_View.Location = new System.Drawing.Point(321, 12);
            this.btn_View.Name = "btn_View";
            this.btn_View.Size = new System.Drawing.Size(74, 25);
            this.btn_View.TabIndex = 46;
            this.btn_View.Text = "&View";
            this.btn_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View.UseVisualStyleBackColor = true;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Exit.Image = global::TaxSolution.Properties.Resources.FormExit;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.Location = new System.Drawing.Point(397, 12);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(74, 25);
            this.btn_Exit.TabIndex = 47;
            this.btn_Exit.Text = "E&xit";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.Image = global::TaxSolution.Properties.Resources.saveHS;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.Location = new System.Drawing.Point(23, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(74, 25);
            this.btn_Save.TabIndex = 42;
            this.btn_Save.Text = "&Save";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.Image = global::TaxSolution.Properties.Resources.ico_delete;
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.Location = new System.Drawing.Point(247, 12);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(74, 25);
            this.btn_Delete.TabIndex = 45;
            this.btn_Delete.Text = "&Delete";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.Image = global::TaxSolution.Properties.Resources.BaBa_clear;
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.Location = new System.Drawing.Point(173, 12);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(74, 25);
            this.btn_Clear.TabIndex = 44;
            this.btn_Clear.Text = "&Clear";
            this.btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // pnlCalander
            // 
            this.pnlCalander.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCalander.Controls.Add(this.btn_HideMonth);
            this.pnlCalander.Controls.Add(this.mCalendarMain);
            this.pnlCalander.Location = new System.Drawing.Point(499, 12);
            this.pnlCalander.Name = "pnlCalander";
            this.pnlCalander.Size = new System.Drawing.Size(234, 215);
            this.pnlCalander.TabIndex = 48;
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
            // 
            // btn_FromDate
            // 
            this.btn_FromDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_FromDate.Image = global::TaxSolution.Properties.Resources.BaBa_Calendar;
            this.btn_FromDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_FromDate.Location = new System.Drawing.Point(35, 64);
            this.btn_FromDate.Name = "btn_FromDate";
            this.btn_FromDate.Size = new System.Drawing.Size(62, 26);
            this.btn_FromDate.TabIndex = 49;
            this.btn_FromDate.TabStop = false;
            this.btn_FromDate.Text = "&Month";
            this.btn_FromDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_FromDate.UseVisualStyleBackColor = true;
            // 
            // frmSampleImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 413);
            this.Controls.Add(this.btn_FromDate);
            this.Controls.Add(this.pnlCalander);
            this.Controls.Add(this.btn_SaveNContinue);
            this.Controls.Add(this.btn_View);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Clear);
            this.Name = "frmSampleImage";
            this.Text = "frmSampleImage";
            this.pnlCalander.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_SaveNContinue;
        private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Panel pnlCalander;
        private System.Windows.Forms.Button btn_HideMonth;
        private System.Windows.Forms.MonthCalendar mCalendarMain;
        private System.Windows.Forms.Button btn_FromDate;
    }
}