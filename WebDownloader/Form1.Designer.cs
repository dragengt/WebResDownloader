namespace WebDownloader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_startDownload = new System.Windows.Forms.Button();
            this.tb_addressToDownload = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_broswer = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.tb_saveTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_logView = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_startDownload
            // 
            this.btn_startDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_startDownload.Location = new System.Drawing.Point(197, 226);
            this.btn_startDownload.Name = "btn_startDownload";
            this.btn_startDownload.Size = new System.Drawing.Size(75, 23);
            this.btn_startDownload.TabIndex = 4;
            this.btn_startDownload.Text = "start";
            this.btn_startDownload.UseVisualStyleBackColor = true;
            this.btn_startDownload.Click += new System.EventHandler(this.btn_startDownload_Click);
            // 
            // tb_addressToDownload
            // 
            this.tb_addressToDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_addressToDownload.Location = new System.Drawing.Point(12, 29);
            this.tb_addressToDownload.Name = "tb_addressToDownload";
            this.tb_addressToDownload.Size = new System.Drawing.Size(259, 21);
            this.tb_addressToDownload.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Address to fetch";
            // 
            // btn_broswer
            // 
            this.btn_broswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_broswer.Location = new System.Drawing.Point(196, 71);
            this.btn_broswer.Name = "btn_broswer";
            this.btn_broswer.Size = new System.Drawing.Size(75, 23);
            this.btn_broswer.TabIndex = 2;
            this.btn_broswer.Text = "browser";
            this.btn_broswer.UseVisualStyleBackColor = true;
            this.btn_broswer.Click += new System.EventHandler(this.btn_broswer_Click);
            // 
            // tb_saveTo
            // 
            this.tb_saveTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_saveTo.Location = new System.Drawing.Point(12, 73);
            this.tb_saveTo.Name = "tb_saveTo";
            this.tb_saveTo.Size = new System.Drawing.Size(178, 21);
            this.tb_saveTo.TabIndex = 1;
            this.tb_saveTo.Text = "F:/Test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Save To";
            // 
            // lb_logView
            // 
            this.lb_logView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_logView.FormattingEnabled = true;
            this.lb_logView.ItemHeight = 12;
            this.lb_logView.Location = new System.Drawing.Point(12, 129);
            this.lb_logView.Name = "lb_logView";
            this.lb_logView.Size = new System.Drawing.Size(267, 88);
            this.lb_logView.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_logView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_saveTo);
            this.Controls.Add(this.btn_broswer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_addressToDownload);
            this.Controls.Add(this.btn_startDownload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_startDownload;
        private System.Windows.Forms.TextBox tb_addressToDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_broswer;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.TextBox tb_saveTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_logView;
        private System.Windows.Forms.Label label3;
    }
}

