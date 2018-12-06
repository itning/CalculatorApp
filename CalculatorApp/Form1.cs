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
        /// <summary>
        /// 显示的字符串
        /// </summary>
        private string showStr = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按钮0点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
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

        /// <summary>
        /// 按钮1点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn1_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("1");
        }

        /// <summary>
        /// 按钮2点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn2_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("2");
        }

        /// <summary>
        /// 按钮3点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn3_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("3");
        }

        /// <summary>
        /// 按钮4点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn4_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("4");
        }

        /// <summary>
        /// 按钮5点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn5_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("5");
        }

        /// <summary>
        /// 按钮6点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn6_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("6");
        }

        /// <summary>
        /// 按钮7点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn7_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("7");
        }

        /// <summary>
        /// 按钮8点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn8_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("8");
        }

        /// <summary>
        /// 按钮9点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btn9_Click(object sender, EventArgs e)
        {
            UpdateStrAndBox("9");
        }

        /// <summary>
        /// 按钮+点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btnjia_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty && !IsLastStrOperator())
            {
                UpdateStrAndBox("+");
            }
        }

        /// <summary>
        /// 按钮-点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btnjian_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty && !IsLastStrOperator())
            {
                UpdateStrAndBox("-");
            }
        }

        /// <summary>
        /// 按钮*点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btncheng_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty && !IsLastStrOperator())
            {
                UpdateStrAndBox("*");
            }
        }

        /// <summary>
        /// 按钮/点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
        private void Btnchu_Click(object sender, EventArgs e)
        {
            if (showStr != string.Empty && !IsLastStrOperator())
            {
                UpdateStrAndBox("/");
            }
        }

        /// <summary>
        /// 按钮C点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
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

        /// <summary>
        /// 按钮.点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
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

        /// <summary>
        /// 按钮Enter点击事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
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

        /// <summary>
        /// 更新<c>showStr</c>和<c>ShowBox.Text</c>值
        /// </summary>
        /// <permission cref="showStr">更新该成员的值</permission>
        /// <param name="str">要更新的字符串</param>
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

        /// <summary>
        /// 验证<c>showStr</c>成员中的上一个字符是否为操作符(+,-,*,/)
        /// </summary>
        /// <returns>如果是操作符返回<c>true</c>否则返回<c>false</c></returns>
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

        /// <summary>
        /// 窗体键盘按下事件
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="e">不包含事件数据的对象</param>
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
