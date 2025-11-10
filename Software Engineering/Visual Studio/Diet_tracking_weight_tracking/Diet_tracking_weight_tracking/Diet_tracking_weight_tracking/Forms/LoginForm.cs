using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diet_tracking_weight_tracking.Models;
using Diet_tracking_weight_tracking.Services;
using Diet_tracking_weight_tracking.Testing;

namespace Diet_tracking_weight_tracking.Forms
{
    /// <summary>
    /// Login form for user authentication with simple credential storage
    /// </summary>
    public partial class LoginForm : Form
    {
      public LoginForm()
     {
  InitializeComponent();
    
        // Set initial focus
txtUsername.Focus();
   
   // Add debug test button in development builds
   #if DEBUG
   AddDebugElements();
   #endif
 }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
      try
     {
     btnLogin.Enabled = false;
   btnLogin.Text = "Logging in...";
   
      string username = txtUsername.Text?.Trim() ?? string.Empty;
    string password = txtPassword.Text ?? string.Empty;
   
       Debug.WriteLine($"Login attempt for username: {username}");

 if (string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password))
     {
   MessageBox.Show("Please enter both username and password.", "Validation Error", 
        MessageBoxButtons.OK, MessageBoxIcon.Warning);
    return;
    }

          // Authenticate using simple credential store
            bool isAuthenticated = SimpleCredStore.AuthenticateUser(username, password);

            if (isAuthenticated)
{
       Debug.WriteLine($"Login successful for user: {username}");
    
      // Create a simple user object for the session
      var user = new User
    {
       Id = 1, // Simple user ID since we only support one user
Username = username,
Email = $"{username}@diettracker.local" // Dummy email
      };

 // Check if user has a profile
       var profileService = new ProfileService();
     var profile = await profileService.GetProfileAsync(user.Id);
 
         if (profile == null)
         {
         Debug.WriteLine($"User {username} has no profile, redirecting to profile setup");
             
    // Show profile setup form if no profile exists
           var profileSetupForm = new ProfileSetupForm(user);
   this.Hide();
         
     if (profileSetupForm.ShowDialog() == DialogResult.OK)
             {
        // Profile setup completed, go to dashboard
 var dashboardForm = new DashboardForm(user);
    dashboardForm.ShowDialog();
             }
         }
       else
         {
 Debug.WriteLine($"User {username} has profile, opening dashboard directly");
             
    // Go directly to dashboard if profile exists
             var dashboardForm = new DashboardForm(user);
  this.Hide();
         dashboardForm.ShowDialog();
    }
  
      this.Close();
 }
 else
  {
    Debug.WriteLine($"Login failed for username: {username}");
       
     // Show generic error message for security
       MessageBox.Show("Invalid username or password. Please try again.", 
   "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
       
       // Clear password field and focus username
    txtPassword.Clear();
     txtUsername.Focus();
     txtUsername.SelectAll();
      }
      }
  catch (Exception ex)
     {
     Debug.WriteLine($"Unexpected login error: {ex.Message}");
     MessageBox.Show($"An error occurred during login:\n{ex.Message}\n\nPlease try again.", 
     "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
   }
     finally
 {
    btnLogin.Enabled = true;
 btnLogin.Text = "Login";
        }
 }

  private void btnRegister_Click(object sender, EventArgs e)
     {
   var registerForm = new RegisterForm();
        this.Hide();
  registerForm.ShowDialog();
   this.Close();
      }

    private void txtPassword_KeyDown(object sender, KeyEventArgs e)
     {
    if (e.KeyCode == Keys.Enter)
    {
     e.SuppressKeyPress = true;
   btnLogin_Click(sender, e);
   }
}

     private void txtUsername_KeyDown(object sender, KeyEventArgs e)
   {
     if (e.KeyCode == Keys.Enter)
     {
      e.SuppressKeyPress = true;
  txtPassword.Focus();
        }
   }

  private void LoginForm_Load(object sender, EventArgs e)
        {
      // Set window position and basic properties
     this.StartPosition = FormStartPosition.CenterScreen;
    
        // Add some helpful debug information in development
    Debug.WriteLine("=== Login Form Loaded ===");
         Debug.WriteLine($"Credentials file path: {SimpleCredStore.CredFilePath}");
      Debug.WriteLine($"Current stored username: {SimpleCredStore.GetCurrentUsername()}");
   }

      private void lblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
   {
        MessageBox.Show("Password recovery is not available in this simple credential system.\n\nYou can register a new account to overwrite the current credentials.", 
      "Password Recovery", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
     #if DEBUG
   private void AddDebugElements()
     {
        // Add debug credentials info label
     var lblDebug = new Label
     {
     Text = $"Creds: {SimpleCredStore.CredFilePath}\nCurrent user: {SimpleCredStore.GetCurrentUsername()}",
      AutoSize = true,
     Location = new Point(10, this.Height - 70),
     ForeColor = Color.Gray,
    Font = new Font("Arial", 8),
 Anchor = AnchorStyles.Bottom | AnchorStyles.Left
    };
      this.Controls.Add(lblDebug);

        // Add test button for authentication testing
     var btnTest = new Button
     {
     Text = "Test Creds",
      Size = new Size(100, 25),
     Location = new Point(this.Width - 120, this.Height - 70),
     Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
    BackColor = Color.LightBlue,
    UseVisualStyleBackColor = false
      };
    
 btnTest.Click += (s, e) => {
      var creds = SimpleCredStore.LoadCredentials();
       MessageBox.Show($"Stored Credentials:\nUsername: {creds.Username}\nPassword: {creds.Password}\nFile: {SimpleCredStore.CredFilePath}",
         "Debug - Stored Credentials", MessageBoxButtons.OK, MessageBoxIcon.Information);
    };
      
     this.Controls.Add(btnTest);

        // Add button to reset to admin/admin
     var btnReset = new Button
         {
   Text = "Reset to Admin",
      Size = new Size(100, 25),
     Location = new Point(this.Width - 120, this.Height - 100),
     Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
    BackColor = Color.LightCoral,
       UseVisualStyleBackColor = false
      };
    
 btnReset.Click += (s, e) => {
   if (MessageBox.Show("Reset credentials to admin/admin?", "Confirm Reset", 
    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
         SimpleCredStore.SaveCredentials(new SimpleCredentials { Username = "admin", Password = "admin" });
     MessageBox.Show("Credentials reset to admin/admin", "Reset Complete");
      }
    };
  
     this.Controls.Add(btnReset);
    }
   #endif
    }
}