namespace Demo_Login.Forms
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
            UserNameTxt = new TextBox();
            label1 = new Label();
            BackToLoginBtn = new Button();
            PasswordTxt = new TextBox();
            label2 = new Label();
            EmailTxt = new TextBox();
            label3 = new Label();
            label4 = new Label();
            RegisterBtn = new Button();
            GenderCbx = new ComboBox();
            SuspendLayout();
            // 
            // UserNameTxt
            // 
            UserNameTxt.Location = new Point(268, 59);
            UserNameTxt.Name = "UserNameTxt";
            UserNameTxt.Size = new Size(289, 27);
            UserNameTxt.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(185, 62);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "UserName";
            // 
            // BackToLoginBtn
            // 
            BackToLoginBtn.Location = new Point(185, 304);
            BackToLoginBtn.Name = "BackToLoginBtn";
            BackToLoginBtn.Size = new Size(173, 29);
            BackToLoginBtn.TabIndex = 2;
            BackToLoginBtn.Text = "Back to login";
            BackToLoginBtn.UseVisualStyleBackColor = true;
            BackToLoginBtn.Click += BackToLoginBtn_Click;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(268, 110);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PasswordChar = '*';
            PasswordTxt.Size = new Size(289, 27);
            PasswordTxt.TabIndex = 0;
            PasswordTxt.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AccessibleRole = AccessibleRole.TitleBar;
            label2.AutoSize = true;
            label2.Location = new Point(185, 113);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // EmailTxt
            // 
            EmailTxt.Location = new Point(268, 216);
            EmailTxt.Name = "EmailTxt";
            EmailTxt.Size = new Size(289, 27);
            EmailTxt.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(185, 168);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 1;
            label3.Text = "Gender";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(185, 219);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 1;
            label4.Text = "Email";
            // 
            // RegisterBtn
            // 
            RegisterBtn.Location = new Point(421, 304);
            RegisterBtn.Name = "RegisterBtn";
            RegisterBtn.Size = new Size(136, 29);
            RegisterBtn.TabIndex = 2;
            RegisterBtn.Text = "Register";
            RegisterBtn.UseVisualStyleBackColor = true;
            RegisterBtn.Click += button2_Click;
            // 
            // GenderCbx
            // 
            GenderCbx.DropDownStyle = ComboBoxStyle.DropDownList;
            GenderCbx.FormattingEnabled = true;
            GenderCbx.Items.AddRange(new object[] { "Male", "Female" });
            GenderCbx.Location = new Point(268, 160);
            GenderCbx.Name = "GenderCbx";
            GenderCbx.Size = new Size(289, 28);
            GenderCbx.TabIndex = 3;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GenderCbx);
            Controls.Add(RegisterBtn);
            Controls.Add(BackToLoginBtn);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(EmailTxt);
            Controls.Add(PasswordTxt);
            Controls.Add(UserNameTxt);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox UserNameTxt;
        private Label label1;
        private Button BackToLoginBtn;
        private TextBox PasswordTxt;
        private Label label2;
        private TextBox EmailTxt;
        private Label label3;
        private Label label4;
        private Button RegisterBtn;
        private ComboBox GenderCbx;
    }
}