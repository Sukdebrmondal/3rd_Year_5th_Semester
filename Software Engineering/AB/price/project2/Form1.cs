using System.Drawing;

namespace project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int m_size = 0;
        int m_brand = 0;
        int k_type = 0;
        int k_brand = 0;
        int p_brand = 0;
        int p_type = 0;
        int ms_brand = 0;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                m_size = 1000;
                //label10.Text = m_size.ToString();
                comboBox2.Text = "";
                //label11.Text = "";
                label5.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Acer");
                comboBox2.Items.Add("Asus");
                comboBox2.Items.Add("Dell");
            }
            if (comboBox1.SelectedIndex == 1)
            {
                m_size = 2000;
                //label10.Text = m_size.ToString();
                comboBox2.Text = "";
                //label11.Text = "";
                label5.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Items.Add("LG");
                comboBox2.Items.Add("Dell");
                comboBox2.Items.Add("Samsung");
            }
            if (comboBox1.SelectedIndex == 2)
            {
                m_size = 3000;
                //label10.Text = m_size.ToString();
                comboBox2.Text = "";
                //label11.Text = "";
                label5.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Samsung");
                comboBox2.Items.Add("Asus");
                comboBox2.Items.Add("LG");
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Acer")
            {
                m_brand = 4000;
                //label11.Text = m_brand.ToString();
                label5.Text = (m_size + m_brand).ToString();
            }
            if (comboBox2.Text == "Asus")
            {
                m_brand = 5000;
                //label11.Text = m_brand.ToString();
                label5.Text = (m_size + m_brand).ToString();
            }
            if (comboBox2.Text == "Dell")
            {
                m_brand = 6000;
                //label11.Text = m_brand.ToString();
                label5.Text = (m_size + m_brand).ToString();
            }
            if (comboBox2.Text == "LG")
            {
                m_brand = 7000;
                //label11.Text = m_brand.ToString();
                label5.Text = (m_size + m_brand).ToString();
            }
            if (comboBox2.Text == "Samsung")
            {
                m_brand = 8000;
                //label11.Text = m_brand.ToString();
                label5.Text = (m_size + m_brand).ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0)
            {
                k_type = 100;
                //label12.Text = k_type.ToString();
                comboBox4.Text = "";
                //label13.Text = "";
                label6.Text = "";
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Logitech");
                comboBox4.Items.Add("Razer");
                comboBox4.Items.Add("Corsair");
            }
            if (comboBox3.SelectedIndex == 1)
            {
                k_type = 200;
                //label12.Text = k_type.ToString();
                comboBox4.Text = "";
                //label13.Text = "";
                label6.Text = "";
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Razer");
                comboBox4.Items.Add("Corsair");
                comboBox4.Items.Add("Matias");
            }
            if (comboBox3.SelectedIndex == 2)
            {
                k_type = 300;
                //label12.Text = k_type.ToString();
                comboBox4.Text = "";
                //label13.Text = "";
                label6.Text = "";
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Corsair");
                comboBox4.Items.Add("Matias");
                comboBox4.Items.Add("LG");
            }
            if (comboBox3.SelectedIndex == 3)
            {
                k_type = 400;
                //label12.Text = k_type.ToString();
                comboBox4.Text = "";
                //label13.Text = "";
                label6.Text = "";
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Matias");
                comboBox4.Items.Add("Asus");
                comboBox4.Items.Add("Dell");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Logitech")
            {
                k_brand = 400;
                //label13.Text = k_brand.ToString();
                label6.Text = (k_type + k_brand).ToString();
            }
            if (comboBox4.Text == "Razer")
            {
                k_brand = 500;
                //label13.Text = k_brand.ToString();
                label6.Text = (k_type + k_brand).ToString();
            }
            if (comboBox4.Text == "Corsair")
            {
                k_brand = 600;
                //label13.Text = k_brand.ToString();
                label6.Text = (k_type + k_brand).ToString();
            }
            if (comboBox4.Text == "Matias")
            {
                k_brand = 700;
                //label13.Text = k_brand.ToString();
                label6.Text = (k_type + k_brand).ToString();
            }
            if (comboBox4.Text == "LG")
            {
                k_brand = 800;
                //label13.Text = k_brand.ToString();
                label6.Text = (k_type + k_brand).ToString();
            }
            if (comboBox4.Text == "Asus")
            {
                k_brand = 900;
                //label13.Text = k_brand.ToString();
                label6.Text = (k_type + k_brand).ToString();
            }
            if (comboBox4.Text == "Dell")
            {
                k_brand = 1000;
                //label13.Text = k_brand.ToString();
                label6.Text = (k_type + k_brand).ToString();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 0)
            {
                p_brand = 20000;
                //label14.Text = p_brand.ToString();
                comboBox6.Text = "";
                //label15.Text = "";
                label7.Text = "";
                comboBox6.Items.Clear();
                comboBox6.Items.Add("i5-12600KF");
                comboBox6.Items.Add("i7-14700F");
                comboBox6.Items.Add("i9-12900KF");
                comboBox6.Items.Add("i3-12100");
            }
            if (comboBox5.SelectedIndex == 1)
            {
                p_brand = 30000;
                //label14.Text = p_brand.ToString();
                comboBox6.Text = "";
                //label15.Text = "";
                label7.Text = "";
                comboBox6.Items.Clear();
                comboBox6.Items.Add("Ryzen 7 8700F");
                comboBox6.Items.Add("Ryzen 5 9600X");
                comboBox6.Items.Add("Ryzen 5 5500GT");
            }
            if (comboBox5.SelectedIndex == 2)
            {
                p_brand = 40000;
                //label14.Text = p_brand.ToString();
                comboBox6.Text = "";
                //label15.Text = "";
                label7.Text = "";
                comboBox6.Items.Clear();
                comboBox6.Items.Add("M4 Chip");
                comboBox6.Items.Add("M4 Pro");
                comboBox6.Items.Add("M4 Max");
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.Text == "i5-12600KF")
            {
                p_type = 17999;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "i7-14700F")
            {
                p_type = 32000;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "i9-12900KF")
            {
                p_type = 29000;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "i3-12100")
            {
                p_type = 25000;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "Ryzen 7 8700F")
            {
                p_type = 23000;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "Ryzen 5 9600X")
            {
                p_type = 25000;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "Ryzen 5 5500GT")
            {
                p_type = 2900;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "M4 Chip")
            {
                p_type = 100000;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "M4 Pro")
            {
                p_type = 105000;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
            if (comboBox6.Text == "M4 Max")
            {
                p_type = 107000;
                //label15.Text = p_type.ToString();
                label7.Text = (p_brand + p_type).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label9.Text = (m_size + m_brand + k_type + k_brand + p_brand + p_type + ms_brand).ToString();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == 0)
            {
                ms_brand = 1000;
                label11.Text = ms_brand.ToString();
            }
            if (comboBox7.SelectedIndex == 1)
            {
                ms_brand = 2000;
                label11.Text = ms_brand.ToString();
            }
            if (comboBox7.SelectedIndex == 2)
            {
                ms_brand = 3000;
                label11.Text = ms_brand.ToString();
            }
            if (comboBox7.SelectedIndex == 3)
            {
                ms_brand = 4000;
                label11.Text = ms_brand.ToString();
            }

        }
    }
}
