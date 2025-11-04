namespace project2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            comboBox5 = new ComboBox();
            comboBox6 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            button1 = new Button();
            label9 = new Label();
            label4 = new Label();
            label8 = new Label();
            comboBox7 = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "21-24 inches", "25-27 inches", "28-32 inches" });
            comboBox1.Location = new Point(138, 105);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(117, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 109);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 1;
            label1.Text = "Monitor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 187);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 2;
            label2.Text = "Keyboard";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 259);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 3;
            label3.Text = "Processor";
            // 
            // comboBox2
            // 
            comboBox2.CausesValidation = false;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(290, 105);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(117, 28);
            comboBox2.TabIndex = 5;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Mechanical", "Membrane", "Gaming", "Wireless" });
            comboBox3.Location = new Point(138, 183);
            comboBox3.Margin = new Padding(3, 4, 3, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(117, 28);
            comboBox3.TabIndex = 6;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(291, 183);
            comboBox4.Margin = new Padding(3, 4, 3, 4);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(117, 28);
            comboBox4.TabIndex = 7;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "Intel", "AMD", "Apple" });
            comboBox5.Location = new Point(138, 255);
            comboBox5.Margin = new Padding(3, 4, 3, 4);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(117, 28);
            comboBox5.TabIndex = 8;
            comboBox5.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            // 
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new Point(290, 255);
            comboBox6.Margin = new Padding(3, 4, 3, 4);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new Size(117, 28);
            comboBox6.TabIndex = 9;
            comboBox6.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(431, 116);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(431, 193);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(431, 259);
            label7.Name = "label7";
            label7.Size = new Size(0, 20);
            label7.TabIndex = 14;
            // 
            // button1
            // 
            button1.Location = new Point(334, 401);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(91, 33);
            button1.TabIndex = 16;
            button1.Text = "Total Price";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(431, 407);
            label9.Name = "label9";
            label9.Size = new Size(0, 20);
            label9.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(169, 56);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 18;
            label4.Text = "Type";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(315, 56);
            label8.Name = "label8";
            label8.Size = new Size(48, 20);
            label8.TabIndex = 19;
            label8.Text = "Brand";
            // 
            // comboBox7
            // 
            comboBox7.FormattingEnabled = true;
            comboBox7.Items.AddRange(new object[] { "Razer", "Logitech", "Corsair", "HP" });
            comboBox7.Location = new Point(138, 323);
            comboBox7.Margin = new Padding(3, 4, 3, 4);
            comboBox7.Name = "comboBox7";
            comboBox7.Size = new Size(117, 28);
            comboBox7.TabIndex = 21;
            comboBox7.SelectedIndexChanged += comboBox7_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(40, 327);
            label10.Name = "label10";
            label10.Size = new Size(53, 20);
            label10.TabIndex = 20;
            label10.Text = "Mouse";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(431, 327);
            label11.Name = "label11";
            label11.Size = new Size(0, 20);
            label11.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(431, 56);
            label12.Name = "label12";
            label12.Size = new Size(41, 20);
            label12.TabIndex = 23;
            label12.Text = "Price";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 545);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(comboBox7);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label9);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBox6);
            Controls.Add(comboBox5);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private ComboBox comboBox5;
        private ComboBox comboBox6;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;
        private Label label9;
        private Label label4;
        private Label label8;
        private ComboBox comboBox7;
        private Label label10;
        private Label label11;
        private Label label12;
    }
}
