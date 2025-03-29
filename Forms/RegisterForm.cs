using Demo_Login.Classes;
using Google.Cloud.Firestore;
using System;
using System.Windows.Forms;

namespace Demo_Login.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly FirebaseAuthHelper _authHelper;

        public RegisterForm()
        {
            InitializeComponent();
            _authHelper = new FirebaseAuthHelper();
            FireStoreHelper.SetEnviromentVariable();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            string username = UserNameTxt.Text.Trim();
            string email = EmailTxt.Text.Trim();
            string password = PasswordTxt.Text;
            string gender = GenderCbx.Text;

            // Kiểm tra các trường không được để trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            // Kiểm tra độ dài mật khẩu
            if (password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            // Kiểm tra kết nối Firestore
            var db = FireStoreHelper.Database;
            if (db == null)
            {
                MessageBox.Show("Database connection failed.");
                return;
            }

            // Kiểm tra username đã tồn tại
            if (await CheckIfUserAlreadyExist(username))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            try
            {
                // Đăng ký người dùng qua Firebase Authentication
                var signUpResponse = await _authHelper.SignUpWithEmailPassword(email, password);
                string idToken = signUpResponse.IdToken ?? throw new InvalidOperationException("IdToken is null");

                // Gửi email xác minh
                await _authHelper.SendEmailVerification(idToken);

                // Lưu thông tin vào Firestore
                var data = new UserData
                {
                    Username = username,
                    Email = email,
                    Gender = gender
                };
                DocumentReference docRef = db.Collection("UserData").Document(username);
                await docRef.SetAsync(data);

                MessageBox.Show("Registration successful! Please check your email to verify your account.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Hiển thị thông báo lỗi cụ thể từ FirebaseAuthHelper
            }
        }

        private void BackToLoginBtn_Click(object sender, EventArgs e)
        {
            Hide();
            new LoginForm().ShowDialog();
            Close();
        }

        private async Task<bool> CheckIfUserAlreadyExist(string username)
        {
            var db = FireStoreHelper.Database;
            try
            {
                DocumentReference docRef = db.Collection("UserData").Document(username);
                var snapshot = await docRef.GetSnapshotAsync();
                return snapshot.Exists;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking user: {ex.Message}");
                return false;
            }
        }
    }
}