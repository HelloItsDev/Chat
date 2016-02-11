namespace ClientForm
{
    partial class chatForm
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
            this.sendButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(640, 406);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(127, 47);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(30, 406);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(595, 47);
            this.messageTextBox.TabIndex = 1;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(30, 57);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(737, 326);
            this.textBox.TabIndex = 2;
            // 
            // chatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 477);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.sendButton);
            this.Name = "chatForm";
            this.Load += new System.EventHandler(this.chatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public void recevoir_message(string msg)
        {
            textBox.Text += msg;
        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox textBox;
    }
}