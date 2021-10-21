
namespace ChatAppClient
{
    partial class StartWindow
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
            this.connectBt = new System.Windows.Forms.Button();
            this.nameTx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.changeServerLb = new System.Windows.Forms.Label();
            this.serverAddressTx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // connectBt
            // 
            this.connectBt.Location = new System.Drawing.Point(177, 112);
            this.connectBt.Name = "connectBt";
            this.connectBt.Size = new System.Drawing.Size(106, 30);
            this.connectBt.TabIndex = 0;
            this.connectBt.Text = "Connect";
            this.connectBt.UseVisualStyleBackColor = true;
            this.connectBt.Click += new System.EventHandler(this.connectBt_Click);
            // 
            // nameTx
            // 
            this.nameTx.Location = new System.Drawing.Point(108, 79);
            this.nameTx.Name = "nameTx";
            this.nameTx.Size = new System.Drawing.Size(175, 27);
            this.nameTx.TabIndex = 1;
            this.nameTx.Text = "client";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nickname:";
            // 
            // changeServerLb
            // 
            this.changeServerLb.AutoSize = true;
            this.changeServerLb.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.changeServerLb.Location = new System.Drawing.Point(12, 206);
            this.changeServerLb.Name = "changeServerLb";
            this.changeServerLb.Size = new System.Drawing.Size(89, 17);
            this.changeServerLb.TabIndex = 2;
            this.changeServerLb.Text = "Change Server";
            this.changeServerLb.Click += new System.EventHandler(this.changeServerLb_Click);
            // 
            // serverAddressTx
            // 
            this.serverAddressTx.Location = new System.Drawing.Point(177, 202);
            this.serverAddressTx.Name = "serverAddressTx";
            this.serverAddressTx.Size = new System.Drawing.Size(133, 27);
            this.serverAddressTx.TabIndex = 1;
            this.serverAddressTx.Text = "127.0.0.1";
            this.serverAddressTx.Visible = false;
            // 
            // StartWindow
            // 
            this.AcceptButton = this.connectBt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 231);
            this.Controls.Add(this.changeServerLb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverAddressTx);
            this.Controls.Add(this.nameTx);
            this.Controls.Add(this.connectBt);
            this.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartWindow";
            this.Text = "ChatApp - Start";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectBt;
        private System.Windows.Forms.TextBox nameTx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label changeServerLb;
        private System.Windows.Forms.TextBox serverAddressTx;
    }
}

