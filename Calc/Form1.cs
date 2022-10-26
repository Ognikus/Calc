using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        public string D; // Запоминание кнопки нажатия
        public string N1; // Запоминание первой переменной
        public bool n2; // Запоминание полученного результата в текс бокс
        public double MS; // запоминание переменной в память
        public Form1()
        {
            InitializeComponent();
        }

        private void button28_Click(object sender, EventArgs e) // Кнопки ввода чисел
        {
            if (n2)
            {
                n2 = false;
                textBox1.Text = "0";
            }    
            Button B = (Button)sender;
            if (textBox1.Text == "0")
                textBox1.Text = B.Text;
            else
                textBox1.Text = textBox1.Text + B.Text;
        }

        private void button9_Click(object sender, EventArgs e) // Кнопки стерания
        {
            textBox1.Text = "0";
        }

        private void button26_Click(object sender, EventArgs e) // Запоминание ввода мат. уравнений
        {
            Button B = (Button)sender;
            D = B.Text;
            N1 = textBox1.Text;
            n2 = true; 
        }

        private void button21_Click(object sender, EventArgs e) // выполнения мат. уравнений 
        {
            double dn1, dn2, res;
            res = 0;
            dn1 = Convert.ToDouble(N1);
            dn2 = Convert.ToDouble(textBox1.Text);
            if (D == "+")
            {
                res = dn1 + dn2;
            }
            if (D == "-")
            {
                res = dn1 - dn2;
            }
            if (D == "*")
            {
                res = dn1 * dn2;
            }
            if (D == "/")
            {
                res = dn1 / dn2;
            }
            if (D == "%")
            {
                res = dn1 * dn2 / 100;
            }
            if (D == "//")
            {
                res = dn1 % dn2;
            }
            D = "=";
            n2 = true;
            textBox1.Text = res.ToString();

        }

        private void button6_Click(object sender, EventArgs e) // Нахождение корня
        {
            double dn, res;
            
            dn = Convert.ToDouble(textBox1.Text);
            res = Math.Sqrt(dn);
            textBox1.Text = res.ToString();
        }

        private void button16_Click(object sender, EventArgs e) // Выполнение 1/x
        {
            double dn, res;

            dn = Convert.ToDouble(textBox1.Text);
            res = 1 / dn;
            textBox1.Text = res.ToString();
        }

        private void button7_Click(object sender, EventArgs e) // Выполнение +-
        {
            double dn, res;

            dn = Convert.ToDouble(textBox1.Text);
            res = -dn;
            textBox1.Text = res.ToString();
        }

        private void button27_Click(object sender, EventArgs e) // проверка на ввод для ,
        {
            if(!textBox1.Text.Contains(","))
                textBox1.Text = textBox1.Text + ",";
        }

        private void button10_Click(object sender, EventArgs e) // Кнопка стирания числа
        {
            textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void конвекторСкоростиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(620, 380);
        }

        private void обычныйКалькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Size = new Size(250, 380);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            double result, speed;
            var stt = textBox2.Text;
            if (Double.TryParse(stt, out var res))
            {
                double v = Convert.ToDouble(textBox2.Text);
                speed = v;
                result = 1.852 * speed;
                textBox3.Text = result.ToString();
                errorProvider1.SetError(textBox2, null);
            }
            else
            {
                errorProvider1.SetError(textBox2, "Необходимо ввести цифры!");
            }

        }

        private void button30_Click(object sender, EventArgs e)
        {
            double result, speed;
            var stt = textBox5.Text;
            if (Double.TryParse(stt, out var res))
            {
                double v = Convert.ToDouble(textBox5.Text);
                speed = v;
                result = 0.54 * speed;
                textBox4.Text = result.ToString();
                errorProvider1.SetError(textBox5, null);
            }
            else
            {
                errorProvider1.SetError(textBox5, "Необходимо ввести цифры!");
            }
        }
        //Сохранение в память
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            double s;
            if (textBox1.Text.Length != 0)
            {
                s = Convert.ToDouble(textBox1.Text);
                MS = s;
            }
              
        }
        //Вызов из памяти
        private void button2_Click(object sender, EventArgs e)
        {
            string res;
            res = Convert.ToString(MS);
            textBox1.Text = res;
                
                
        }
        //Очистка памяти
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            MS = 0;
        }
        //Прибавить к памяти
        private void button4_Click(object sender, EventArgs e)
        {
            double s;
            s = Convert.ToDouble(textBox1.Text);
            MS = MS + s;

        }
        //Вычти из памяти
        private void button5_Click(object sender, EventArgs e)
        {
            double s;
            s = Convert.ToDouble(textBox1.Text);
            MS = MS - s;
        }
    }
}
