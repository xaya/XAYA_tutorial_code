namespace HelloXaya
{
    partial class HelloXaya
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
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnGetFromCookie = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnLaunchWrapper = new System.Windows.Forms.Button();
            this.lblSayHello = new System.Windows.Forms.Label();
            this.txtHelloWorld = new System.Windows.Forms.TextBox();
            this.btnSayHelloWorld = new System.Windows.Forms.Button();
            this.txtHelloGameState = new System.Windows.Forms.TextBox();
            this.lblOtherPeople = new System.Windows.Forms.Label();
            this.cbxNames = new System.Windows.Forms.ComboBox();
            this.btnStartXayaService = new System.Windows.Forms.Button();
            this.lblNames = new System.Windows.Forms.Label();
            this.gbx1 = new System.Windows.Forms.GroupBox();
            this.gbx2 = new System.Windows.Forms.GroupBox();
            this.gbx3 = new System.Windows.Forms.GroupBox();
            this.gbx1.SuspendLayout();
            this.gbx2.SuspendLayout();
            this.gbx3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 21);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 13);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Username";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(65, 18);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(175, 20);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(65, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(412, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 47);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password";
            // 
            // btnGetFromCookie
            // 
            this.btnGetFromCookie.Location = new System.Drawing.Point(246, 16);
            this.btnGetFromCookie.Name = "btnGetFromCookie";
            this.btnGetFromCookie.Size = new System.Drawing.Size(231, 23);
            this.btnGetFromCookie.TabIndex = 4;
            this.btnGetFromCookie.Text = "Get username and password from .cookie";
            this.btnGetFromCookie.UseVisualStyleBackColor = true;
            this.btnGetFromCookie.Click += new System.EventHandler(this.btnGetFromCookie_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(243, 73);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 6;
            this.lblPort.Text = "Port";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(6, 73);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(29, 13);
            this.lblHost.TabIndex = 5;
            this.lblHost.Text = "Host";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(275, 70);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(202, 20);
            this.txtPort.TabIndex = 8;
            this.txtPort.Text = "8396";
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(67, 70);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(162, 20);
            this.txtHost.TabIndex = 7;
            this.txtHost.Text = "http://127.0.0.1";
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // btnLaunchWrapper
            // 
            this.btnLaunchWrapper.Location = new System.Drawing.Point(9, 19);
            this.btnLaunchWrapper.Name = "btnLaunchWrapper";
            this.btnLaunchWrapper.Size = new System.Drawing.Size(468, 23);
            this.btnLaunchWrapper.TabIndex = 9;
            this.btnLaunchWrapper.Text = "Launch and Connect to XAYAWrapper";
            this.btnLaunchWrapper.UseVisualStyleBackColor = true;
            this.btnLaunchWrapper.Click += new System.EventHandler(this.btnLaunchWrapper_Click);
            // 
            // lblSayHello
            // 
            this.lblSayHello.Location = new System.Drawing.Point(6, 45);
            this.lblSayHello.Name = "lblSayHello";
            this.lblSayHello.Size = new System.Drawing.Size(471, 39);
            this.lblSayHello.TabIndex = 10;
            this.lblSayHello.Text = "Say HELLO WORLD!\r\n\r\nType in the text box, then click HELLO WORLD!";
            this.lblSayHello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHelloWorld
            // 
            this.txtHelloWorld.Location = new System.Drawing.Point(9, 87);
            this.txtHelloWorld.MaxLength = 20;
            this.txtHelloWorld.Name = "txtHelloWorld";
            this.txtHelloWorld.Size = new System.Drawing.Size(468, 20);
            this.txtHelloWorld.TabIndex = 11;
            // 
            // btnSayHelloWorld
            // 
            this.btnSayHelloWorld.Location = new System.Drawing.Point(9, 113);
            this.btnSayHelloWorld.Name = "btnSayHelloWorld";
            this.btnSayHelloWorld.Size = new System.Drawing.Size(468, 23);
            this.btnSayHelloWorld.TabIndex = 12;
            this.btnSayHelloWorld.Text = "HELLO WORLD!";
            this.btnSayHelloWorld.UseVisualStyleBackColor = true;
            this.btnSayHelloWorld.Click += new System.EventHandler(this.btnSayHelloWorld_Click);
            // 
            // txtHelloGameState
            // 
            this.txtHelloGameState.Location = new System.Drawing.Point(9, 181);
            this.txtHelloGameState.Multiline = true;
            this.txtHelloGameState.Name = "txtHelloGameState";
            this.txtHelloGameState.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHelloGameState.Size = new System.Drawing.Size(468, 148);
            this.txtHelloGameState.TabIndex = 13;
            // 
            // lblOtherPeople
            // 
            this.lblOtherPeople.Location = new System.Drawing.Point(6, 139);
            this.lblOtherPeople.Name = "lblOtherPeople";
            this.lblOtherPeople.Size = new System.Drawing.Size(471, 39);
            this.lblOtherPeople.TabIndex = 14;
            this.lblOtherPeople.Text = "Here are HELLO WORLD!s from other people!";
            this.lblOtherPeople.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxNames
            // 
            this.cbxNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNames.FormattingEnabled = true;
            this.cbxNames.Location = new System.Drawing.Point(62, 48);
            this.cbxNames.Name = "cbxNames";
            this.cbxNames.Size = new System.Drawing.Size(418, 21);
            this.cbxNames.TabIndex = 16;
            // 
            // btnStartXayaService
            // 
            this.btnStartXayaService.Location = new System.Drawing.Point(6, 19);
            this.btnStartXayaService.Name = "btnStartXayaService";
            this.btnStartXayaService.Size = new System.Drawing.Size(474, 23);
            this.btnStartXayaService.TabIndex = 17;
            this.btnStartXayaService.Text = "Start xayaService";
            this.btnStartXayaService.UseVisualStyleBackColor = true;
            this.btnStartXayaService.Click += new System.EventHandler(this.btnStartXayaService_Click);
            // 
            // lblNames
            // 
            this.lblNames.AutoSize = true;
            this.lblNames.Location = new System.Drawing.Point(3, 51);
            this.lblNames.Name = "lblNames";
            this.lblNames.Size = new System.Drawing.Size(40, 13);
            this.lblNames.TabIndex = 18;
            this.lblNames.Text = "Names";
            // 
            // gbx1
            // 
            this.gbx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx1.Controls.Add(this.lblUser);
            this.gbx1.Controls.Add(this.txtUser);
            this.gbx1.Controls.Add(this.lblPassword);
            this.gbx1.Controls.Add(this.txtPassword);
            this.gbx1.Controls.Add(this.btnGetFromCookie);
            this.gbx1.Controls.Add(this.lblHost);
            this.gbx1.Controls.Add(this.lblPort);
            this.gbx1.Controls.Add(this.txtHost);
            this.gbx1.Controls.Add(this.txtPort);
            this.gbx1.Location = new System.Drawing.Point(12, 5);
            this.gbx1.Name = "gbx1";
            this.gbx1.Size = new System.Drawing.Size(486, 96);
            this.gbx1.TabIndex = 19;
            this.gbx1.TabStop = false;
            this.gbx1.Text = "1) Collect data for the XAYA RPC URL";
            // 
            // gbx2
            // 
            this.gbx2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx2.Controls.Add(this.lblNames);
            this.gbx2.Controls.Add(this.cbxNames);
            this.gbx2.Controls.Add(this.btnStartXayaService);
            this.gbx2.Location = new System.Drawing.Point(12, 116);
            this.gbx2.Name = "gbx2";
            this.gbx2.Size = new System.Drawing.Size(486, 88);
            this.gbx2.TabIndex = 20;
            this.gbx2.TabStop = false;
            this.gbx2.Text = "2) Start the xayaService and choose a name if you wish to play";
            // 
            // gbx3
            // 
            this.gbx3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx3.BackColor = System.Drawing.SystemColors.Control;
            this.gbx3.Controls.Add(this.btnLaunchWrapper);
            this.gbx3.Controls.Add(this.lblSayHello);
            this.gbx3.Controls.Add(this.lblOtherPeople);
            this.gbx3.Controls.Add(this.txtHelloWorld);
            this.gbx3.Controls.Add(this.txtHelloGameState);
            this.gbx3.Controls.Add(this.btnSayHelloWorld);
            this.gbx3.Location = new System.Drawing.Point(15, 218);
            this.gbx3.Name = "gbx3";
            this.gbx3.Size = new System.Drawing.Size(483, 337);
            this.gbx3.TabIndex = 21;
            this.gbx3.TabStop = false;
            this.gbx3.Text = "3) Launch and connect to XAYAWrapper. If xayaService is started, you can say hell" +
    "o.";
            // 
            // HelloXaya
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 564);
            this.Controls.Add(this.gbx3);
            this.Controls.Add(this.gbx2);
            this.Controls.Add(this.gbx1);
            this.Name = "HelloXaya";
            this.Text = "Hello World! with HelloXaya";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelloXaya_FormClosing);
            this.Load += new System.EventHandler(this.HelloXaya_Load);
            this.gbx1.ResumeLayout(false);
            this.gbx1.PerformLayout();
            this.gbx2.ResumeLayout(false);
            this.gbx2.PerformLayout();
            this.gbx3.ResumeLayout(false);
            this.gbx3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnGetFromCookie;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Button btnLaunchWrapper;
        private System.Windows.Forms.Label lblSayHello;
        private System.Windows.Forms.TextBox txtHelloWorld;
        private System.Windows.Forms.Button btnSayHelloWorld;
        private System.Windows.Forms.TextBox txtHelloGameState;
        private System.Windows.Forms.Label lblOtherPeople;
        private System.Windows.Forms.ComboBox cbxNames;
        private System.Windows.Forms.Button btnStartXayaService;
        private System.Windows.Forms.Label lblNames;
        private System.Windows.Forms.GroupBox gbx1;
        private System.Windows.Forms.GroupBox gbx2;
        private System.Windows.Forms.GroupBox gbx3;
    }
}

