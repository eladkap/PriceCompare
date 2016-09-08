namespace FinalLab.Forms
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
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_register = new System.Windows.Forms.Button();
            this.txt_retypePassword = new System.Windows.Forms.TextBox();
            this.lbl_retypePassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(237, 108);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(146, 20);
            this.txt_password.TabIndex = 1;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(237, 58);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(146, 20);
            this.txt_username.TabIndex = 0;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_password.Location = new System.Drawing.Point(113, 108);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(69, 17);
            this.lbl_password.TabIndex = 7;
            this.lbl_password.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(113, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Username";
            // 
            // btn_register
            // 
            this.btn_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btn_register.Location = new System.Drawing.Point(237, 214);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(88, 29);
            this.btn_register.TabIndex = 3;
            this.btn_register.Text = "Register";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // txt_retypePassword
            // 
            this.txt_retypePassword.Location = new System.Drawing.Point(237, 155);
            this.txt_retypePassword.Name = "txt_retypePassword";
            this.txt_retypePassword.PasswordChar = '*';
            this.txt_retypePassword.Size = new System.Drawing.Size(146, 20);
            this.txt_retypePassword.TabIndex = 2;
            // 
            // lbl_retypePassword
            // 
            this.lbl_retypePassword.AutoSize = true;
            this.lbl_retypePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_retypePassword.Location = new System.Drawing.Point(113, 155);
            this.lbl_retypePassword.Name = "lbl_retypePassword";
            this.lbl_retypePassword.Size = new System.Drawing.Size(118, 17);
            this.lbl_retypePassword.TabIndex = 7;
            this.lbl_retypePassword.Text = "Retype Password";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 301);
            this.Controls.Add(this.txt_retypePassword);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.lbl_retypePassword);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_register);
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.TextBox txt_retypePassword;
        private System.Windows.Forms.Label lbl_retypePassword;
    }
}