using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Raceing_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Ensure the road segments are positioned seamlessly
            pictureBox1.Left = 0;
            pictureBox2.Left = pictureBox1.Right;
            pictureBox3.Left = pictureBox2.Right;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            roadTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            roadTimer.Stop();
        }

        private void roadTimer_Tick(object sender, EventArgs e)
        {
            int moveSpeed = 5;
            // Move all road segments to the left
            pictureBox1.Left -= moveSpeed;
            pictureBox2.Left -= moveSpeed;
            pictureBox3.Left -= moveSpeed;

            // If a pictureBox moves out of the left edge, reposition it to the right of the rightmost box
            PictureBox[] roads = { pictureBox1, pictureBox2, pictureBox3 };
            foreach (var pb in roads)
            {
                if (pb.Right < 0)
                {
                    // Find the rightmost PictureBox
                    var rightmost = roads.OrderByDescending(r => r.Right).First();
                    pb.Left = rightmost.Right;
                }
            }
        }
    }
}
