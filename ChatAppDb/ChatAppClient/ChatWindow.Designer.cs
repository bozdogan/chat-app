
namespace ChatAppClient
{
    partial class ChatWindow
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
            this.messageTx = new System.Windows.Forms.TextBox();
            this.chatTx = new System.Windows.Forms.RichTextBox();
            this.sendBt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // messageTx
            // 
            this.messageTx.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageTx.Location = new System.Drawing.Point(15, 289);
            this.messageTx.Margin = new System.Windows.Forms.Padding(4);
            this.messageTx.Name = "messageTx";
            this.messageTx.Size = new System.Drawing.Size(474, 27);
            this.messageTx.TabIndex = 0;
            // 
            // chatTx
            // 
            this.chatTx.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chatTx.Location = new System.Drawing.Point(15, 15);
            this.chatTx.Margin = new System.Windows.Forms.Padding(4);
            this.chatTx.Name = "chatTx";
            this.chatTx.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.chatTx.Size = new System.Drawing.Size(576, 266);
            this.chatTx.TabIndex = 1;
            this.chatTx.TabStop = false;
            this.chatTx.Text = "";
            // 
            // sendBt
            // 
            this.sendBt.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sendBt.Location = new System.Drawing.Point(497, 289);
            this.sendBt.Margin = new System.Windows.Forms.Padding(4);
            this.sendBt.Name = "sendBt";
            this.sendBt.Size = new System.Drawing.Size(94, 27);
            this.sendBt.TabIndex = 2;
            this.sendBt.Text = "Send";
            this.sendBt.UseVisualStyleBackColor = true;
            this.sendBt.Click += new System.EventHandler(this.sendBt_Click);
            // 
            // ChatWindow
            // 
            this.AcceptButton = this.sendBt;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 330);
            this.Controls.Add(this.sendBt);
            this.Controls.Add(this.chatTx);
            this.Controls.Add(this.messageTx);
            this.Font = new System.Drawing.Font("Segoe UI", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatWindow";
            this.Text = "ChatApp";
            this.Load += new System.EventHandler(this.ChatWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox messageTx;
        private System.Windows.Forms.RichTextBox chatTx;
        private System.Windows.Forms.Button sendBt;
    }
}

