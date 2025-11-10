using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Diet_tracking_weight_tracking.Services;

namespace Diet_tracking_weight_tracking.Testing
{
    /// <summary>
    /// Simple test form to verify credential system functionality
    /// </summary>
 public partial class CredentialTestForm : Form
    {
      private TextBox txtUsername;
  private TextBox txtPassword;
  private Button btnSave;
    private Button btnLoad;
        private Button btnTest;
        private Button btnReset;
       private Label lblResult;
   private Label lblFilePath;

        public CredentialTestForm()
        {
         InitializeComponent();
   }

  private void InitializeComponent()
       {
     this.Size = new Size(500, 400);
       this.Text = "Credential System Test";
 this.StartPosition = FormStartPosition.CenterScreen;

   // Username input
   var lblUsername = new Label
     {
       Text = "Username:",
   Location = new Point(20, 20),
         Size = new Size(100, 23)
  };
      this.Controls.Add(lblUsername);

            txtUsername = new TextBox
  {
 Location = new Point(130, 20),
       Size = new Size(200, 23)
     };
   this.Controls.Add(txtUsername);

   // Password input
  var lblPassword = new Label
     {
       Text = "Password:",
   Location = new Point(20, 60),
  Size = new Size(100, 23)
  };
  this.Controls.Add(lblPassword);

    txtPassword = new TextBox
 {
 Location = new Point(130, 60),
 Size = new Size(200, 23)
 };
   this.Controls.Add(txtPassword);

  // Buttons
       btnSave = new Button
       {
        Text = "Save Credentials",
     Location = new Point(20, 100),
     Size = new Size(120, 30)
  };
      btnSave.Click += BtnSave_Click;
       this.Controls.Add(btnSave);

    btnLoad = new Button
 {
        Text = "Load Credentials",
     Location = new Point(150, 100),
       Size = new Size(120, 30)
  };
      btnLoad.Click += BtnLoad_Click;
this.Controls.Add(btnLoad);

    btnTest = new Button
       {
        Text = "Test Login",
     Location = new Point(280, 100),
    Size = new Size(120, 30)
  };
      btnTest.Click += BtnTest_Click;
       this.Controls.Add(btnTest);

   btnReset = new Button
       {
        Text = "Reset to Admin",
     Location = new Point(20, 140),
 Size = new Size(120, 30)
  };
      btnReset.Click += BtnReset_Click;
     this.Controls.Add(btnReset);

   // Result display
    lblResult = new Label
   {
            Text = "Ready to test...",
 Location = new Point(20, 180),
  Size = new Size(450, 100),
      BorderStyle = BorderStyle.FixedSingle,
  BackColor = Color.LightYellow
     };
    this.Controls.Add(lblResult);

     // File path display
     lblFilePath = new Label
  {
       Text = $"Credential file: {SimpleCredStore.CredFilePath}",
  Location = new Point(20, 290),
            Size = new Size(450, 40),
      ForeColor = Color.Gray,
   Font = new Font("Arial", 8)
     };
   this.Controls.Add(lblFilePath);

  // Load current credentials on startup
       BtnLoad_Click(null, null);
     }

 private void BtnSave_Click(object sender, EventArgs e)
        {
     try
     {
  var username = txtUsername.Text?.Trim();
    var password = txtPassword.Text ?? string.Empty;

 if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
  {
       lblResult.Text = "ERROR: Username and password cannot be empty";
      lblResult.BackColor = Color.LightCoral;
        return;
     }

    bool success = SimpleCredStore.RegisterUser(username, password);
   if (success)
  {
       lblResult.Text = $"SUCCESS: Saved credentials for '{username}'";
     lblResult.BackColor = Color.LightGreen;
 }
     else
 {
       lblResult.Text = "ERROR: Failed to save credentials";
       lblResult.BackColor = Color.LightCoral;
        }
        }
      catch (Exception ex)
      {
       lblResult.Text = $"ERROR: {ex.Message}";
         lblResult.BackColor = Color.LightCoral;
        }
     }

 private void BtnLoad_Click(object sender, EventArgs e)
        {
        try
  {
       var creds = SimpleCredStore.LoadCredentials();
     if (creds != null)
  {
     txtUsername.Text = creds.Username;
     txtPassword.Text = creds.Password;
       lblResult.Text = $"LOADED: Username='{creds.Username}', Password='{creds.Password}'";
         lblResult.BackColor = Color.LightBlue;
 }
     else
   {
       lblResult.Text = "ERROR: Failed to load credentials";
     lblResult.BackColor = Color.LightCoral;
        }
       }
  catch (Exception ex)
      {
     lblResult.Text = $"ERROR: {ex.Message}";
   lblResult.BackColor = Color.LightCoral;
        }
 }

  private void BtnTest_Click(object sender, EventArgs e)
        {
  try
     {
     var username = txtUsername.Text?.Trim();
    var password = txtPassword.Text ?? string.Empty;

       bool isValid = SimpleCredStore.AuthenticateUser(username, password);
      if (isValid)
  {
       lblResult.Text = $"SUCCESS: Authentication passed for '{username}'";
         lblResult.BackColor = Color.LightGreen;
 }
     else
   {
   lblResult.Text = $"FAILED: Authentication failed for '{username}'";
         lblResult.BackColor = Color.LightCoral;
        }
            }
    catch (Exception ex)
      {
     lblResult.Text = $"ERROR: {ex.Message}";
         lblResult.BackColor = Color.LightCoral;
   }
   }

 private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
             SimpleCredStore.SaveCredentials(new SimpleCredentials { Username = "admin", Password = "admin" });
  lblResult.Text = "SUCCESS: Reset to admin/admin";
         lblResult.BackColor = Color.LightGreen;
       BtnLoad_Click(null, null); // Reload to show admin credentials
 }
      catch (Exception ex)
      {
       lblResult.Text = $"ERROR: {ex.Message}";
         lblResult.BackColor = Color.LightCoral;
     }
     }
    }
}