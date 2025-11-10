using System;
using System.Diagnostics;
using System.Windows.Forms;
using Diet_tracking_weight_tracking.Forms;
using Diet_tracking_weight_tracking.Services;

namespace Diet_tracking_weight_tracking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Initialize simple credential system
                Debug.WriteLine("=== Diet Tracker Starting ===");
                Debug.WriteLine($"Credentials file: {SimpleCredStore.CredFilePath}");

                // Load credentials to ensure file is created and show current state
                var currentCreds = SimpleCredStore.LoadCredentials();
                Debug.WriteLine($"Current credentials: {currentCreds.Username} / {currentCreds.Password}");

                if (currentCreds.Username == "admin" && currentCreds.Password == "admin")
                {
                    Debug.WriteLine("Using default credentials - first run or no custom user registered");
                }
                else
                {
                    Debug.WriteLine($"Custom user registered: {currentCreds.Username}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during credential initialization: {ex.Message}");
                MessageBox.Show(
                    $"Error initializing credentials:\n{ex.Message}\n\nUsing default admin/admin credentials.",
                    "Credential System Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Start with the login form
            Application.Run(new LoginForm());
        }
    }
}
