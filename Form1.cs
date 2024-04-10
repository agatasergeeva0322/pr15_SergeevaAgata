using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prackt18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            pictureBox1.Image = Image.FromFile("cat.jfif");
        }

        private void button1_Click(object sender, EventArgs e)
        {

                double a = Convert.ToDouble(numericUpDown1.Text);
                double b = Convert.ToDouble(numericUpDown2.Text);
                double c = Convert.ToDouble(numericUpDown3.Text);
                double d = Convert.ToDouble(numericUpDown4.Text);
                if (comboBox1.SelectedIndex == 0) label9.Text = Convert.ToString(ComplexNumber.Add(a, b, c, d));
                else if (comboBox1.SelectedIndex == 1) label9.Text = Convert.ToString(ComplexNumber.Subtract(a, b, c, d));
                else label9.Text = Convert.ToString(ComplexNumber.Multiply(a, b, c, d));
        }
    }
}
