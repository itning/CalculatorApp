using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {

        private string showStr = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty)
            {
                UpdateStrAndBox("0");

            }
            else if (!IsLastStrOperator())
            {
                UpdateStrAndBox("0");
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {

            UpdateStrAndBox("1");
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("2");
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("3");
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("4");
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("5");
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("6");
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("7");
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("8");
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("9");
        }

        private void Btnjia_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty && !IsLastStrOperator())
            {
                UpdateStrAndBox("+");
            }
        }

        private void Btnjian_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty && !IsLastStrOperator())
            {
                UpdateStrAndBox("-");
            }
        }

        private void Btncheng_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty && !IsLastStrOperator())
            {
                UpdateStrAndBox("*");
            }
        }

        private void Btnchu_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty && !IsLastStrOperator())
            {
                UpdateStrAndBox("/");
            }
        }

        private void Btnc_Click(object sender, EventArgs e)
        {
            ShowBox.Focus();
            if (showStr == string.Empty)
            {
                ShowBox.Text = "0";
                return;
            }
            showStr = showStr.Substring(0, showStr.Length - 1);
            if (string.Equals(showStr, string.Empty))
            {
                showStr = "0";
            }
            ShowBox.Text = showStr;
        }

        private void Btndian_Click(object sender, EventArgs e)
        {
            if (showStr == string.Empty)
            {
                UpdateStrAndBox("0.");
                return;
            }
            char[] cs = { '+', '-', '*', '/' };
            int index = showStr.LastIndexOfAny(cs);
            //没有找到
            if (index == -1 && !showStr.Contains("."))
            {
                UpdateStrAndBox(".");
                return;
            }
            if (index != -1 && showStr.IndexOf(".", index) == -1 && !IsLastStrOperator())
            {
                UpdateStrAndBox(".");
            }
        }

        private void Btnenter_Click(object sender, EventArgs e)
        {
            ShowBox.Focus();
            if (showStr.IndexOfAny(new char[] { '+', '-', '*', '/' }) == -1)
            {
                return;
            }
            try
            {
                double result = Calculation.GetCalculation().Result(showStr);
                showStr = string.Empty;
                ShowBox.Text = result.ToString();
            }
            catch (Exception)
            {
                return;
            }
          
        }

        private void UpdateStrAndBox(string str)
        {
            ShowBox.Focus();
            if (showStr == "0" && str != ".")
            {
                showStr = str;
            }
            else
            {
                showStr += str;
            }
            ShowBox.Text = showStr;
        }


        private bool IsLastStrOperator()
        {
            if (showStr.Length == 0)
            {
                return false;
            }
            switch (showStr[showStr.Length - 1])
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    {
                        return true;
                    }
            }
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    {
                        this.Btn0_Click(null, null);
                        break;
                    }
                case Keys.NumPad1:
                    {
                        this.Btn1_Click(null, null);
                        break;
                    }
                case Keys.NumPad2:
                    {
                        this.Btn2_Click(null, null);
                        break;
                    }
                case Keys.NumPad3:
                    {
                        this.Btn3_Click(null, null);
                        break;
                    }
                case Keys.NumPad4:
                    {
                        this.Btn4_Click(null, null);
                        break;
                    }

                case Keys.NumPad5:
                    {
                        this.Btn5_Click(null, null);
                        break;
                    }
                case Keys.NumPad6:
                    {
                        this.Btn6_Click(null, null);
                        break;
                    }
                case Keys.NumPad7:
                    {
                        this.Btn7_Click(null, null);
                        break;
                    }
                case Keys.NumPad8:
                    {
                        this.Btn8_Click(null, null);
                        break;
                    }
                case Keys.NumPad9:
                    {
                        this.Btn9_Click(null, null);
                        break;
                    }
                case Keys.Add:
                    {
                        this.Btnjia_Click(null, null);
                        break;
                    }
                case Keys.Subtract:
                    {
                        this.Btnjian_Click(null, null);
                        break;
                    }
                case Keys.Multiply:
                    {
                        this.Btncheng_Click(null, null);
                        break;
                    }
                case Keys.Divide:
                    {
                        this.Btnchu_Click(null, null);
                        break;
                    }
                case Keys.Decimal:
                    {
                        this.Btndian_Click(null, null);
                        break;
                    }
                case Keys.Back:
                case Keys.Delete:
                    {
                        this.Btnc_Click(null, null);
                        break;
                    }
                case Keys.Return:
                    {
                        this.Btnenter_Click(null, null);
                        break;
                    }
            }
        }
    }
}
