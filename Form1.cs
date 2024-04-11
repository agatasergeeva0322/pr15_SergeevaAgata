using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string[] complexnumb = File.ReadAllLines("complexnumb.txt");
            if (complexnumb.Length < 2 || complexnumb.Length > 2)
            {
                groupBox1_ComplexNumbers.Visible = true;
            }
            else
            {
                label10.Visible = true;
                label10.Text = $"Z1 = {complexnumb[0]}\nZ2 = {complexnumb[1]}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a=0, b=0, c=0, d=0;
            string[] complexnumb = File.ReadAllLines("complexnumb.txt");
            if (complexnumb.Length < 2 || complexnumb.Length > 2)
            {
                a = Convert.ToInt32(numericUpDown1.Text);
                b = Convert.ToInt32(numericUpDown2.Text);
                c = Convert.ToInt32(numericUpDown3.Text);
                d = Convert.ToInt32(numericUpDown4.Text);
            }
            else 
            {
                if (int.TryParse(complexnumb[0], out a)) a = Convert.ToInt32(complexnumb[0]);
                else if (complexnumb[0].Contains("i"))
                {
                    if (complexnumb[0].Contains("-") || complexnumb[0].Contains("+"))
                    {
                        ComplexNumbFromFile(complexnumb[0], out a, out b);
                        b = -b;
                    }
                    else ComplexNumbFromFile(complexnumb[0], out a, out b);
                }
                if (int.TryParse(complexnumb[1], out c)) c = Convert.ToInt32(complexnumb[1]);
                else if (complexnumb[1].Contains("i"))
                {
                    if (complexnumb[1].Contains("-") || complexnumb[1].Contains("+"))
                    {
                        ComplexNumbFromFile(complexnumb[1], out c, out d);
                        d = -d;
                    }
                    else ComplexNumbFromFile(complexnumb[1], out c, out d);
                }
            }
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    label9.Text = Convert.ToString(ComplexNumber.Add(a, b, c, d));  
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    label9.Text = Convert.ToString(ComplexNumber.Subtract(a, b, c, d));
                }
                else
                {
                    label9.Text = Convert.ToString(ComplexNumber.Multiply(a, b, c, d));    
                }
                writer.WriteLine($"{label9.Text}");
            }
        }
        public void ComplexNumbFromFile(string stroka, out int a, out int b)
        {
            a = 0;
            b = 0;
            int ind = stroka.IndexOf("-");
            if (ind == -1) ind = stroka.IndexOf("+");
            if (ind == -1)
            {
                a = 0;
                string cn = "";
                for (int i = 0; i < stroka.Length-1; i++)
                {
                    cn += stroka[i];
                }
                b = Convert.ToInt32(cn);
            }
            else if (ind == 0)
            {
                a = 0;
                string cn = "";
                for (int i = 1; i < stroka.Length-1; i++)
                {
                    cn += stroka[i];
                }
                b = Convert.ToInt32(cn);
            }
            else
            {
                string cn = "";
                for (int i = 0; i < ind; i++)
                {
                    cn += stroka[i];
                }
                a = Convert.ToInt32(cn);
                cn = "";
                for (int i = ind + 1; i < stroka.Length-1; i++)
                {
                    cn += stroka[i];
                }
                b = Convert.ToInt32(cn);
            }
        }
    }
}
