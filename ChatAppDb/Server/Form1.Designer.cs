
namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startServerBt = new System.Windows.Forms.Button();
            this.stopServerBt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serverStatusLb = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchPanel = new System.Windows.Forms.GroupBox();
            this.databaseStatusLb = new System.Windows.Forms.Label();
            this.byMessageRadio = new System.Windows.Forms.RadioButton();
            this.bySenderRadio = new System.Windows.Forms.RadioButton();
            this.messageSearchFindBt = new System.Windows.Forms.Button();
            this.messagePreviewTx = new System.Windows.Forms.TextBox();
            this.searchQueryTx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nClientActiveLb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // startServerBt
            // 
            this.startServerBt.Location = new System.Drawing.Point(6, 63);
            this.startServerBt.Name = "startServerBt";
            this.startServerBt.Size = new System.Drawing.Size(76, 26);
            this.startServerBt.TabIndex = 0;
            this.startServerBt.Text = "Start";
            this.startServerBt.UseVisualStyleBackColor = true;
            this.startServerBt.Click += new System.EventHandler(this.startServerBt_Click);
            // 
            // stopServerBt
            // 
            this.stopServerBt.Location = new System.Drawing.Point(88, 63);
            this.stopServerBt.Name = "stopServerBt";
            this.stopServerBt.Size = new System.Drawing.Size(75, 26);
            this.stopServerBt.TabIndex = 1;
            this.stopServerBt.Text = "STOP";
            this.stopServerBt.UseVisualStyleBackColor = true;
            this.stopServerBt.Click += new System.EventHandler(this.stopServerBt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status:";
            // 
            // serverStatusLb
            // 
            this.serverStatusLb.AutoSize = true;
            this.serverStatusLb.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.serverStatusLb.Location = new System.Drawing.Point(68, 31);
            this.serverStatusLb.Name = "serverStatusLb";
            this.serverStatusLb.Size = new System.Drawing.Size(61, 17);
            this.serverStatusLb.TabIndex = 3;
            this.serverStatusLb.Text = "NOT SET";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serverStatusLb);
            this.groupBox1.Controls.Add(this.startServerBt);
            this.groupBox1.Controls.Add(this.stopServerBt);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 95);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Control";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.databaseStatusLb);
            this.searchPanel.Controls.Add(this.byMessageRadio);
            this.searchPanel.Controls.Add(this.bySenderRadio);
            this.searchPanel.Controls.Add(this.messageSearchFindBt);
            this.searchPanel.Controls.Add(this.messagePreviewTx);
            this.searchPanel.Controls.Add(this.searchQueryTx);
            this.searchPanel.Controls.Add(this.label2);
            this.searchPanel.Location = new System.Drawing.Point(13, 114);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(429, 303);
            this.searchPanel.TabIndex = 5;
            this.searchPanel.TabStop = false;
            this.searchPanel.Text = "Search in History";
            // 
            // databaseStatusLb
            // 
            this.databaseStatusLb.AutoSize = true;
            this.databaseStatusLb.Location = new System.Drawing.Point(154, 19);
            this.databaseStatusLb.Name = "databaseStatusLb";
            this.databaseStatusLb.Size = new System.Drawing.Size(139, 15);
            this.databaseStatusLb.TabIndex = 5;
            this.databaseStatusLb.Text = "DATABASE STATUS LABEL";
            // 
            // byMessageRadio
            // 
            this.byMessageRadio.AutoSize = true;
            this.byMessageRadio.Location = new System.Drawing.Point(220, 70);
            this.byMessageRadio.Name = "byMessageRadio";
            this.byMessageRadio.Size = new System.Drawing.Size(122, 19);
            this.byMessageRadio.TabIndex = 4;
            this.byMessageRadio.Text = "Search in Message";
            this.byMessageRadio.UseVisualStyleBackColor = true;
            // 
            // bySenderRadio
            // 
            this.bySenderRadio.AutoSize = true;
            this.bySenderRadio.Checked = true;
            this.bySenderRadio.Location = new System.Drawing.Point(99, 70);
            this.bySenderRadio.Name = "bySenderRadio";
            this.bySenderRadio.Size = new System.Drawing.Size(115, 19);
            this.bySenderRadio.TabIndex = 4;
            this.bySenderRadio.TabStop = true;
            this.bySenderRadio.Text = "Search by Sender";
            this.bySenderRadio.UseVisualStyleBackColor = true;
            // 
            // messageSearchFindBt
            // 
            this.messageSearchFindBt.Location = new System.Drawing.Point(337, 40);
            this.messageSearchFindBt.Name = "messageSearchFindBt";
            this.messageSearchFindBt.Size = new System.Drawing.Size(75, 23);
            this.messageSearchFindBt.TabIndex = 3;
            this.messageSearchFindBt.Text = "Find";
            this.messageSearchFindBt.UseVisualStyleBackColor = true;
            this.messageSearchFindBt.Click += new System.EventHandler(this.messageSearchFindBt_Click);
            // 
            // messagePreviewTx
            // 
            this.messagePreviewTx.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messagePreviewTx.Location = new System.Drawing.Point(6, 95);
            this.messagePreviewTx.Multiline = true;
            this.messagePreviewTx.Name = "messagePreviewTx";
            this.messagePreviewTx.ReadOnly = true;
            this.messagePreviewTx.Size = new System.Drawing.Size(417, 202);
            this.messagePreviewTx.TabIndex = 2;
            // 
            // searchQueryTx
            // 
            this.searchQueryTx.Location = new System.Drawing.Point(99, 41);
            this.searchQueryTx.Name = "searchQueryTx";
            this.searchQueryTx.Size = new System.Drawing.Size(232, 23);
            this.searchQueryTx.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search Text:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Number of Client Connected:";
            // 
            // nClientActiveLb
            // 
            this.nClientActiveLb.AutoSize = true;
            this.nClientActiveLb.Location = new System.Drawing.Point(374, 27);
            this.nClientActiveLb.Name = "nClientActiveLb";
            this.nClientActiveLb.Size = new System.Drawing.Size(51, 15);
            this.nClientActiveLb.TabIndex = 7;
            this.nClientActiveLb.Text = "# clients";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 429);
            this.Controls.Add(this.nClientActiveLb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "ChatApp Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startServerBt;
        private System.Windows.Forms.Button stopServerBt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label serverStatusLb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox searchPanel;
        private System.Windows.Forms.RadioButton byMessageRadio;
        private System.Windows.Forms.RadioButton bySenderRadio;
        private System.Windows.Forms.Button messageSearchFindBt;
        private System.Windows.Forms.TextBox messagePreviewTx;
        private System.Windows.Forms.TextBox searchQueryTx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label databaseStatusLb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label nClientActiveLb;
        private System.Windows.Forms.Timer timer1;
    }
}

