namespace OneCRM
{
    partial class Break
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmdbreakcancel = new System.Windows.Forms.Button();
            this.cmdbreakok = new System.Windows.Forms.Button();
            this.cmbbreakopt = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cmdbreakcancel);
            this.panel5.Controls.Add(this.cmdbreakok);
            this.panel5.Controls.Add(this.cmbbreakopt);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(8, 6);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(355, 73);
            this.panel5.TabIndex = 30;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // cmdbreakcancel
            // 
            this.cmdbreakcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdbreakcancel.Location = new System.Drawing.Point(263, 37);
            this.cmdbreakcancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdbreakcancel.Name = "cmdbreakcancel";
            this.cmdbreakcancel.Size = new System.Drawing.Size(83, 28);
            this.cmdbreakcancel.TabIndex = 37;
            this.cmdbreakcancel.Text = "Cancel";
            this.cmdbreakcancel.UseVisualStyleBackColor = true;
            this.cmdbreakcancel.Click += new System.EventHandler(this.cmdbreakcancel_Click);
            // 
            // cmdbreakok
            // 
            this.cmdbreakok.Location = new System.Drawing.Point(179, 37);
            this.cmdbreakok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdbreakok.Name = "cmdbreakok";
            this.cmdbreakok.Size = new System.Drawing.Size(83, 28);
            this.cmdbreakok.TabIndex = 36;
            this.cmdbreakok.Text = "OK";
            this.cmdbreakok.UseVisualStyleBackColor = true;
            this.cmdbreakok.Click += new System.EventHandler(this.cmdbreakok_Click);
            // 
            // cmbbreakopt
            // 
            this.cmbbreakopt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbreakopt.FormattingEnabled = true;
            this.cmbbreakopt.Location = new System.Drawing.Point(129, 7);
            this.cmbbreakopt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbbreakopt.Name = "cmbbreakopt";
            this.cmbbreakopt.Size = new System.Drawing.Size(215, 25);
            this.cmbbreakopt.TabIndex = 35;
            this.cmbbreakopt.SelectedIndexChanged += new System.EventHandler(this.cmbbreakopt_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 17);
            this.label11.TabIndex = 34;
            this.label11.Text = "Break Reason";
            // 
            // Break
            // 
            this.AcceptButton = this.cmdbreakok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.cmdbreakcancel;
            this.ClientSize = new System.Drawing.Size(372, 86);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Break";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Break";
            this.Load += new System.EventHandler(this.Break_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button cmdbreakcancel;
        private System.Windows.Forms.Button cmdbreakok;
        private System.Windows.Forms.ComboBox cmbbreakopt;
        private System.Windows.Forms.Label label11;
    }
}