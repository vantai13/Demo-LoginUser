using Demo_Login.Classes;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Demo_Login.Forms
{
    public partial class LoginForm : Form
    {
        private readonly FirebaseAuthHelper _authHelper;

        public LoginForm()
        {
            InitializeComponent();
            _authHelper = new FirebaseAuthHelper();
            FireStoreHelper.SetEnviromentVariable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            RegisterForm form = new RegisterForm();
            form.ShowDialog();
            Close();
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text.Trim();
            string password = PasswordTxt.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email or password cannot be empty.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address (e.g., example@domain.com).");
                return;
            }

            try
            {
                var signInResponse = await _authHelper.SignInWithEmailPassword(email, password);
                string idToken = signInResponse.IdToken ?? throw new InvalidOperationException("IdToken is null");

                bool isEmailVerified = await _authHelper.IsEmailVerified(idToken);
                if (!isEmailVerified)
                {
                    MessageBox.Show("Please verify your email before logging in.");
                    return;
                }

                MessageBox.Show("Login Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị thông báo lỗi cụ thể
            }
        }

        private async void ForgotPasswordBtn_Click(object sender, EventArgs e)
        {
            string email = EmailTxt.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email to reset password.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address (e.g., example@domain.com).");
                return;
            }

            try
            {
                await _authHelper.SendPasswordResetEmail(email);
                MessageBox.Show("A password reset email has been sent. Please check your inbox.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị thông báo lỗi cụ thể
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

       
    }
}