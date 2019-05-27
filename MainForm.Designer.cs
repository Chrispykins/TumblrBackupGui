namespace TumblrBackupGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.OutputFolderText = new System.Windows.Forms.TextBox();
            this.OutputFolderButton = new System.Windows.Forms.Button();
            this.BlogNamePanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.ErrorText = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Folder:";
            // 
            // OutputFolderText
            // 
            this.OutputFolderText.Location = new System.Drawing.Point(19, 34);
            this.OutputFolderText.Name = "OutputFolderText";
            this.OutputFolderText.Size = new System.Drawing.Size(405, 28);
            this.OutputFolderText.TabIndex = 1;
            // 
            // OutputFolderButton
            // 
            this.OutputFolderButton.BackgroundImage = global::TumblrBackupGui.Properties.Resources.folder;
            this.OutputFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OutputFolderButton.Location = new System.Drawing.Point(430, 27);
            this.OutputFolderButton.Name = "OutputFolderButton";
            this.OutputFolderButton.Size = new System.Drawing.Size(40, 40);
            this.OutputFolderButton.TabIndex = 2;
            this.OutputFolderButton.UseVisualStyleBackColor = true;
            this.OutputFolderButton.Click += new System.EventHandler(this.OutputFolderButton_Click);
            // 
            // BlogNamePanel
            // 
            this.BlogNamePanel.AutoScroll = true;
            this.BlogNamePanel.Location = new System.Drawing.Point(16, 30);
            this.BlogNamePanel.Name = "BlogNamePanel";
            this.BlogNamePanel.Size = new System.Drawing.Size(634, 297);
            this.BlogNamePanel.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BlogNamePanel);
            this.groupBox1.Font = new System.Drawing.Font("Gentium Basic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(19, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 333);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blog Names";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Font = new System.Drawing.Font("GENUINE", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.DownloadButton.ForeColor = System.Drawing.Color.Black;
            this.DownloadButton.Location = new System.Drawing.Point(542, 488);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(127, 41);
            this.DownloadButton.TabIndex = 6;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSize = true;
            this.ErrorText.Font = new System.Drawing.Font("Gentium Basic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorText.ForeColor = System.Drawing.Color.LightSalmon;
            this.ErrorText.Location = new System.Drawing.Point(15, 439);
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.Size = new System.Drawing.Size(0, 23);
            this.ErrorText.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(83)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(687, 547);
            this.Controls.Add(this.ErrorText);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OutputFolderButton);
            this.Controls.Add(this.OutputFolderText);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Gentium Basic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Tumblr Backup";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox OutputFolderText;
        private System.Windows.Forms.Button OutputFolderButton;
        private System.Windows.Forms.Panel BlogNamePanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Label ErrorText;
    }
}

