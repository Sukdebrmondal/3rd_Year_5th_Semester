namespace Diet_tracking_weight_tracking.Forms
{
    partial class RegisterForm
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
     this.pnlMain = new System.Windows.Forms.Panel();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
       this.btnRegister = new System.Windows.Forms.Button();
    this.dtpDob = new System.Windows.Forms.DateTimePicker();
      this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
          this.txtEmail = new System.Windows.Forms.TextBox();
  this.txtPhone = new System.Windows.Forms.TextBox();
   this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
 this.lblDob = new System.Windows.Forms.Label();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
     this.lblPassword = new System.Windows.Forms.Label();
      this.lblEmail = new System.Windows.Forms.Label();
         this.lblPhone = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
          // 
    // pnlMain
            // 
     this.pnlMain.BackColor = System.Drawing.Color.White;
         this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
  this.pnlMain.Controls.Add(this.lnkLogin);
       this.pnlMain.Controls.Add(this.btnRegister);
            this.pnlMain.Controls.Add(this.dtpDob);
        this.pnlMain.Controls.Add(this.txtConfirmPassword);
   this.pnlMain.Controls.Add(this.txtPassword);
 this.pnlMain.Controls.Add(this.txtEmail);
            this.pnlMain.Controls.Add(this.txtPhone);
       this.pnlMain.Controls.Add(this.txtUsername);
   this.pnlMain.Controls.Add(this.txtName);
      this.pnlMain.Controls.Add(this.lblDob);
   this.pnlMain.Controls.Add(this.lblConfirmPassword);
        this.pnlMain.Controls.Add(this.lblPassword);
   this.pnlMain.Controls.Add(this.lblEmail);
     this.pnlMain.Controls.Add(this.lblPhone);
     this.pnlMain.Controls.Add(this.lblUsername);
    this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Controls.Add(this.lblTitle);
     this.pnlMain.Location = new System.Drawing.Point(30, 30);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 500);
            this.pnlMain.TabIndex = 0;
    // 
      // lnkLogin
            // 
     this.lnkLogin.AutoSize = true;
this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
     this.lnkLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
 this.lnkLogin.Location = new System.Drawing.Point(130, 460);
   this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(140, 15);
 this.lnkLogin.TabIndex = 9;
          this.lnkLogin.TabStop = true;
    this.lnkLogin.Text = "Already have an account?";
  this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
     // btnRegister
      // 
 this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
   this.btnRegister.FlatAppearance.BorderSize = 0;
   this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
    this.btnRegister.ForeColor = System.Drawing.Color.White;
    this.btnRegister.Location = new System.Drawing.Point(50, 410);
      this.btnRegister.Name = "btnRegister";
    this.btnRegister.Size = new System.Drawing.Size(300, 40);
  this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Register";
       this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
       // 
            // dtpDob
        // 
  this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 10F);
    this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(50, 370);
          this.dtpDob.MaxDate = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
 this.dtpDob.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
       this.dtpDob.Name = "dtpDob";
this.dtpDob.Size = new System.Drawing.Size(300, 25);
            this.dtpDob.TabIndex = 7;
 this.dtpDob.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
     // txtConfirmPassword
// 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(50, 320);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
       this.txtConfirmPassword.Size = new System.Drawing.Size(300, 25);
            this.txtConfirmPassword.TabIndex = 6;
      // 
            // txtPassword
    // 
      this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
  this.txtPassword.Location = new System.Drawing.Point(50, 270);
            this.txtPassword.Name = "txtPassword";
  this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(300, 25);
     this.txtPassword.TabIndex = 5;
            // 
        // txtEmail
   // 
       this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(50, 220);
            this.txtEmail.Name = "txtEmail";
       this.txtEmail.Size = new System.Drawing.Size(300, 25);
      this.txtEmail.TabIndex = 4;
     // 
    // txtPhone
            // 
 this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.txtPhone.Location = new System.Drawing.Point(50, 170);
     this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(300, 25);
            this.txtPhone.TabIndex = 3;
      // 
       // txtUsername
  // 
      this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
    this.txtUsername.Location = new System.Drawing.Point(50, 120);
            this.txtUsername.Name = "txtUsername";
     this.txtUsername.Size = new System.Drawing.Size(300, 25);
          this.txtUsername.TabIndex = 2;
        // 
        // txtName
// 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
       this.txtName.Location = new System.Drawing.Point(50, 70);
            this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(300, 25);
         this.txtName.TabIndex = 1;
            // 
      // lblDob
     // 
            this.lblDob.AutoSize = true;
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblDob.Location = new System.Drawing.Point(50, 350);
            this.lblDob.Name = "lblDob";
      this.lblDob.Size = new System.Drawing.Size(76, 15);
      this.lblDob.TabIndex = 8;
    this.lblDob.Text = "Date of Birth:";
  // 
         // lblConfirmPassword
            // 
      this.lblConfirmPassword.AutoSize = true;
   this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
  this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
          this.lblConfirmPassword.Location = new System.Drawing.Point(50, 300);
        this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(107, 15);
      this.lblConfirmPassword.TabIndex = 7;
    this.lblConfirmPassword.Text = "Confirm Password:";
            // 
    // lblPassword
            // 
     this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
          this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
this.lblPassword.Location = new System.Drawing.Point(50, 250);
          this.lblPassword.Name = "lblPassword";
 this.lblPassword.Size = new System.Drawing.Size(60, 15);
      this.lblPassword.TabIndex = 6;
      this.lblPassword.Text = "Password:";
            // 
            // lblEmail
            // 
    this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
     this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblEmail.Location = new System.Drawing.Point(50, 200);
       this.lblEmail.Name = "lblEmail";
     this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 5;
          this.lblEmail.Text = "Email:";
          // 
         // lblPhone
            // 
this.lblPhone.AutoSize = true;
      this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
   this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.lblPhone.Location = new System.Drawing.Point(50, 150);
       this.lblPhone.Name = "lblPhone";
 this.lblPhone.Size = new System.Drawing.Size(91, 15);
         this.lblPhone.TabIndex = 4;
        this.lblPhone.Text = "Phone Number:";
   // 
       // lblUsername
// 
    this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
  this.lblUsername.Location = new System.Drawing.Point(50, 100);
         this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(63, 15);
    this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username:";
      // 
         // lblName
   // 
          this.lblName.AutoSize = true;
          this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
        this.lblName.Location = new System.Drawing.Point(50, 50);
      this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(64, 15);
       this.lblName.TabIndex = 2;
     this.lblName.Text = "Full Name:";
        // 
         // lblTitle
       // 
      this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
  this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
    this.lblTitle.Location = new System.Drawing.Point(140, 10);
      this.lblTitle.Name = "lblTitle";
    this.lblTitle.Size = new System.Drawing.Size(120, 32);
      this.lblTitle.TabIndex = 1;
          this.lblTitle.Text = "Register";
// 
         // RegisterForm
      // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
  this.ClientSize = new System.Drawing.Size(460, 560);
         this.Controls.Add(this.pnlMain);
       this.Font = new System.Drawing.Font("Segoe UI", 9F);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
     this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diet Tracker - Register";
 this.pnlMain.ResumeLayout(false);
  this.pnlMain.PerformLayout();
  this.ResumeLayout(false);

        }

        #endregion

      private System.Windows.Forms.Panel pnlMain;
   private System.Windows.Forms.LinkLabel lnkLogin;
   private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.DateTimePicker dtpDob;
     private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Label lblPassword;
 private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
  private System.Windows.Forms.Label lblUsername;
   private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.Label lblTitle;
 }
}