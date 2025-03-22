using Demo_Login.Classes;
using Demo_Login.Forms;
using Google.Cloud.Firestore.V1;

namespace Demo_Login
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            FireStoreHelper.SetEnviromentVariable(); 
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}