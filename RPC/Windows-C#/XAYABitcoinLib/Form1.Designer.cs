namespace XAYABitcoinLib
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtShowName = new System.Windows.Forms.TextBox();
            this.btnShowName = new System.Windows.Forms.Button();
            this.txtShowNameResult = new System.Windows.Forms.TextBox();
            this.txtRegisterName = new System.Windows.Forms.TextBox();
            this.btnRegisterName = new System.Windows.Forms.Button();
            this.txtRegisterNameResult = new System.Windows.Forms.TextBox();
            this.tabXaya = new System.Windows.Forms.TabControl();
            this.tabShowName = new System.Windows.Forms.TabPage();
            this.txtShowNameInfo = new System.Windows.Forms.TextBox();
            this.tabRegisterName = new System.Windows.Forms.TabPage();
            this.txtRegisterNameInfo = new System.Windows.Forms.TextBox();
            this.tabGetBlockHeight = new System.Windows.Forms.TabPage();
            this.txtGetBlockHeightInfo = new System.Windows.Forms.TextBox();
            this.txtGetBlockHeightResult = new System.Windows.Forms.TextBox();
            this.btnGetBlockHeight = new System.Windows.Forms.Button();
            this.tabGetWalletNames = new System.Windows.Forms.TabPage();
            this.txtGetWalletNamesInfo = new System.Windows.Forms.TextBox();
            this.txtGetWalletNamesResult = new System.Windows.Forms.TextBox();
            this.btnGetWalletNames = new System.Windows.Forms.Button();
            this.tabUpdateName = new System.Windows.Forms.TabPage();
            this.txtUpdateNameValue = new System.Windows.Forms.TextBox();
            this.txtUpdateNameInfo = new System.Windows.Forms.TextBox();
            this.txtUpdateNameResult = new System.Windows.Forms.TextBox();
            this.txtUpdateNameName = new System.Windows.Forms.TextBox();
            this.btnUpdateName = new System.Windows.Forms.Button();
            this.tabXaya.SuspendLayout();
            this.tabShowName.SuspendLayout();
            this.tabRegisterName.SuspendLayout();
            this.tabGetBlockHeight.SuspendLayout();
            this.tabGetWalletNames.SuspendLayout();
            this.tabUpdateName.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtShowName
            // 
            this.txtShowName.Location = new System.Drawing.Point(6, 66);
            this.txtShowName.Name = "txtShowName";
            this.txtShowName.Size = new System.Drawing.Size(193, 20);
            this.txtShowName.TabIndex = 0;
            this.txtShowName.Text = "p/";
            this.txtShowName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShowName_KeyDown);
            // 
            // btnShowName
            // 
            this.btnShowName.Location = new System.Drawing.Point(205, 64);
            this.btnShowName.Name = "btnShowName";
            this.btnShowName.Size = new System.Drawing.Size(132, 23);
            this.btnShowName.TabIndex = 1;
            this.btnShowName.Text = "Show Name";
            this.btnShowName.UseVisualStyleBackColor = true;
            this.btnShowName.Click += new System.EventHandler(this.btnShowName_Click);
            // 
            // txtShowNameResult
            // 
            this.txtShowNameResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShowNameResult.Location = new System.Drawing.Point(6, 93);
            this.txtShowNameResult.Multiline = true;
            this.txtShowNameResult.Name = "txtShowNameResult";
            this.txtShowNameResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShowNameResult.Size = new System.Drawing.Size(537, 391);
            this.txtShowNameResult.TabIndex = 2;
            // 
            // txtRegisterName
            // 
            this.txtRegisterName.Location = new System.Drawing.Point(6, 66);
            this.txtRegisterName.Name = "txtRegisterName";
            this.txtRegisterName.Size = new System.Drawing.Size(193, 20);
            this.txtRegisterName.TabIndex = 3;
            this.txtRegisterName.Text = "p/";
            // 
            // btnRegisterName
            // 
            this.btnRegisterName.Location = new System.Drawing.Point(205, 63);
            this.btnRegisterName.Name = "btnRegisterName";
            this.btnRegisterName.Size = new System.Drawing.Size(132, 23);
            this.btnRegisterName.TabIndex = 4;
            this.btnRegisterName.Text = "Register Name";
            this.btnRegisterName.UseVisualStyleBackColor = true;
            this.btnRegisterName.Click += new System.EventHandler(this.btnRegisterName_Click);
            // 
            // txtRegisterNameResult
            // 
            this.txtRegisterNameResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegisterNameResult.Location = new System.Drawing.Point(6, 92);
            this.txtRegisterNameResult.Multiline = true;
            this.txtRegisterNameResult.Name = "txtRegisterNameResult";
            this.txtRegisterNameResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRegisterNameResult.Size = new System.Drawing.Size(537, 392);
            this.txtRegisterNameResult.TabIndex = 5;
            // 
            // tabXaya
            // 
            this.tabXaya.Controls.Add(this.tabShowName);
            this.tabXaya.Controls.Add(this.tabRegisterName);
            this.tabXaya.Controls.Add(this.tabGetBlockHeight);
            this.tabXaya.Controls.Add(this.tabGetWalletNames);
            this.tabXaya.Controls.Add(this.tabUpdateName);
            this.tabXaya.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabXaya.Location = new System.Drawing.Point(0, 0);
            this.tabXaya.Name = "tabXaya";
            this.tabXaya.SelectedIndex = 0;
            this.tabXaya.Size = new System.Drawing.Size(557, 516);
            this.tabXaya.TabIndex = 6;
            // 
            // tabShowName
            // 
            this.tabShowName.Controls.Add(this.txtShowNameInfo);
            this.tabShowName.Controls.Add(this.txtShowNameResult);
            this.tabShowName.Controls.Add(this.txtShowName);
            this.tabShowName.Controls.Add(this.btnShowName);
            this.tabShowName.Location = new System.Drawing.Point(4, 22);
            this.tabShowName.Name = "tabShowName";
            this.tabShowName.Padding = new System.Windows.Forms.Padding(3);
            this.tabShowName.Size = new System.Drawing.Size(549, 490);
            this.tabShowName.TabIndex = 0;
            this.tabShowName.Text = "Show Name";
            this.tabShowName.UseVisualStyleBackColor = true;
            // 
            // txtShowNameInfo
            // 
            this.txtShowNameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShowNameInfo.Location = new System.Drawing.Point(6, 6);
            this.txtShowNameInfo.Multiline = true;
            this.txtShowNameInfo.Name = "txtShowNameInfo";
            this.txtShowNameInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShowNameInfo.Size = new System.Drawing.Size(537, 52);
            this.txtShowNameInfo.TabIndex = 3;
            this.txtShowNameInfo.Text = resources.GetString("txtShowNameInfo.Text");
            // 
            // tabRegisterName
            // 
            this.tabRegisterName.Controls.Add(this.txtRegisterNameInfo);
            this.tabRegisterName.Controls.Add(this.txtRegisterNameResult);
            this.tabRegisterName.Controls.Add(this.txtRegisterName);
            this.tabRegisterName.Controls.Add(this.btnRegisterName);
            this.tabRegisterName.Location = new System.Drawing.Point(4, 22);
            this.tabRegisterName.Name = "tabRegisterName";
            this.tabRegisterName.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegisterName.Size = new System.Drawing.Size(549, 490);
            this.tabRegisterName.TabIndex = 1;
            this.tabRegisterName.Text = "Register Name";
            this.tabRegisterName.UseVisualStyleBackColor = true;
            // 
            // txtRegisterNameInfo
            // 
            this.txtRegisterNameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegisterNameInfo.Location = new System.Drawing.Point(6, 6);
            this.txtRegisterNameInfo.Multiline = true;
            this.txtRegisterNameInfo.Name = "txtRegisterNameInfo";
            this.txtRegisterNameInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRegisterNameInfo.Size = new System.Drawing.Size(537, 54);
            this.txtRegisterNameInfo.TabIndex = 4;
            this.txtRegisterNameInfo.Text = "Enter a name in the text box then click \"Register Name\" to create a new name. \r\n\r" +
    "\nCheck the code to see how simple it is.\r\n";
            // 
            // tabGetBlockHeight
            // 
            this.tabGetBlockHeight.Controls.Add(this.txtGetBlockHeightInfo);
            this.tabGetBlockHeight.Controls.Add(this.txtGetBlockHeightResult);
            this.tabGetBlockHeight.Controls.Add(this.btnGetBlockHeight);
            this.tabGetBlockHeight.Location = new System.Drawing.Point(4, 22);
            this.tabGetBlockHeight.Name = "tabGetBlockHeight";
            this.tabGetBlockHeight.Padding = new System.Windows.Forms.Padding(3);
            this.tabGetBlockHeight.Size = new System.Drawing.Size(549, 490);
            this.tabGetBlockHeight.TabIndex = 2;
            this.tabGetBlockHeight.Text = "Get Block Height";
            this.tabGetBlockHeight.UseVisualStyleBackColor = true;
            // 
            // txtGetBlockHeightInfo
            // 
            this.txtGetBlockHeightInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGetBlockHeightInfo.Location = new System.Drawing.Point(6, 6);
            this.txtGetBlockHeightInfo.Multiline = true;
            this.txtGetBlockHeightInfo.Name = "txtGetBlockHeightInfo";
            this.txtGetBlockHeightInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGetBlockHeightInfo.Size = new System.Drawing.Size(537, 54);
            this.txtGetBlockHeightInfo.TabIndex = 7;
            this.txtGetBlockHeightInfo.Text = "Click \"Get Block Height\" to find out the current block height. Blocks come in eve" +
    "ry 30 seconds on average. \r\n\r\nCheck the code to see how simple it is.\r\n";
            // 
            // txtGetBlockHeightResult
            // 
            this.txtGetBlockHeightResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGetBlockHeightResult.Location = new System.Drawing.Point(6, 92);
            this.txtGetBlockHeightResult.Multiline = true;
            this.txtGetBlockHeightResult.Name = "txtGetBlockHeightResult";
            this.txtGetBlockHeightResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGetBlockHeightResult.Size = new System.Drawing.Size(537, 392);
            this.txtGetBlockHeightResult.TabIndex = 9;
            // 
            // btnGetBlockHeight
            // 
            this.btnGetBlockHeight.Location = new System.Drawing.Point(8, 63);
            this.btnGetBlockHeight.Name = "btnGetBlockHeight";
            this.btnGetBlockHeight.Size = new System.Drawing.Size(132, 23);
            this.btnGetBlockHeight.TabIndex = 8;
            this.btnGetBlockHeight.Text = "Get Block Height";
            this.btnGetBlockHeight.UseVisualStyleBackColor = true;
            this.btnGetBlockHeight.Click += new System.EventHandler(this.btnGetBlockHeight_Click);
            // 
            // tabGetWalletNames
            // 
            this.tabGetWalletNames.Controls.Add(this.txtGetWalletNamesInfo);
            this.tabGetWalletNames.Controls.Add(this.txtGetWalletNamesResult);
            this.tabGetWalletNames.Controls.Add(this.btnGetWalletNames);
            this.tabGetWalletNames.Location = new System.Drawing.Point(4, 22);
            this.tabGetWalletNames.Name = "tabGetWalletNames";
            this.tabGetWalletNames.Padding = new System.Windows.Forms.Padding(3);
            this.tabGetWalletNames.Size = new System.Drawing.Size(549, 490);
            this.tabGetWalletNames.TabIndex = 3;
            this.tabGetWalletNames.Text = "Get Wallet Names";
            this.tabGetWalletNames.UseVisualStyleBackColor = true;
            // 
            // txtGetWalletNamesInfo
            // 
            this.txtGetWalletNamesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGetWalletNamesInfo.Location = new System.Drawing.Point(6, 6);
            this.txtGetWalletNamesInfo.Multiline = true;
            this.txtGetWalletNamesInfo.Name = "txtGetWalletNamesInfo";
            this.txtGetWalletNamesInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGetWalletNamesInfo.Size = new System.Drawing.Size(537, 54);
            this.txtGetWalletNamesInfo.TabIndex = 10;
            this.txtGetWalletNamesInfo.Text = "Click \"Get Wallet Names\" to get a list of all names in your wallet. \r\n\r\nCheck the" +
    " code to see how simple it is.\r\n";
            // 
            // txtGetWalletNamesResult
            // 
            this.txtGetWalletNamesResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGetWalletNamesResult.Location = new System.Drawing.Point(6, 92);
            this.txtGetWalletNamesResult.Multiline = true;
            this.txtGetWalletNamesResult.Name = "txtGetWalletNamesResult";
            this.txtGetWalletNamesResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGetWalletNamesResult.Size = new System.Drawing.Size(537, 392);
            this.txtGetWalletNamesResult.TabIndex = 12;
            // 
            // btnGetWalletNames
            // 
            this.btnGetWalletNames.Location = new System.Drawing.Point(8, 63);
            this.btnGetWalletNames.Name = "btnGetWalletNames";
            this.btnGetWalletNames.Size = new System.Drawing.Size(132, 23);
            this.btnGetWalletNames.TabIndex = 11;
            this.btnGetWalletNames.Text = "Get Wallet Names";
            this.btnGetWalletNames.UseVisualStyleBackColor = true;
            this.btnGetWalletNames.Click += new System.EventHandler(this.btnGetWalletNames_Click);
            // 
            // tabUpdateName
            // 
            this.tabUpdateName.Controls.Add(this.txtUpdateNameValue);
            this.tabUpdateName.Controls.Add(this.txtUpdateNameInfo);
            this.tabUpdateName.Controls.Add(this.txtUpdateNameResult);
            this.tabUpdateName.Controls.Add(this.txtUpdateNameName);
            this.tabUpdateName.Controls.Add(this.btnUpdateName);
            this.tabUpdateName.Location = new System.Drawing.Point(4, 22);
            this.tabUpdateName.Name = "tabUpdateName";
            this.tabUpdateName.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdateName.Size = new System.Drawing.Size(549, 490);
            this.tabUpdateName.TabIndex = 4;
            this.tabUpdateName.Text = "Update Name";
            this.tabUpdateName.UseVisualStyleBackColor = true;
            // 
            // txtUpdateNameValue
            // 
            this.txtUpdateNameValue.Location = new System.Drawing.Point(205, 66);
            this.txtUpdateNameValue.Name = "txtUpdateNameValue";
            this.txtUpdateNameValue.Size = new System.Drawing.Size(193, 20);
            this.txtUpdateNameValue.TabIndex = 10;
            this.txtUpdateNameValue.Text = "{}";
            // 
            // txtUpdateNameInfo
            // 
            this.txtUpdateNameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateNameInfo.Location = new System.Drawing.Point(6, 6);
            this.txtUpdateNameInfo.Multiline = true;
            this.txtUpdateNameInfo.Name = "txtUpdateNameInfo";
            this.txtUpdateNameInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUpdateNameInfo.Size = new System.Drawing.Size(537, 54);
            this.txtUpdateNameInfo.TabIndex = 7;
            this.txtUpdateNameInfo.Text = "Enter a name in the left text box and a JSON value in the right input. Click \"Upd" +
    "ate Name\". \r\n\r\nCheck the code to see how simple it is.\r\n";
            // 
            // txtUpdateNameResult
            // 
            this.txtUpdateNameResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateNameResult.Location = new System.Drawing.Point(6, 92);
            this.txtUpdateNameResult.Multiline = true;
            this.txtUpdateNameResult.Name = "txtUpdateNameResult";
            this.txtUpdateNameResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUpdateNameResult.Size = new System.Drawing.Size(537, 392);
            this.txtUpdateNameResult.TabIndex = 9;
            // 
            // txtUpdateNameName
            // 
            this.txtUpdateNameName.Location = new System.Drawing.Point(6, 66);
            this.txtUpdateNameName.Name = "txtUpdateNameName";
            this.txtUpdateNameName.Size = new System.Drawing.Size(193, 20);
            this.txtUpdateNameName.TabIndex = 6;
            this.txtUpdateNameName.Text = "p/";
            // 
            // btnUpdateName
            // 
            this.btnUpdateName.Location = new System.Drawing.Point(404, 64);
            this.btnUpdateName.Name = "btnUpdateName";
            this.btnUpdateName.Size = new System.Drawing.Size(132, 23);
            this.btnUpdateName.TabIndex = 8;
            this.btnUpdateName.Text = "Update Name";
            this.btnUpdateName.UseVisualStyleBackColor = true;
            this.btnUpdateName.Click += new System.EventHandler(this.btnUpdateName_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 516);
            this.Controls.Add(this.tabXaya);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabXaya.ResumeLayout(false);
            this.tabShowName.ResumeLayout(false);
            this.tabShowName.PerformLayout();
            this.tabRegisterName.ResumeLayout(false);
            this.tabRegisterName.PerformLayout();
            this.tabGetBlockHeight.ResumeLayout(false);
            this.tabGetBlockHeight.PerformLayout();
            this.tabGetWalletNames.ResumeLayout(false);
            this.tabGetWalletNames.PerformLayout();
            this.tabUpdateName.ResumeLayout(false);
            this.tabUpdateName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtShowName;
        private System.Windows.Forms.Button btnShowName;
        private System.Windows.Forms.TextBox txtShowNameResult;
        private System.Windows.Forms.TextBox txtRegisterName;
        private System.Windows.Forms.Button btnRegisterName;
        private System.Windows.Forms.TextBox txtRegisterNameResult;
        private System.Windows.Forms.TabControl tabXaya;
        private System.Windows.Forms.TabPage tabShowName;
        private System.Windows.Forms.TextBox txtShowNameInfo;
        private System.Windows.Forms.TabPage tabRegisterName;
        private System.Windows.Forms.TextBox txtRegisterNameInfo;
        private System.Windows.Forms.TabPage tabGetBlockHeight;
        private System.Windows.Forms.TextBox txtGetBlockHeightInfo;
        private System.Windows.Forms.TextBox txtGetBlockHeightResult;
        private System.Windows.Forms.Button btnGetBlockHeight;
        private System.Windows.Forms.TabPage tabGetWalletNames;
        private System.Windows.Forms.TextBox txtGetWalletNamesInfo;
        private System.Windows.Forms.TextBox txtGetWalletNamesResult;
        private System.Windows.Forms.Button btnGetWalletNames;
        private System.Windows.Forms.TabPage tabUpdateName;
        private System.Windows.Forms.TextBox txtUpdateNameValue;
        private System.Windows.Forms.TextBox txtUpdateNameInfo;
        private System.Windows.Forms.TextBox txtUpdateNameResult;
        private System.Windows.Forms.TextBox txtUpdateNameName;
        private System.Windows.Forms.Button btnUpdateName;
    }
}

