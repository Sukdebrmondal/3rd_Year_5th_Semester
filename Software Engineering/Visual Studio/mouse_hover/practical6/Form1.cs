using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practical6
{
    public partial class Form1 : Form

    {   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 10);
            }
            else if (e.KeyChar == 's')
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 10);
            }
            else if (e.KeyChar == 'a')
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X - 10, pictureBox1.Location.Y);
            }
            else if (e.KeyChar == 'd')
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 10, pictureBox1.Location.Y);
            }


            if (pictureBox1.Location.X < 0)
            {
                pictureBox1.Location = new Point(0, pictureBox1.Location.Y);
            }
            else if(pictureBox1.Location.Y < 0)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, 0);
            }
            else if (pictureBox1.Location.X > 940)
            {
                pictureBox1.Location = new Point(940,pictureBox1.Location.Y);
            }
            else if (pictureBox1.Location.Y > 520)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X,520);
            }

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            Random random1 = new Random();
            pictureBox1.Location = new Point(random1.Next(0, 940), random1.Next(0, 520));
        }
    }
}
