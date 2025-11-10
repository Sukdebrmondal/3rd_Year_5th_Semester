namespace Diet_tracking_weight_tracking.Forms
{
    partial class ProfileSetupForm
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
        this.btnProfileSubmit = new System.Windows.Forms.Button();
  this.nudWaterTarget = new System.Windows.Forms.NumericUpDown();
   this.lblWaterTarget = new System.Windows.Forms.Label();
   this.nudTargetWeight = new System.Windows.Forms.NumericUpDown();
    this.chkTargetWeight = new System.Windows.Forms.CheckBox();
         this.lblTargetWeight = new System.Windows.Forms.Label();
  this.cmbHealthGoal = new System.Windows.Forms.ComboBox();
 this.lblHealthGoal = new System.Windows.Forms.Label();
       this.cmbActivity = new System.Windows.Forms.ComboBox();
      this.lblActivity = new System.Windows.Forms.Label();
       this.nudWeight = new System.Windows.Forms.NumericUpDown();
   this.lblWeight = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
    this.lblHeight = new System.Windows.Forms.Label();
   this.cmbGender = new System.Windows.Forms.ComboBox();
    this.lblGender = new System.Windows.Forms.Label();
  this.dtpDob = new System.Windows.Forms.DateTimePicker();
   this.lblDob = new System.Windows.Forms.Label();
    this.txtPhone = new System.Windows.Forms.TextBox();
      this.lblPhone = new System.Windows.Forms.Label();
    this.txtNameProfile = new System.Windows.Forms.TextBox();
            this.lblNameProfile = new System.Windows.Forms.Label();
  this.lblTitle = new System.Windows.Forms.Label();
this.pnlMain.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.nudWaterTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTargetWeight)).BeginInit();
   ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
     this.SuspendLayout();
     // 
     // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
      this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
       this.pnlMain.Controls.Add(this.btnProfileSubmit);
  this.pnlMain.Controls.Add(this.nudWaterTarget);
       this.pnlMain.Controls.Add(this.lblWaterTarget);
 this.pnlMain.Controls.Add(this.nudTargetWeight);
  this.pnlMain.Controls.Add(this.chkTargetWeight);
 this.pnlMain.Controls.Add(this.lblTargetWeight);
     this.pnlMain.Controls.Add(this.cmbHealthGoal);
     this.pnlMain.Controls.Add(this.lblHealthGoal);
       this.pnlMain.Controls.Add(this.cmbActivity);
   this.pnlMain.Controls.Add(this.lblActivity);
      this.pnlMain.Controls.Add(this.nudWeight);
 this.pnlMain.Controls.Add(this.lblWeight);
            this.pnlMain.Controls.Add(this.nudHeight);
     this.pnlMain.Controls.Add(this.lblHeight);
        this.pnlMain.Controls.Add(this.cmbGender);
     this.pnlMain.Controls.Add(this.lblGender);
  this.pnlMain.Controls.Add(this.dtpDob);
  this.pnlMain.Controls.Add(this.lblDob);
      this.pnlMain.Controls.Add(this.txtPhone);
    this.pnlMain.Controls.Add(this.lblPhone);
        this.pnlMain.Controls.Add(this.txtNameProfile);
    this.pnlMain.Controls.Add(this.lblNameProfile);
   this.pnlMain.Controls.Add(this.lblTitle);
        this.pnlMain.Location = new System.Drawing.Point(30, 20);
       this.pnlMain.Name = "pnlMain";
     this.pnlMain.Size = new System.Drawing.Size(500, 650);
 this.pnlMain.TabIndex = 0;
     // 
   // btnProfileSubmit
  // 
  this.btnProfileSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
       this.btnProfileSubmit.FlatAppearance.BorderSize = 0;
        this.btnProfileSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
  this.btnProfileSubmit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
    this.btnProfileSubmit.ForeColor = System.Drawing.Color.White;
this.btnProfileSubmit.Location = new System.Drawing.Point(150, 590);
     this.btnProfileSubmit.Name = "btnProfileSubmit";
      this.btnProfileSubmit.Size = new System.Drawing.Size(200, 40);
     this.btnProfileSubmit.TabIndex = 11;
       this.btnProfileSubmit.Text = "Save Profile";
 this.btnProfileSubmit.UseVisualStyleBackColor = false;
            this.btnProfileSubmit.Click += new System.EventHandler(this.btnProfileSubmit_Click);
      // 
        // nudWaterTarget
        // 
    this.nudWaterTarget.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudWaterTarget.Increment = new decimal(new int[] {
      100,
 0,
   0,
       0});
       this.nudWaterTarget.Location = new System.Drawing.Point(280, 540);
  this.nudWaterTarget.Maximum = new decimal(new int[] {
   5000,
      0,
  0,
         0});
     this.nudWaterTarget.Minimum = new decimal(new int[] {
          1000,
   0,
   0,
      0});
   this.nudWaterTarget.Name = "nudWaterTarget";
 this.nudWaterTarget.Size = new System.Drawing.Size(150, 25);
     this.nudWaterTarget.TabIndex = 10;
   this.nudWaterTarget.Value = new decimal(new int[] {
  2000,
       0,
 0,
      0});
    // 
    // lblWaterTarget
     // 
     this.lblWaterTarget.AutoSize = true;
     this.lblWaterTarget.Font = new System.Drawing.Font("Segoe UI", 10F);
          this.lblWaterTarget.Location = new System.Drawing.Point(50, 540);
        this.lblWaterTarget.Name = "lblWaterTarget";
      this.lblWaterTarget.Size = new System.Drawing.Size(123, 19);
        this.lblWaterTarget.TabIndex = 21;
         this.lblWaterTarget.Text = "Water Target (ml):";
 // 
     // nudTargetWeight
    // 
          this.nudTargetWeight.DecimalPlaces = 1;
       this.nudTargetWeight.Enabled = false;
this.nudTargetWeight.Font = new System.Drawing.Font("Segoe UI", 10F);
this.nudTargetWeight.Location = new System.Drawing.Point(280, 490);
            this.nudTargetWeight.Maximum = new decimal(new int[] {
            500,
       0,
   0,
            0});
 this.nudTargetWeight.Minimum = new decimal(new int[] {
     20,
      0,
  0,
      0});
     this.nudTargetWeight.Name = "nudTargetWeight";
    this.nudTargetWeight.Size = new System.Drawing.Size(150, 25);
        this.nudTargetWeight.TabIndex = 9;
        this.nudTargetWeight.Value = new decimal(new int[] {
       70,
      0,
     0,
            0});
            // 
      // chkTargetWeight
   // 
     this.chkTargetWeight.AutoSize = true;
     this.chkTargetWeight.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.chkTargetWeight.Location = new System.Drawing.Point(50, 490);
        this.chkTargetWeight.Name = "chkTargetWeight";
     this.chkTargetWeight.Size = new System.Drawing.Size(108, 19);
    this.chkTargetWeight.TabIndex = 8;
  this.chkTargetWeight.Text = "Set target weight";
     this.chkTargetWeight.UseVisualStyleBackColor = true;
          this.chkTargetWeight.CheckedChanged += new System.EventHandler(this.chkTargetWeight_CheckedChanged);
  // 
        // lblTargetWeight
         // 
 this.lblTargetWeight.AutoSize = true;
    this.lblTargetWeight.Enabled = false;
       this.lblTargetWeight.Font = new System.Drawing.Font("Segoe UI", 10F);
       this.lblTargetWeight.Location = new System.Drawing.Point(280, 470);
     this.lblTargetWeight.Name = "lblTargetWeight";
      this.lblTargetWeight.Size = new System.Drawing.Size(125, 19);
   this.lblTargetWeight.TabIndex = 18;
     this.lblTargetWeight.Text = "Target Weight (kg):";
   // 
        // cmbHealthGoal
            // 
  this.cmbHealthGoal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
  this.cmbHealthGoal.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cmbHealthGoal.FormattingEnabled = true;
        this.cmbHealthGoal.Location = new System.Drawing.Point(280, 420);
 this.cmbHealthGoal.Name = "cmbHealthGoal";
this.cmbHealthGoal.Size = new System.Drawing.Size(150, 25);
   this.cmbHealthGoal.TabIndex = 7;
     this.cmbHealthGoal.SelectedIndexChanged += new System.EventHandler(this.cmbHealthGoal_SelectedIndexChanged);
            // 
        // lblHealthGoal
            // 
      this.lblHealthGoal.AutoSize = true;
       this.lblHealthGoal.Font = new System.Drawing.Font("Segoe UI", 10F);
  this.lblHealthGoal.Location = new System.Drawing.Point(50, 420);
 this.lblHealthGoal.Name = "lblHealthGoal";
   this.lblHealthGoal.Size = new System.Drawing.Size(86, 19);
        this.lblHealthGoal.TabIndex = 16;
     this.lblHealthGoal.Text = "Health Goal:";
     // 
        // cmbActivity
   // 
  this.cmbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActivity.Font = new System.Drawing.Font("Segoe UI", 10F);
   this.cmbActivity.FormattingEnabled = true;
        this.cmbActivity.Location = new System.Drawing.Point(50, 370);
  this.cmbActivity.Name = "cmbActivity";
   this.cmbActivity.Size = new System.Drawing.Size(380, 25);
       this.cmbActivity.TabIndex = 6;
        // 
   // lblActivity
      // 
      this.lblActivity.AutoSize = true;
      this.lblActivity.Font = new System.Drawing.Font("Segoe UI", 10F);
  this.lblActivity.Location = new System.Drawing.Point(50, 350);
      this.lblActivity.Name = "lblActivity";
            this.lblActivity.Size = new System.Drawing.Size(95, 19);
    this.lblActivity.TabIndex = 14;
    this.lblActivity.Text = "Activity Level:";
       // 
         // nudWeight
 // 
       this.nudWeight.DecimalPlaces = 1;
       this.nudWeight.Font = new System.Drawing.Font("Segoe UI", 10F);
   this.nudWeight.Location = new System.Drawing.Point(280, 300);
      this.nudWeight.Maximum = new decimal(new int[] {
     500,
  0,
       0,
  0});
  this.nudWeight.Minimum = new decimal(new int[] {
         20,
            0,
       0,
   0});
       this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(150, 25);
       this.nudWeight.TabIndex = 5;
   this.nudWeight.Value = new decimal(new int[] {
        70,
    0,
      0,
    0});
        // 
      // lblWeight
     // 
        this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 10F);
       this.lblWeight.Location = new System.Drawing.Point(50, 300);
     this.lblWeight.Name = "lblWeight";
         this.lblWeight.Size = new System.Drawing.Size(80, 19);
       this.lblWeight.TabIndex = 12;
     this.lblWeight.Text = "Weight (kg):";
            // 
      // nudHeight
            // 
  this.nudHeight.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.nudHeight.Location = new System.Drawing.Point(280, 250);
        this.nudHeight.Maximum = new decimal(new int[] {
      250,
      0,
      0,
      0});
         this.nudHeight.Minimum = new decimal(new int[] {
       50,
            0,
     0,
       0});
        this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(150, 25);
      this.nudHeight.TabIndex = 4;
 this.nudHeight.Value = new decimal(new int[] {
    170,
            0,
    0,
  0});
       // 
     // lblHeight
            // 
         this.lblHeight.AutoSize = true;
        this.lblHeight.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.lblHeight.Location = new System.Drawing.Point(50, 250);
   this.lblHeight.Name = "lblHeight";
     this.lblHeight.Size = new System.Drawing.Size(82, 19);
 this.lblHeight.TabIndex = 10;
         this.lblHeight.Text = "Height (cm):";
        // 
     // cmbGender
    // 
   this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
  this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
 this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(280, 200);
 this.cmbGender.Name = "cmbGender";
     this.cmbGender.Size = new System.Drawing.Size(150, 25);
 this.cmbGender.TabIndex = 3;
    // 
     // lblGender
// 
  this.lblGender.AutoSize = true;
      this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
  this.lblGender.Location = new System.Drawing.Point(50, 200);
        this.lblGender.Name = "lblGender";
        this.lblGender.Size = new System.Drawing.Size(59, 19);
    this.lblGender.TabIndex = 8;
     this.lblGender.Text = "Gender:";
 // 
            // dtpDob
            // 
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(280, 150);
      this.dtpDob.MaxDate = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);
      this.dtpDob.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
         this.dtpDob.Name = "dtpDob";
          this.dtpDob.Size = new System.Drawing.Size(150, 25);
        this.dtpDob.TabIndex = 2;
     this.dtpDob.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
        // 
        // lblDob
          // 
   this.lblDob.AutoSize = true;
 this.lblDob.Font = new System.Drawing.Font("Segoe UI", 10F);
     this.lblDob.Location = new System.Drawing.Point(50, 150);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(91, 19);
     this.lblDob.TabIndex = 6;
 this.lblDob.Text = "Date of Birth:";
    // 
  // txtPhone
  // 
      this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
  this.txtPhone.Location = new System.Drawing.Point(280, 100);
    this.txtPhone.Name = "txtPhone";
     this.txtPhone.Size = new System.Drawing.Size(150, 25);
 this.txtPhone.TabIndex = 1;
      // 
      // lblPhone
        // 
  this.lblPhone.AutoSize = true;
       this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
     this.lblPhone.Location = new System.Drawing.Point(50, 100);
    this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(108, 19);
     this.lblPhone.TabIndex = 4;
  this.lblPhone.Text = "Phone Number:";
        // 
  // txtNameProfile
      // 
      this.txtNameProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
    this.txtNameProfile.Location = new System.Drawing.Point(280, 50);
     this.txtNameProfile.Name = "txtNameProfile";
  this.txtNameProfile.Size = new System.Drawing.Size(150, 25);
   this.txtNameProfile.TabIndex = 0;
      // 
   // lblNameProfile
         // 
        this.lblNameProfile.AutoSize = true;
 this.lblNameProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblNameProfile.Location = new System.Drawing.Point(50, 50);
  this.lblNameProfile.Name = "lblNameProfile";
       this.lblNameProfile.Size = new System.Drawing.Size(75, 19);
            this.lblNameProfile.TabIndex = 2;
      this.lblNameProfile.Text = "Full Name:";
    // 
       // lblTitle
        // 
  this.lblTitle.AutoSize = true;
 this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
  this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
this.lblTitle.Location = new System.Drawing.Point(150, 10);
      this.lblTitle.Name = "lblTitle";
    this.lblTitle.Size = new System.Drawing.Size(200, 30);
this.lblTitle.TabIndex = 0;
  this.lblTitle.Text = "Complete Your Profile";
          // 
    // ProfileSetupForm
   // 
     this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
     this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(560, 690);
       this.Controls.Add(this.pnlMain);
     this.Font = new System.Drawing.Font("Segoe UI", 9F);
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
       this.MaximizeBox = false;
        this.MinimizeBox = false;
     this.Name = "ProfileSetupForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
     this.Text = "Diet Tracker - Profile Setup";
        this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
       ((System.ComponentModel.ISupportInitialize)(this.nudWaterTarget)).EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.nudTargetWeight)).EndInit();
     ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
   ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
       this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
     private System.Windows.Forms.Button btnProfileSubmit;
   private System.Windows.Forms.NumericUpDown nudWaterTarget;
     private System.Windows.Forms.Label lblWaterTarget;
     private System.Windows.Forms.NumericUpDown nudTargetWeight;
        private System.Windows.Forms.CheckBox chkTargetWeight;
   private System.Windows.Forms.Label lblTargetWeight;
        private System.Windows.Forms.ComboBox cmbHealthGoal;
 private System.Windows.Forms.Label lblHealthGoal;
   private System.Windows.Forms.ComboBox cmbActivity;
        private System.Windows.Forms.Label lblActivity;
        private System.Windows.Forms.NumericUpDown nudWeight;
   private System.Windows.Forms.Label lblWeight;
   private System.Windows.Forms.NumericUpDown nudHeight;
  private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.ComboBox cmbGender;
  private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.DateTimePicker dtpDob;
     private System.Windows.Forms.Label lblDob;
      private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtNameProfile;
     private System.Windows.Forms.Label lblNameProfile;
        private System.Windows.Forms.Label lblTitle;
    }
}