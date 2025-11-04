using System;
using System.Windows.Forms;

namespace Application_Form
{
    public partial class Form2 : Form
    {
        private static string GetPermanentAddress()
        {
            // Collect permanent address fields from Form1 static variables
            return $"{Form1.village} (Village), {Form1.postoffice} (Post Office), {Form1.policestation} (Police Station), {Form1.district} (District), {Form1.pin} (Pin), {Form1.country} (Country), {Form1.state} (State)";
        }

        private static string GetPermanentAddressAlt()
        {
            // Collect permanent address fields from permanent address controls
            return $"{Form1.village} (Village), {Form1.postoffice} (Post Office), {Form1.policestation} (Police Station), {Form1.district} (District), {Form1.pin} (Pin), {Form1.country} (Country), {Form1.state} (State)";
        }

        public Form2(string[] labels, string[] values)
        {
            InitializeComponent();

            // Build the display text with heading and subheading
            var displayText = "RAMAKRISHNA MISSION VIDYAMANDIRA\r\nAPPLICATION FORM\r\n\r\n";
            // Compose present and permanent address from values and Form1 static fields
            string presentAddress = $"{values[4]} (Village), {values[5]} (Post Office), {values[6]} (Police Station), {values[7]} (District), {values[8]} (Pin), {values[9]} (Country), {values[10]} (State)";
            string permanentAddress = $"{Form1.village} (Village), {Form1.postoffice} (Post Office), {Form1.policestation} (Police Station), {Form1.district} (District), {Form1.pin} (Pin), {Form1.country} (Country), {Form1.state} (State)";
            for (int i = 0; i < labels.Length; i++)
            {
                // For subjects and marks, only show if not empty
                if ((labels[i].StartsWith("Subject") || labels[i].StartsWith("Mark")) && string.IsNullOrWhiteSpace(values[i]))
                    continue;
                // For address, add both present and permanent address
                if (labels[i] == "Village:")
                {
                    displayText += $"Present Address: {presentAddress}\r\n";
                    displayText += $"Permanent Address: {permanentAddress}\r\n";
                    // Skip the next 6 address fields since we already displayed them
                    i = 10;
                    continue;
                }
                displayText += $"{labels[i]} {values[i]}\r\n";
            }
            textBoxDisplay.Text = displayText;
        }

        private void textBoxDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
