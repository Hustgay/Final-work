using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace 计算器
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string Number = "",Answer = "";
        List<string> expressions = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_number_Click(object sender, RoutedEventArgs e)
        {
            Numberinput(Convert.ToString((sender as Button).Content));
        }   
        private void Button_equ_Click(object sender, RoutedEventArgs e)
        {
            Label1.Content = Result(Number);
            Answer = Result(Number);
            expressions.Add(Number + "=" + Result(Number));
            FileStream resultfile = new FileStream("result.txt", FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(resultfile);
            foreach (string a in expressions)
            {
                streamWriter.WriteLine(a);
            }
            streamWriter.Close();
            Number = "";
        }
        private void MenuItem_save_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("result.txt");
        }
        private void Button_clean_Click(object sender, RoutedEventArgs e)
        {
            Number = "";
            Label1.Content = "0";
        }
        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {
            if(Number.Length > 0)
            {
                Number = Number.Remove(Number.Length - 1);
                Label1.Content = Number;
            }
        }
        private void Button_ans_Click(object sender, RoutedEventArgs e)
        {
            Label1.Content = Answer;
            Number = Answer;
        }
        private void Numberinput(string Content)
        {
            if(Number.Length > 0)
            {
                if (Number.Substring(Number.Length - 1, 1) == "." && Content == ".")
                {
                    return;
                }
            }
            Number = Number + Content;
            Label1.Content = Number;
        }
        static char[] Operators = new char[] { '+', '-', '*', '/', '(', ')' };
        static string Result(string args)
        {
            string Number = "";
            float a = EvaluateExpression(args);
            Number = Convert.ToString(a);
            return Number;
        }
        /// <summary>
        /// 初始化运算符优先级
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static char InitPriorities(char a, char b)
        {
            int aIndex = -1;
            int bIndex = -1;
            for (int i = 0; i < Operators.Length; i++)
            {
                if (Operators[i] == a)
                    aIndex = i;
                if (Operators[i] == b)
                    bIndex = i;

            }
            char[,] Priorities = new char[6, 6] {{'>','>','<','<','<','>'},
                                                 {'>','>','<','<','<','>'},
                                                 {'>','>','>','>','<','>'},
                                                 {'>','>','>','>','<','>'},
                                                 {'<','<','<','<','<','='},
                                                 {'?','?','?','?','?','?'}};
            return Priorities[aIndex, bIndex];
        }
        static float Calculate(float Operand1, float Operand2, char Operator)
        {
            float Ret = 0;
            if (Operator == '+')
            {
                Ret = Operand1 + Operand2;
            }
            else if (Operator == '-')
            {
                Ret = Operand1 - Operand2;
            }
            else if (Operator == '*')
            {
                Ret = Operand1 * Operand2;
            }
            else if (Operator == '/')
            {
                Ret = Operand1 / Operand2;
            }
            return Ret;
        }
        static float EvaluateExpression(string str)
        {
            Stack<float> OperandStack = new Stack<float>(); // 操作数栈， 
            Stack<char> OperatorStack = new Stack<char>(); // 操作符栈  
            float OperandTemp = 0;
            int key = 0,j = 0,k = 0;

            char LastOperator = '0';  // 记录最后遇到的操作符  

            for (int i = 0, size = str.Length; i < size; ++i)
            {
                char ch = str[i];
                if (ch == '.')
                {
                    key = 1;
                }
                else if ('0' <= ch && ch <= '9')
                {   // 读取一个操作数  
                    if (key == 0)
                    { OperandTemp = OperandTemp * 10 + ch - '0'; }
                    else if (key == 1)
                    {
                        float s = 1;
                        j++;
                        for (k = j; k > 0; k--)
                        {
                            s = s * 10;
                        }
                        OperandTemp = OperandTemp + (ch - '0') / s; 
                    }
                }
                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/' ||
                    ch == '(' || ch == ')')
                {
                    key = 0;j = 0;
                    // 有2种情况 是没有操作数需要入栈保存的。  
                    // 1 当前操作符是 “(”。（的左边的操作符已经负责操作数入栈了。  
                    // 2 上一次遇到的操作符是“）”。）本身会负责操作数入栈，）后面紧跟的操作符不需要再负责操作数入栈。  
                    if (ch != '(' && LastOperator != ')')
                    {
                        // 遇到一个操作符后，意味着之前读取的操作数已经结束。保存操作数。  
                        OperandStack.Push(OperandTemp);
                        // 清空，为读取下一个操作符做准备。  
                        OperandTemp = 0;
                    }

                    // 当前遇到的操作符作为操作符2，将和之前遇到的操作符（作为操作符1）进行优先级比较  
                    char Opt2 = ch;

                    for (; OperatorStack.Count > 0;)
                    {
                        // 比较当前遇到的操作符和上一次遇到的操作符(顶部的操作符)的优先级  
                        char Opt1 = OperatorStack.Peek();
                        char CompareRet = InitPriorities(Opt1, Opt2);
                        if (CompareRet == '>')
                        {   // 如果操作符1 大于 操作符2 那么，操作符1应该先计算  

                            // 取出之前保存的操作数2  
                            float Operand2 = OperandStack.Pop();

                            // 取出之前保存的操作数1  
                            float Operand1 = OperandStack.Pop();

                            // 取出之前保存的操作符。当前计算这个操作符，计算完成后，消除该操作符，就没必要保存了。  
                            OperatorStack.Pop();

                            // 二元操作符计算。并把计算结果保存。  
                            float Ret = Calculate(Operand1, Operand2, Opt1);
                            OperandStack.Push(Ret);
                        }
                        else if (CompareRet == '<')
                        {   // 如果操作符1 小于 操作符2，说明 操作符1 和 操作符2 当前都不能进行计算，  
                            // 退出循环，记录操作符。  
                            break;
                        }
                        else if (CompareRet == '=')
                        {
                            // 操作符相等的情况，只有操作符2是“）”，操作数1是“（”的情况，  
                            // 弹出原先保存的操作符“（”，意味着“（”，“）”已经互相消掉，括号内容已经计算完毕  
                            OperatorStack.Pop();
                            break;
                        }

                    } // end for  

                    // 保存当前遇到操作符，当前操作符还缺少右操作数，要读完右操作数才能计算。  
                    if (Opt2 != ')')
                    {
                        OperatorStack.Push(Opt2);
                    }

                    LastOperator = Opt2;
                }

            } // end for  


            /* 
            上面的 for 会一面遍历表达式一面计算，如果可以计算的话。 
            当遍历完成后，并不代表整个表达式计算完成了。而会有2种情况： 
            1.剩余1个运算符。 
            2.剩余2个运算符，且运算符1 小于 运算符2。这种情况，在上面的遍历过程中是不能进行计算的，所以才会被遗留下来。 
            到这里，已经不需要进行优先级比较了。情况1和情况2，都是循环取出最后读入的操作符进行运算。 
            */
            if (LastOperator != ')')
            {
                OperandStack.Push(OperandTemp);
            }
            for (; OperatorStack.Count > 0;)
            {
                // 取出之前保存的操作数2  
                float Operand2 = OperandStack.Pop();

                // 取出之前保存的操作数1  
                float Operand1 = OperandStack.Pop();

                // 取出末端一个操作符  
                char Opt = OperatorStack.Pop();

                // 二元操作符计算。  
                float Ret = Calculate(Operand1, Operand2, Opt);
                OperandStack.Push(Ret);
            }

            return OperandStack.Peek();
        }


    }
}
