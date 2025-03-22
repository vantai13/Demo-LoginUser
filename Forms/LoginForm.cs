using Demo_Login.Classes;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_Login.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
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
            string username = UserNameTxt.Text.Trim();
            string password = PasswordTxt.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or password cannot be empty.");
                return;
            }

            var db = FireStoreHelper.Database;
            if (db == null)
            {
                MessageBox.Show("Database connection failed. Please check Firestore configuration.");
                return;
            }

            DocumentReference docRef = db.Collection("UserData").Document(username);
            var snapshot = await docRef.GetSnapshotAsync(); // Sử dụng await thay vì .Result
            UserData data = snapshot.ConvertTo<UserData>();

            if (data != null)
            {
                if (password == data.Password)
                {
                    MessageBox.Show("Login Success");
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }

    }
}
