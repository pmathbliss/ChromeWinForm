namespace ChromeWinForm
{
    partial class MainForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbChromecasts = new System.Windows.Forms.GroupBox();
            this.lbChromeCasts = new System.Windows.Forms.ListBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.gbUrlBox = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCast = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.lblChromeCastName = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbChromecasts.SuspendLayout();
            this.gbUrlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.gbChromecasts);
            this.flowLayoutPanel1.Controls.Add(this.gbUrlBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(437, 313);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // gbChromecasts
            // 
            this.gbChromecasts.Controls.Add(this.lbChromeCasts);
            this.gbChromecasts.Controls.Add(this.btnFind);
            this.gbChromecasts.Location = new System.Drawing.Point(3, 3);
            this.gbChromecasts.Name = "gbChromecasts";
            this.gbChromecasts.Size = new System.Drawing.Size(423, 139);
            this.gbChromecasts.TabIndex = 0;
            this.gbChromecasts.TabStop = false;
            this.gbChromecasts.Text = "Chromecasts";
            // 
            // lbChromeCasts
            // 
            this.lbChromeCasts.FormattingEnabled = true;
            this.lbChromeCasts.Location = new System.Drawing.Point(91, 20);
            this.lbChromeCasts.Name = "lbChromeCasts";
            this.lbChromeCasts.Size = new System.Drawing.Size(259, 95);
            this.lbChromeCasts.TabIndex = 1;
            this.lbChromeCasts.SelectedIndexChanged += new System.EventHandler(this.lbChromeCasts_SelectedIndexChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(9, 19);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_ClickAsync);
            // 
            // gbUrlBox
            // 
            this.gbUrlBox.Controls.Add(this.btnDisconnect);
            this.gbUrlBox.Controls.Add(this.btnConnect);
            this.gbUrlBox.Controls.Add(this.lblStatus);
            this.gbUrlBox.Controls.Add(this.btnCast);
            this.gbUrlBox.Controls.Add(this.lblUrl);
            this.gbUrlBox.Controls.Add(this.txtURL);
            this.gbUrlBox.Controls.Add(this.lblChromeCastName);
            this.gbUrlBox.Location = new System.Drawing.Point(3, 148);
            this.gbUrlBox.Name = "gbUrlBox";
            this.gbUrlBox.Size = new System.Drawing.Size(423, 153);
            this.gbUrlBox.TabIndex = 1;
            this.gbUrlBox.TabStop = false;
            this.gbUrlBox.Text = "URL";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 127);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 2;
            // 
            // btnCast
            // 
            this.btnCast.Enabled = false;
            this.btnCast.Location = new System.Drawing.Point(10, 92);
            this.btnCast.Name = "btnCast";
            this.btnCast.Size = new System.Drawing.Size(75, 23);
            this.btnCast.TabIndex = 3;
            this.btnCast.Text = "Connect";
            this.btnCast.UseVisualStyleBackColor = true;
            this.btnCast.Click += new System.EventHandler(this.btnCast_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(10, 46);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(29, 13);
            this.lblUrl.TabIndex = 2;
            this.lblUrl.Text = "URL";
            // 
            // txtURL
            // 
            this.txtURL.Enabled = false;
            this.txtURL.Location = new System.Drawing.Point(10, 65);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(407, 20);
            this.txtURL.TabIndex = 1;
            this.txtURL.Text = "https://www.pexels.com/search/nature/";
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // lblChromeCastName
            // 
            this.lblChromeCastName.AutoSize = true;
            this.lblChromeCastName.Location = new System.Drawing.Point(7, 20);
            this.lblChromeCastName.Name = "lblChromeCastName";
            this.lblChromeCastName.Size = new System.Drawing.Size(0, 13);
            this.lblChromeCastName.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(91, 92);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Cast";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(172, 92);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 313);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Chromecast WinForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbChromecasts.ResumeLayout(false);
            this.gbUrlBox.ResumeLayout(false);
            this.gbUrlBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbChromecasts;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ListBox lbChromeCasts;
        private System.Windows.Forms.GroupBox gbUrlBox;
        private System.Windows.Forms.Label lblChromeCastName;
        private System.Windows.Forms.Button btnCast;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
    }
}

