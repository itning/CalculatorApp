using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Calculation
    {
        private readonly static Calculation c = new Calculation();
        private Calculation()
        {

        }

        public static Calculation GetCalculation()
        {
            return c;
        }

        public double Result(string str)
        {
            List<string> ops = GetOps(str);
            List<double> num = GetNum(str);

            // 先乘除再加减
            for (int i = 0; i < ops.Count; i++)
            {
                if (ops[i].Contains("*") || ops[i].Contains("/"))
                {
                    String op = ops[i];
                    ops.RemoveAt(i);
                    if (op.Equals("*"))
                    {
                        // 从数字集合取对应和后面一位数字
                        double d1 = num[i];
                        num.RemoveAt(i);
                        double d2 = num[i];
                        num.RemoveAt(i);

                        double number = d1 * d2;
                        //再加上
                        num.Insert(i, number);
                    }
                    if (op.Equals("/"))
                    {
                        double d1 = num[i];
                        num.RemoveAt(i);
                        double d2 = num[i];
                        num.RemoveAt(i);
                        double number = d1 / d2;
                        num.Insert(i, number);
                    }
                    i--;    //刚刚移掉两个,却又刚加上一个新数,所以i要--,因为i++,所以才能取到,如果不加那么虽然貌似正常,但是如果如8*3/3,*/连在一起就报错了;因为连着的两个if;
                }
            }
            //到+-,按顺序的所以就用while()了
            while (ops.Count != 0)
            {
                String op = ops[0];
                ops.RemoveAt(0);
                double d1 = num[0];
                num.RemoveAt(0);
                double d2 = num[0];
                num.RemoveAt(0);

                if (op.Equals("+"))
                {
                    double number = d1 + d2;
                    //再加入
                    num.Insert(0, number);
                }
                if (op.Equals("-"))
                {
                    double number = d1 - d2;
                    num.Insert(0, number);
                }
            }
            return num[0];
        }

        /**
     * 获取符号 1.首位 和 * /后面 的-变成@,其他的-不用
     */
        private List<double> GetNum(string str)
        {
            // -变成@
            str = Change(str);
            List<double> list = new List<double>();

            String[] split = Regex.Split(str, "[\\+\\-\\*/]");
            for (int i = 0; i < split.Length; i++)
            { // @3,5,@4,9,@3
                String s = split[i];
                // 再把@变成-
                if (s.Contains("@"))
                {
                    s = '-' + s.Substring(1);
                }
                list.Add(Double.Parse(s));
            }

            return list;
        }

        private string Change(string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                // @3+5*-4-9/-3
                if (i == 0 && chars[i] == '-')
                {
                    str = '@' + str.Substring(i + 1);
                }
                // @3+5*@4-9/@3
                if (chars[i] == '*' && chars[i + 1] == '-' || chars[i] == '/' && chars[i + 1] == '-')
                {
                    str = str.Substring(0, i + 1) + '@' + str.Substring(i + 2);
                }
            }
            return str;
        }

        // 获取符号
        private List<string> GetOps(String str)
        {
            List<string> list = new List<string>();
            // @变-
            str = Change(str);
            // @3+5*@4-9/@3
            String[] split = Regex.Split(str, "[0-9\\.@]");  // 表示0-9包括小数和@
            for (int i = 0; i < split.Length; i++)
            {
                if (split[i].Contains("+") || split[i].Contains("-") || split[i].Contains("*") || split[i].Contains("/"))
                {
                    list.Add(split[i]);
                }
            }
            return list;
        }
    }
}
