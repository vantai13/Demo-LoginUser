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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var db = FireStoreHelper.Database;
            string username = UserNameTxt.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username cannot be empty.");
                return;
            }

            if (CheckIfUserAlreadyExist())
            {
                MessageBox.Show("User Already Exists");
                return;
            }

            var data = GetWriteData();
            DocumentReference docRef = db.Collection("UserData").Document(data.Username);
            docRef.SetAsync(data);
            MessageBox.Show("Success");
        }

        private void BackToLoginBtn_Click(object sender, EventArgs e)
        {
            Hide(); 
            LoginForm frm = new LoginForm();
            frm.ShowDialog();
            Close();
        }


        private UserData GetWriteData()
        {
           

            string username = UserNameTxt.Text.Trim(); 
            string password = PasswordTxt.Text;
            string gender = GenderCbx.Text;
            string email = EmailTxt.Text.Trim();

            return new UserData()
            {
                Username = username,
                Password = password,
                Gender = gender,
                Email = email

            }; 
        }

      
        private bool CheckIfUserAlreadyExist()
        {
            string username = UserNameTxt.Text.Trim();
            string password = PasswordTxt.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username or password cannot be empty.");
                return false;
            }

            var db = FireStoreHelper.Database;
         
            try
            {
                DocumentReference docRef = db.Collection("UserData").Document(username);
                UserData data = docRef.GetSnapshotAsync().Result.ConvertTo<UserData>();
                if (data != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking user: {ex.Message}");
                return false;
            }
            return false;
        }
    }
}
