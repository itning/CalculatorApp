using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CalculatorApp
{
    /// <summary>
    /// 计算核心算法
    /// </summary>
    class Calculation
    {
        /// <summary>
        /// 静态只读实例
        /// </summary>
        private readonly static Calculation c = new Calculation();

        /// <summary>
        /// 私有化构造方法(单例)
        /// </summary>
        private Calculation()
        {

        }

        /// <summary>
        /// 提供公共静态获取器
        /// </summary>
        /// <returns><c>Calculation</c>实例</returns>
        public static Calculation GetCalculation()
        {
            return c;
        }

        /// <summary>
        /// 给定字符串,返回运算结果
        /// </summary>
        /// <param name="str">要计算的字符串</param>
        /// <returns>算术结果</returns>
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
                        //从数字集合取对应和后面一位数字
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
                    //刚刚移掉两个,却又刚加上一个新数,所以i要--,因为i++,
                    //所以才能取到,如果不加那么虽然貌似正常,但是如果如8*3/3,*/连在一起就报错了;因为连着的两个if;
                    i--;
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

        /// <summary>
        /// 获取符号 1.首位 和 * /后面 的-变成@,其他的-不用
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>符号集合</returns>
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

        /// <summary>
        /// 将负数的负号变成@
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>变换完的字符串</returns>
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

        /// <summary>
        /// 获取符号
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>符号集合</returns>
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
