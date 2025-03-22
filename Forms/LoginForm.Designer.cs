namespace Demo_Login.Forms
{
    partial class LoginForm
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
            BackToRegisterBtn = new Button();
            UserNameTxt = new TextBox();
            label1 = new Label();
            PasswordTxt = new TextBox();
            label2 = new Label();
            LoginBtn = new Button();
            SuspendLayout();
            // 
            // BackToRegisterBtn
            // 
            BackToRegisterBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BackToRegisterBtn.Location = new Point(208, 241);
            BackToRegisterBtn.Name = "BackToRegisterBtn";
            BackToRegisterBtn.Size = new Size(166, 29);
            BackToRegisterBtn.TabIndex = 0;
            BackToRegisterBtn.Text = " Back to Register";
            BackToRegisterBtn.UseVisualStyleBackColor = true;
            BackToRegisterBtn.Click += button1_Click;
            // 
            // UserNameTxt
            // 
            UserNameTxt.Location = new Point(303, 102);
            UserNameTxt.Name = "UserNameTxt";
            UserNameTxt.Size = new Size(353, 27);
            UserNameTxt.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(208, 105);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 2;
            label1.Text = "Username";
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(303, 156);
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.Size = new Size(353, 27);
            PasswordTxt.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(208, 159);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 2;
            label2.Text = "Password";
            // 
            // LoginBtn
            // 
            LoginBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            LoginBtn.Location = new Point(484, 241);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(172, 29);
            LoginBtn.TabIndex = 0;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Aquamarine;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTxt);
            Controls.Add(UserNameTxt);
            Controls.Add(LoginBtn);
            Controls.Add(BackToRegisterBtn);
            Cursor = Cursors.Hand;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackToRegisterBtn;
        private TextBox UserNameTxt;
        private Label label1;
        private TextBox PasswordTxt;
        private Label label2;
        private Button LoginBtn;
    }
}