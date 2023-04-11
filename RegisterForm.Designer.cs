namespace LottoWForms
{
    partial class RegisterForm
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
            this.loginGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.registerBtn = new System.Windows.Forms.Button();
            this.passLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passInput = new System.Windows.Forms.TextBox();
            this.loginInput = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.loginGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginGroupBox
            // 
            this.loginGroupBox.Controls.Add(this.label1);
            this.loginGroupBox.Controls.Add(this.textBox1);
            this.loginGroupBox.Controls.Add(this.registerBtn);
            this.loginGroupBox.Controls.Add(this.passLabel);
            this.loginGroupBox.Controls.Add(this.loginLabel);
            this.loginGroupBox.Controls.Add(this.passInput);
            this.loginGroupBox.Controls.Add(this.loginInput);
            this.loginGroupBox.Location = new System.Drawing.Point(12, 12);
            this.loginGroupBox.Name = "loginGroupBox";
            this.loginGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.loginGroupBox.Size = new System.Drawing.Size(210, 196);
            this.loginGroupBox.TabIndex = 2;
            this.loginGroupBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Repeat password";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 23);
            this.textBox1.TabIndex = 6;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(6, 158);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(198, 23);
            this.registerBtn.TabIndex = 5;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = true;
            // 
            // passLabel
            // 
            this.passLabel.AutoSize = true;
            this.passLabel.Location = new System.Drawing.Point(6, 65);
            this.passLabel.Name = "passLabel";
            this.passLabel.Size = new System.Drawing.Size(57, 15);
            this.passLabel.TabIndex = 3;
            this.passLabel.Text = "Password";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(6, 21);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(37, 15);
            this.loginLabel.TabIndex = 2;
            this.loginLabel.Text = "Login";
            // 
            // passInput
            // 
            this.passInput.Location = new System.Drawing.Point(6, 83);
            this.passInput.Name = "passInput";
            this.passInput.Size = new System.Drawing.Size(198, 23);
            this.passInput.TabIndex = 1;
            this.passInput.UseSystemPasswordChar = true;
            // 
            // loginInput
            // 
            this.loginInput.Location = new System.Drawing.Point(6, 39);
            this.loginInput.Name = "loginInput";
            this.loginInput.Size = new System.Drawing.Size(198, 23);
            this.loginInput.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(172, 211);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(50, 15);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Go back";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 241);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.loginGroupBox);
            this.Name = "RegisterForm";
            this.Text = "Lotto - Register";
            this.loginGroupBox.ResumeLayout(false);
            this.loginGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox loginGroupBox;
        private System.Windows.Forms.Label passLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox passInput;
        private System.Windows.Forms.TextBox loginInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}