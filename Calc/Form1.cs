using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string deystvie;
        float chislo1;
        float chislo2;
        float enterToTablo;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8)      //Если символ, введенный с клавы - не цифра (IsDigit),
            {
                e.Handled = true;                                // то событие не обрабатывается. ch!=8 (8 - это Backspace)
            }
        }

        private void btn_dt_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.Text += "0,";
                }
                else
                {
                    textBox1.Text += ",";
                    textBox1.Focus();
                    textBox1.SelectionStart = textBox1.Text.Length;
                }
            }
            else 
            {
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            
        }

        private void btn_pls_Click(object sender, EventArgs e)
        {
            deystvie = "+";

            if (textBox1.Text != "")
            {
                chislo1 = (float)Convert.ToDouble(textBox1.Text);
            }
            else
            { 
                chislo1 = 0;
            }
           
            textBox1.Text = "";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_mns_Click(object sender, EventArgs e)
        {
            deystvie = "-";

            if (textBox1.Text != "")
            {
                chislo1 = (float)Convert.ToDouble(textBox1.Text);
            }
            else
            {
                chislo1 = 0;
            }

            textBox1.Text = "";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_umn_Click(object sender, EventArgs e)
        {
            deystvie = "*";

            if (textBox1.Text != "")
            {
                chislo1 = (float)Convert.ToDouble(textBox1.Text);
            }
            else
            {
                chislo1 = 0;
            }

            textBox1.Text = "";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            deystvie = "/";

            if (textBox1.Text != "")
            {
                chislo1 = (float)Convert.ToDouble(textBox1.Text);
            }
            else
            {
                chislo1 = 0;
            }

            textBox1.Text = "";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_pow_Click(object sender, EventArgs e)
        {
            deystvie = "pow";

            if (textBox1.Text != "")
            {
                chislo1 = (float)Convert.ToDouble(textBox1.Text);
            }
            else
            {
                chislo1 = 0;
            }

            textBox1.Text = "";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_sqrt_Click(object sender, EventArgs e)
        {
            textBox1.Text = Math.Sqrt((float)Convert.ToDouble(textBox1.Text)).ToString();
        }

        private void btn_rav_Click(object sender, EventArgs e)
        {
            chislo2 = (float)Convert.ToDouble(textBox1.Text);
            textBox1.Text = "";           
            funk_result();
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        void funk_result()
        {
            switch (deystvie)
            {
                case "+": {
                    enterToTablo = chislo1 + chislo2;
                    textBox1.Text = enterToTablo.ToString();

                    writeToFile(chislo1, chislo2, enterToTablo, "+");

                    break; }

                case "-":
                    {
                        enterToTablo = chislo1 - chislo2;
                        textBox1.Text = enterToTablo.ToString();

                        writeToFile(chislo1, chislo2, enterToTablo, "-");

                        break;
                    }

                case "*":
                    {
                        enterToTablo = chislo1 * chislo2;
                        textBox1.Text = enterToTablo.ToString();

                        writeToFile(chislo1, chislo2, enterToTablo, "-");

                        break;
                    }

                case "/":
                    {
                        if (chislo2 == 0)
                        {
                            MessageBox.Show("Делить на ноль нельзя!", "Ошибка");
                            StreamWriter sw = File.AppendText("History.txt");
                            sw.WriteLine(chislo1 + " / " + chislo2 + " = Error." + Environment.NewLine);
                            sw.Close();
                        }
                        else
                        {
                            enterToTablo = chislo1 / chislo2;
                            writeToFile(chislo1, chislo2, enterToTablo, "/");
                        }
                        textBox1.Text = enterToTablo.ToString();                   

                        break;
                    }

                case "pow":
                    {
                        enterToTablo = (float)Math.Pow(chislo1, chislo2);
                        textBox1.Text = enterToTablo.ToString();

                        StreamWriter sw = File.AppendText("History.txt");
                        sw.WriteLine(chislo1 + " ^ " + chislo2 + " = " + enterToTablo + Environment.NewLine);
                        sw.Close();

                        break;
                    }
            }
        }

        void writeToFile(float c1, float c2, float re, string d)
        {
            StreamWriter sw = File.AppendText("History.txt");
            sw.WriteLine(c1 + " " + d + " " + c2 + " = " + re + Environment.NewLine);
            sw.Close();
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            enterToTablo = 0;
            chislo1 = 0;
            chislo2 = 0;
            deystvie = "";
            textBox1.Text = "";
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_proc_Click(object sender, EventArgs e)
        {
            if (chislo1 != 0)
            {
                chislo2 = chislo1 * (float)Convert.ToDouble(textBox1.Text) / 100;
                textBox1.Text = chislo2.ToString();
            }
            else
            {
                chislo1 = 0;
                textBox1.Text = chislo1.ToString();
            }
            
            textBox1.Focus();
            textBox1.SelectionStart = textBox1.Text.Length;
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            Process.Start("History.txt");
        }

        
    }
}
