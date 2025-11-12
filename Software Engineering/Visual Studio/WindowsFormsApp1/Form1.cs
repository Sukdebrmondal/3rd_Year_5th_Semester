using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Hello World";
        }

        private void btnset_Click(object sender, EventArgs e)
        {
            label1.Text = "Hi i am sukdeb";
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            label1.Text = "Text has benn cancelled..........";
        }
    }
}
