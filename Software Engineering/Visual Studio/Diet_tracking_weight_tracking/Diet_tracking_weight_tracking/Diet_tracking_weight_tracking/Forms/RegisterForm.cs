using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diet_tracking_weight_tracking.DTOs;
using Diet_tracking_weight_tracking.Models;
using Diet_tracking_weight_tracking.Services;

namespace Diet_tracking_weight_tracking.Forms
{
    /// <summary>
    /// Registration form for new user accounts with simple credential storage
    /// </summary>
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            
            // Add debug label for development
         #if DEBUG
             AddDebugCredentialsLabel();
           #endif
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
 {
          btnRegister.Enabled = false;
     btnRegister.Text = "Creating account...";
            
        Debug.WriteLine($"Registration attempt for username: {txtUsername.Text}");

                // Get input values
       var username = txtUsername.Text?.Trim();
 var password = txtPassword.Text ?? string.Empty;
     var confirmPassword = txtConfirmPassword.Text ?? string.Empty;

       // Validate inputs
          if (!ValidateInputs(username, password, confirmPassword))
      return;

   // Register user using simple credential store
   bool success = SimpleCredStore.RegisterUser(username, password);

       if (success)
         {
        Debug.WriteLine($"Registration successful for user: {username}");
    MessageBox.Show(
     "Registration complete! Please set up your profile to get started.", 
         "Registration Successful", 
      MessageBoxButtons.OK, 
   MessageBoxIcon.Information);

      // Create a simple user object for profile setup
         var user = new User
         {
             Id = 1, // Simple user ID since we only support one user
             Username = username,
 Email = $"{username}@diettracker.local" // Dummy email
         };

       // Open profile setup form after successful registration
         var profileSetupForm = new ProfileSetupForm(user);
         this.Hide();
         
     if (profileSetupForm.ShowDialog() == DialogResult.OK)
         {
           // Profile setup completed, go to dashboard
       var dashboardForm = new DashboardForm(user);
             dashboardForm.ShowDialog();
         }
         
         this.Close();
   }
     else
       {
        Debug.WriteLine("Registration failed: SimpleCredStore.RegisterUser returned false");
     MessageBox.Show("Registration failed. Please try again.", 
         "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
   }
 catch (Exception ex)
      {
    Debug.WriteLine($"Unexpected registration error: {ex.Message}");
           MessageBox.Show($"An error occurred during registration:\n{ex.Message}", 
        "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
     finally
     {
     btnRegister.Enabled = true;
     btnRegister.Text = "Register";
            }
        }

  private bool ValidateInputs(string username, string password, string confirmPassword)
    {
       if (string.IsNullOrWhiteSpace(username))
     {
 MessageBox.Show("Please enter a username.", "Validation Error", 
      MessageBoxButtons.OK, MessageBoxIcon.Warning);
 txtUsername.Focus();
    return false;
  }

      if (username.Length < 3)
        {
      MessageBox.Show("Username must be at least 3 characters long.", "Validation Error", 
   MessageBoxButtons.OK, MessageBoxIcon.Warning);
    txtUsername.Focus();
  return false;
      }

     if (string.IsNullOrEmpty(password))
     {
          MessageBox.Show("Please enter a password.", "Validation Error", 
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
   txtPassword.Focus();
        return false;
   }

     if (password.Length < 3)
   {
       MessageBox.Show("Password must be at least 3 characters long.", "Validation Error", 
     MessageBoxButtons.OK, MessageBoxIcon.Warning);
 txtPassword.Focus();
        return false;
        }

        if (password != confirmPassword)
   {
 MessageBox.Show("Passwords do not match.", "Validation Error", 
    MessageBoxButtons.OK, MessageBoxIcon.Warning);
      txtConfirmPassword.Focus();
      return false;
 }

        return true;
      }

        private void btnCancel_Click(object sender, EventArgs e)
        {
  this.Close();
    }

  private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
     {
var loginForm = new LoginForm();
      this.Hide();
        loginForm.ShowDialog();
   this.Close();
}

        #if DEBUG
   private void AddDebugCredentialsLabel()
        {
       var lblDebug = new Label
            {
    Text = $"Creds file: {SimpleCredStore.CredFilePath}",
  AutoSize = true,
 Location = new System.Drawing.Point(10, this.Height - 50),
           ForeColor = System.Drawing.Color.Gray,
   Font = new System.Drawing.Font("Arial", 8),
 Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
  
            this.Controls.Add(lblDebug);
    }
        #endif
    }
}