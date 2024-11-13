namespace OneCRM
{
    partial class CTI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CTI));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl_CTI = new System.Windows.Forms.Panel();
            this.lblcallback = new System.Windows.Forms.Label();
            this.pnl_transfer = new System.Windows.Forms.Panel();
            this.btn_trans = new System.Windows.Forms.Button();
            this.cmbtrnsRoutepoint = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlConf = new System.Windows.Forms.Panel();
            this.btndisconnectconf = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWarmtrnsRP = new System.Windows.Forms.ComboBox();
            this.btnconfdial = new System.Windows.Forms.Button();
            this.txtconfmobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbphonenos = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblcallstatus = new System.Windows.Forms.Label();
            this.txtmycode = new System.Windows.Forms.Label();
            this.LblStatus1 = new System.Windows.Forms.Label();
            this.lblcampaign = new System.Windows.Forms.Label();
            this.btnagentready = new System.Windows.Forms.Button();
            this.ButtonHold = new System.Windows.Forms.Button();
            this.btn_ShowHide_CTI = new System.Windows.Forms.Button();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btn_Conference = new System.Windows.Forms.Button();
            this.btnBreak = new System.Windows.Forms.Button();
            this.cmdgetnext = new System.Windows.Forms.Button();
            this.btn_Transfer = new System.Windows.Forms.Button();
            this.ButtonHangUp = new System.Windows.Forms.Button();
            this.ButtonDial = new System.Windows.Forms.Button();
            this.txt_campaignmode = new System.Windows.Forms.TextBox();
            this.txtbatchid = new System.Windows.Forms.TextBox();
            this.txt_AgentName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnl_CTI.SuspendLayout();
            this.pnl_transfer.SuspendLayout();
            this.pnlConf.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // pnl_CTI
            // 
            this.pnl_CTI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_CTI.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_CTI.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnl_CTI.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnl_CTI.BackgroundImage")));
            this.pnl_CTI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_CTI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_CTI.Controls.Add(this.lblcallback);
            this.pnl_CTI.Controls.Add(this.pnl_transfer);
            this.pnl_CTI.Controls.Add(this.pnlConf);
            this.pnl_CTI.Controls.Add(this.button1);
            this.pnl_CTI.Controls.Add(this.label7);
            this.pnl_CTI.Controls.Add(this.cmbphonenos);
            this.pnl_CTI.Controls.Add(this.label18);
            this.pnl_CTI.Controls.Add(this.label15);
            this.pnl_CTI.Controls.Add(this.label14);
            this.pnl_CTI.Controls.Add(this.lblcallstatus);
            this.pnl_CTI.Controls.Add(this.txtmycode);
            this.pnl_CTI.Controls.Add(this.LblStatus1);
            this.pnl_CTI.Controls.Add(this.lblcampaign);
            this.pnl_CTI.Controls.Add(this.btnagentready);
            this.pnl_CTI.Controls.Add(this.ButtonHold);
            this.pnl_CTI.Controls.Add(this.btn_ShowHide_CTI);
            this.pnl_CTI.Controls.Add(this.btnsubmit);
            this.pnl_CTI.Controls.Add(this.btnLogout);
            this.pnl_CTI.Controls.Add(this.btn_Conference);
            this.pnl_CTI.Controls.Add(this.btnBreak);
            this.pnl_CTI.Controls.Add(this.cmdgetnext);
            this.pnl_CTI.Controls.Add(this.btn_Transfer);
            this.pnl_CTI.Controls.Add(this.ButtonHangUp);
            this.pnl_CTI.Controls.Add(this.ButtonDial);
            this.pnl_CTI.Controls.Add(this.txt_campaignmode);
            this.pnl_CTI.Controls.Add(this.txtbatchid);
            this.pnl_CTI.Controls.Add(this.txt_AgentName);
            this.pnl_CTI.Controls.Add(this.label17);
            this.pnl_CTI.Controls.Add(this.label28);
            this.pnl_CTI.Controls.Add(this.label30);
            this.pnl_CTI.Controls.Add(this.txtphone);
            this.pnl_CTI.Controls.Add(this.label4);
            this.pnl_CTI.Controls.Add(this.label24);
            this.pnl_CTI.Controls.Add(this.label26);
            this.pnl_CTI.Controls.Add(this.label25);
            this.pnl_CTI.Controls.Add(this.label1);
            this.pnl_CTI.ForeColor = System.Drawing.Color.White;
            this.pnl_CTI.Location = new System.Drawing.Point(4, 4);
            this.pnl_CTI.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_CTI.Name = "pnl_CTI";
            this.pnl_CTI.Size = new System.Drawing.Size(25, 36);
            this.pnl_CTI.TabIndex = 0;
            this.pnl_CTI.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_CTI_Paint);
            // 
            // lblcallback
            // 
            this.lblcallback.AutoSize = true;
            this.lblcallback.BackColor = System.Drawing.Color.Transparent;
            this.lblcallback.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcallback.ForeColor = System.Drawing.Color.Red;
            this.lblcallback.Location = new System.Drawing.Point(1255, 154);
            this.lblcallback.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcallback.Name = "lblcallback";
            this.lblcallback.Size = new System.Drawing.Size(104, 17);
            this.lblcallback.TabIndex = 79;
            this.lblcallback.Text = "Not Available";
            this.lblcallback.Click += new System.EventHandler(this.lblcallback_Click);
            // 
            // pnl_transfer
            // 
            this.pnl_transfer.BackColor = System.Drawing.Color.DimGray;
            this.pnl_transfer.Controls.Add(this.btn_trans);
            this.pnl_transfer.Controls.Add(this.cmbtrnsRoutepoint);
            this.pnl_transfer.Controls.Add(this.label2);
            this.pnl_transfer.Location = new System.Drawing.Point(752, 132);
            this.pnl_transfer.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_transfer.Name = "pnl_transfer";
            this.pnl_transfer.Size = new System.Drawing.Size(420, 48);
            this.pnl_transfer.TabIndex = 78;
            this.pnl_transfer.Visible = false;
            // 
            // btn_trans
            // 
            this.btn_trans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trans.ForeColor = System.Drawing.Color.Black;
            this.btn_trans.Location = new System.Drawing.Point(329, 7);
            this.btn_trans.Margin = new System.Windows.Forms.Padding(4);
            this.btn_trans.Name = "btn_trans";
            this.btn_trans.Size = new System.Drawing.Size(87, 28);
            this.btn_trans.TabIndex = 4;
            this.btn_trans.Text = "Transfer";
            this.btn_trans.UseVisualStyleBackColor = true;
            this.btn_trans.Click += new System.EventHandler(this.btn_trans_Click);
            // 
            // cmbtrnsRoutepoint
            // 
            this.cmbtrnsRoutepoint.FormattingEnabled = true;
            this.cmbtrnsRoutepoint.Location = new System.Drawing.Point(139, 10);
            this.cmbtrnsRoutepoint.Margin = new System.Windows.Forms.Padding(4);
            this.cmbtrnsRoutepoint.Name = "cmbtrnsRoutepoint";
            this.cmbtrnsRoutepoint.Size = new System.Drawing.Size(181, 24);
            this.cmbtrnsRoutepoint.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Routepoint :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pnlConf
            // 
            this.pnlConf.BackColor = System.Drawing.Color.DimGray;
            this.pnlConf.Controls.Add(this.btndisconnectconf);
            this.pnlConf.Controls.Add(this.label5);
            this.pnlConf.Controls.Add(this.cmbWarmtrnsRP);
            this.pnlConf.Controls.Add(this.btnconfdial);
            this.pnlConf.Controls.Add(this.txtconfmobile);
            this.pnlConf.Controls.Add(this.label3);
            this.pnlConf.Location = new System.Drawing.Point(737, 53);
            this.pnlConf.Margin = new System.Windows.Forms.Padding(4);
            this.pnlConf.Name = "pnlConf";
            this.pnlConf.Size = new System.Drawing.Size(420, 78);
            this.pnlConf.TabIndex = 46;
            this.pnlConf.Visible = false;
            // 
            // btndisconnectconf
            // 
            this.btndisconnectconf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndisconnectconf.ForeColor = System.Drawing.Color.Black;
            this.btndisconnectconf.Location = new System.Drawing.Point(300, 43);
            this.btndisconnectconf.Margin = new System.Windows.Forms.Padding(4);
            this.btndisconnectconf.Name = "btndisconnectconf";
            this.btndisconnectconf.Size = new System.Drawing.Size(112, 28);
            this.btndisconnectconf.TabIndex = 6;
            this.btndisconnectconf.Text = "Disconnect";
            this.btndisconnectconf.UseVisualStyleBackColor = true;
            this.btndisconnectconf.Click += new System.EventHandler(this.btndisconnectconf_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(45, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "RP :";
            // 
            // cmbWarmtrnsRP
            // 
            this.cmbWarmtrnsRP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarmtrnsRP.FormattingEnabled = true;
            this.cmbWarmtrnsRP.Location = new System.Drawing.Point(99, 43);
            this.cmbWarmtrnsRP.Margin = new System.Windows.Forms.Padding(4);
            this.cmbWarmtrnsRP.Name = "cmbWarmtrnsRP";
            this.cmbWarmtrnsRP.Size = new System.Drawing.Size(181, 24);
            this.cmbWarmtrnsRP.TabIndex = 4;
            // 
            // btnconfdial
            // 
            this.btnconfdial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconfdial.ForeColor = System.Drawing.Color.Black;
            this.btnconfdial.Location = new System.Drawing.Point(297, 9);
            this.btnconfdial.Margin = new System.Windows.Forms.Padding(4);
            this.btnconfdial.Name = "btnconfdial";
            this.btnconfdial.Size = new System.Drawing.Size(120, 28);
            this.btnconfdial.TabIndex = 2;
            this.btnconfdial.Text = "Dial";
            this.btnconfdial.UseVisualStyleBackColor = true;
            this.btnconfdial.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtconfmobile
            // 
            this.txtconfmobile.Location = new System.Drawing.Point(99, 11);
            this.txtconfmobile.Margin = new System.Windows.Forms.Padding(4);
            this.txtconfmobile.MaxLength = 10;
            this.txtconfmobile.Name = "txtconfmobile";
            this.txtconfmobile.Size = new System.Drawing.Size(181, 22);
            this.txtconfmobile.TabIndex = 1;
            this.txtconfmobile.TextChanged += new System.EventHandler(this.txtconfmobile_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(11, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mobile :";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::OneCRM.Properties.Resources.transfer;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(451, 101);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 49);
            this.button1.TabIndex = 77;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(3, 208);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 25);
            this.label7.TabIndex = 76;
            this.label7.Text = "*";
            // 
            // cmbphonenos
            // 
            this.cmbphonenos.BackColor = System.Drawing.Color.White;
            this.cmbphonenos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbphonenos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbphonenos.FormattingEnabled = true;
            this.cmbphonenos.Location = new System.Drawing.Point(12, 116);
            this.cmbphonenos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbphonenos.Name = "cmbphonenos";
            this.cmbphonenos.Size = new System.Drawing.Size(213, 24);
            this.cmbphonenos.TabIndex = 62;
            this.cmbphonenos.SelectedIndexChanged += new System.EventHandler(this.cmbphonenos_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(23, 183);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(21, 25);
            this.label18.TabIndex = 54;
            this.label18.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(673, 96);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 17);
            this.label15.TabIndex = 51;
            this.label15.Text = "CAMPAIGN        :";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(41, 128);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 25);
            this.label14.TabIndex = 45;
            this.label14.Text = "*";
            // 
            // lblcallstatus
            // 
            this.lblcallstatus.AutoSize = true;
            this.lblcallstatus.BackColor = System.Drawing.Color.Transparent;
            this.lblcallstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcallstatus.ForeColor = System.Drawing.Color.White;
            this.lblcallstatus.Location = new System.Drawing.Point(839, 150);
            this.lblcallstatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcallstatus.Name = "lblcallstatus";
            this.lblcallstatus.Size = new System.Drawing.Size(104, 17);
            this.lblcallstatus.TabIndex = 42;
            this.lblcallstatus.Text = "Not Available";
            this.lblcallstatus.Click += new System.EventHandler(this.lblcallstatus_Click);
            // 
            // txtmycode
            // 
            this.txtmycode.AutoSize = true;
            this.txtmycode.BackColor = System.Drawing.Color.Transparent;
            this.txtmycode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmycode.ForeColor = System.Drawing.Color.White;
            this.txtmycode.Location = new System.Drawing.Point(839, 124);
            this.txtmycode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtmycode.Name = "txtmycode";
            this.txtmycode.Size = new System.Drawing.Size(104, 17);
            this.txtmycode.TabIndex = 42;
            this.txtmycode.Text = "Not Available";
            this.txtmycode.Click += new System.EventHandler(this.txtmycode_Click);
            // 
            // LblStatus1
            // 
            this.LblStatus1.AutoSize = true;
            this.LblStatus1.BackColor = System.Drawing.Color.Transparent;
            this.LblStatus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStatus1.ForeColor = System.Drawing.Color.White;
            this.LblStatus1.Location = new System.Drawing.Point(1245, 97);
            this.LblStatus1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblStatus1.Name = "LblStatus1";
            this.LblStatus1.Size = new System.Drawing.Size(104, 17);
            this.LblStatus1.TabIndex = 42;
            this.LblStatus1.Text = "Not Available";
            this.LblStatus1.TextChanged += new System.EventHandler(this.LblStatus1_TextChanged);
            this.LblStatus1.Click += new System.EventHandler(this.LblStatus1_Click);
            // 
            // lblcampaign
            // 
            this.lblcampaign.AutoSize = true;
            this.lblcampaign.BackColor = System.Drawing.Color.Transparent;
            this.lblcampaign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcampaign.ForeColor = System.Drawing.Color.White;
            this.lblcampaign.Location = new System.Drawing.Point(839, 96);
            this.lblcampaign.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblcampaign.Name = "lblcampaign";
            this.lblcampaign.Size = new System.Drawing.Size(104, 17);
            this.lblcampaign.TabIndex = 42;
            this.lblcampaign.Text = "Not Available";
            this.lblcampaign.Click += new System.EventHandler(this.lblcampaign_Click);
            // 
            // btnagentready
            // 
            this.btnagentready.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnagentready.BackgroundImage")));
            this.btnagentready.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnagentready.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnagentready.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagentready.Location = new System.Drawing.Point(559, 102);
            this.btnagentready.Margin = new System.Windows.Forms.Padding(4);
            this.btnagentready.Name = "btnagentready";
            this.btnagentready.Size = new System.Drawing.Size(107, 49);
            this.btnagentready.TabIndex = 41;
            this.btnagentready.UseVisualStyleBackColor = true;
            this.btnagentready.Click += new System.EventHandler(this.btnagentready_Click);
            // 
            // ButtonHold
            // 
            this.ButtonHold.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ButtonHold.BackgroundImage")));
            this.ButtonHold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonHold.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHold.Location = new System.Drawing.Point(559, 53);
            this.ButtonHold.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonHold.Name = "ButtonHold";
            this.ButtonHold.Size = new System.Drawing.Size(107, 49);
            this.ButtonHold.TabIndex = 39;
            this.ButtonHold.UseVisualStyleBackColor = true;
            this.ButtonHold.Click += new System.EventHandler(this.ButtonHold_Click);
            // 
            // btn_ShowHide_CTI
            // 
            this.btn_ShowHide_CTI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ShowHide_CTI.BackgroundImage = global::OneCRM.Properties.Resources.minus;
            this.btn_ShowHide_CTI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ShowHide_CTI.Location = new System.Drawing.Point(-68, 2);
            this.btn_ShowHide_CTI.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ShowHide_CTI.Name = "btn_ShowHide_CTI";
            this.btn_ShowHide_CTI.Size = new System.Drawing.Size(59, 54);
            this.btn_ShowHide_CTI.TabIndex = 33;
            this.btn_ShowHide_CTI.Tag = "Edit";
            this.btn_ShowHide_CTI.UseVisualStyleBackColor = true;
            this.btn_ShowHide_CTI.Click += new System.EventHandler(this.btn_ShowHide_CTI_Click);
            // 
            // btnsubmit
            // 
            this.btnsubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnsubmit.BackgroundImage = global::OneCRM.Properties.Resources.submit;
            this.btnsubmit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsubmit.FlatAppearance.BorderSize = 0;
            this.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubmit.ForeColor = System.Drawing.Color.Transparent;
            this.btnsubmit.Location = new System.Drawing.Point(1508, 114);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(4);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(129, 48);
            this.btnsubmit.TabIndex = 38;
            this.btnsubmit.UseVisualStyleBackColor = false;
            this.btnsubmit.Visible = false;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackgroundImage = global::OneCRM.Properties.Resources.logout;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(-184, 58);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(129, 48);
            this.btnLogout.TabIndex = 36;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btn_LogOut_Click);
            // 
            // btn_Conference
            // 
            this.btn_Conference.BackgroundImage = global::OneCRM.Properties.Resources.conference;
            this.btn_Conference.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Conference.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Conference.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Conference.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Conference.Location = new System.Drawing.Point(451, 53);
            this.btn_Conference.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Conference.Name = "btn_Conference";
            this.btn_Conference.Size = new System.Drawing.Size(107, 49);
            this.btn_Conference.TabIndex = 34;
            this.btn_Conference.UseVisualStyleBackColor = true;
            this.btn_Conference.Click += new System.EventHandler(this.btn_Conference_Click);
            // 
            // btnBreak
            // 
            this.btnBreak.BackgroundImage = global::OneCRM.Properties.Resources._break;
            this.btnBreak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBreak.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBreak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBreak.Location = new System.Drawing.Point(344, 53);
            this.btnBreak.Margin = new System.Windows.Forms.Padding(4);
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.Size = new System.Drawing.Size(107, 97);
            this.btnBreak.TabIndex = 33;
            this.btnBreak.UseVisualStyleBackColor = true;
            this.btnBreak.Click += new System.EventHandler(this.btn_Break_Click);
            // 
            // cmdgetnext
            // 
            this.cmdgetnext.BackgroundImage = global::OneCRM.Properties.Resources.getnext;
            this.cmdgetnext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdgetnext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.cmdgetnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdgetnext.Location = new System.Drawing.Point(292, 101);
            this.cmdgetnext.Margin = new System.Windows.Forms.Padding(4);
            this.cmdgetnext.Name = "cmdgetnext";
            this.cmdgetnext.Size = new System.Drawing.Size(53, 49);
            this.cmdgetnext.TabIndex = 32;
            this.cmdgetnext.UseVisualStyleBackColor = true;
            this.cmdgetnext.Click += new System.EventHandler(this.btn_GetNext_Click);
            // 
            // btn_Transfer
            // 
            this.btn_Transfer.BackgroundImage = global::OneCRM.Properties.Resources.transfer;
            this.btn_Transfer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Transfer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Transfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Transfer.Location = new System.Drawing.Point(292, 53);
            this.btn_Transfer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Transfer.Name = "btn_Transfer";
            this.btn_Transfer.Size = new System.Drawing.Size(53, 49);
            this.btn_Transfer.TabIndex = 31;
            this.btn_Transfer.UseVisualStyleBackColor = true;
            this.btn_Transfer.Visible = false;
            this.btn_Transfer.Click += new System.EventHandler(this.btn_Transfer_Click);
            // 
            // ButtonHangUp
            // 
            this.ButtonHangUp.BackgroundImage = global::OneCRM.Properties.Resources._out;
            this.ButtonHangUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonHangUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonHangUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHangUp.Location = new System.Drawing.Point(240, 101);
            this.ButtonHangUp.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonHangUp.Name = "ButtonHangUp";
            this.ButtonHangUp.Size = new System.Drawing.Size(53, 49);
            this.ButtonHangUp.TabIndex = 30;
            this.ButtonHangUp.UseVisualStyleBackColor = true;
            this.ButtonHangUp.Click += new System.EventHandler(this.btn_Out_Click);
            // 
            // ButtonDial
            // 
            this.ButtonDial.BackgroundImage = global::OneCRM.Properties.Resources.call;
            this.ButtonDial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ButtonDial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ButtonDial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonDial.Location = new System.Drawing.Point(240, 53);
            this.ButtonDial.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDial.Name = "ButtonDial";
            this.ButtonDial.Size = new System.Drawing.Size(53, 49);
            this.ButtonDial.TabIndex = 29;
            this.ButtonDial.UseVisualStyleBackColor = true;
            this.ButtonDial.Click += new System.EventHandler(this.btn_Call_Click);
            // 
            // txt_campaignmode
            // 
            this.txt_campaignmode.Location = new System.Drawing.Point(1256, 58);
            this.txt_campaignmode.Margin = new System.Windows.Forms.Padding(4);
            this.txt_campaignmode.Name = "txt_campaignmode";
            this.txt_campaignmode.ReadOnly = true;
            this.txt_campaignmode.Size = new System.Drawing.Size(188, 22);
            this.txt_campaignmode.TabIndex = 27;
            this.txt_campaignmode.TextChanged += new System.EventHandler(this.txt_campaignmode_TextChanged);
            // 
            // txtbatchid
            // 
            this.txtbatchid.Location = new System.Drawing.Point(1259, 126);
            this.txtbatchid.Margin = new System.Windows.Forms.Padding(4);
            this.txtbatchid.Name = "txtbatchid";
            this.txtbatchid.ReadOnly = true;
            this.txtbatchid.Size = new System.Drawing.Size(185, 22);
            this.txtbatchid.TabIndex = 26;
            this.txtbatchid.TextChanged += new System.EventHandler(this.txtbatchid_TextChanged);
            // 
            // txt_AgentName
            // 
            this.txt_AgentName.Location = new System.Drawing.Point(841, 58);
            this.txt_AgentName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AgentName.Name = "txt_AgentName";
            this.txt_AgentName.ReadOnly = true;
            this.txt_AgentName.Size = new System.Drawing.Size(197, 22);
            this.txt_AgentName.TabIndex = 25;
            this.txt_AgentName.TextChanged += new System.EventHandler(this.txt_AgentName_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(1389, 96);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 17);
            this.label17.TabIndex = 20;
            this.label17.Text = "Not Available";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.White;
            this.label28.Location = new System.Drawing.Point(1061, 62);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(162, 17);
            this.label28.TabIndex = 11;
            this.label28.Text = "CAMPAIGN MODE    :";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(1064, 128);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(159, 17);
            this.label30.TabIndex = 10;
            this.label30.Text = "BATCHID                :";
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(13, 81);
            this.txtphone.Margin = new System.Windows.Forms.Padding(4);
            this.txtphone.MaxLength = 14;
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(212, 22);
            this.txtphone.TabIndex = 13;
            this.txtphone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersOnly);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(675, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "AGENT NAME   :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(673, 150);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(135, 17);
            this.label24.TabIndex = 12;
            this.label24.Text = "EVENT STATUS :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(675, 124);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(133, 17);
            this.label26.TabIndex = 12;
            this.label26.Text = "MYCODE           :";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(1061, 97);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(163, 17);
            this.label25.TabIndex = 12;
            this.label25.Text = "CURRENT STATUS  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "PHONE NUMBER :";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Snow;
            this.flowLayoutPanel1.Controls.Add(this.pnl_CTI);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1725, 239);
            this.flowLayoutPanel1.TabIndex = 9;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // CTI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(169, 21);
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CTI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CTI_Load);
            this.pnl_CTI.ResumeLayout(false);
            this.pnl_CTI.PerformLayout();
            this.pnl_transfer.ResumeLayout(false);
            this.pnl_transfer.PerformLayout();
            this.pnlConf.ResumeLayout(false);
            this.pnlConf.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnl_CTI;
        private System.Windows.Forms.Label lblcallback;
        private System.Windows.Forms.Panel pnl_transfer;
        private System.Windows.Forms.Button btn_trans;
        private System.Windows.Forms.ComboBox cmbtrnsRoutepoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlConf;
        private System.Windows.Forms.Button btndisconnectconf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbWarmtrnsRP;
        private System.Windows.Forms.Button btnconfdial;
        private System.Windows.Forms.TextBox txtconfmobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbphonenos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblcallstatus;
        private System.Windows.Forms.Label txtmycode;
        private System.Windows.Forms.Label LblStatus1;
        private System.Windows.Forms.Label lblcampaign;
        private System.Windows.Forms.Button btnagentready;
        private System.Windows.Forms.Button ButtonHold;
        private System.Windows.Forms.Button btn_ShowHide_CTI;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btn_Conference;
        private System.Windows.Forms.Button btnBreak;
        private System.Windows.Forms.Button cmdgetnext;
        private System.Windows.Forms.Button btn_Transfer;
        private System.Windows.Forms.Button ButtonHangUp;
        private System.Windows.Forms.Button ButtonDial;
        private System.Windows.Forms.TextBox txt_campaignmode;
        private System.Windows.Forms.TextBox txtbatchid;
        private System.Windows.Forms.TextBox txt_AgentName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

