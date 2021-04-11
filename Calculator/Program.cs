using System;
using System.Collections.Generic;

namespace Calculator
{
    class Calculator
    {
        //---------------------------------------------------------
        public void DoOperation()
        {
            // 入力
            Console.WriteLine("計算式を入力してください。");
            Console.WriteLine("入力は整数もしくは演算子のみとします。");
            Console.WriteLine("演算子：+、-、*、/");
            string token = Console.ReadLine();

            // 中置記法から逆ポーランド記法へ変換
            Queue<string> queue = ConvInfixNotationToReversePolishNotion(token);

            // 計算
            double answer = DoCalculate(queue);

            // 出力
            Console.WriteLine("= " + answer);
        }

        //---------------------------------------------------------
        private Queue<string> ConvInfixNotationToReversePolishNotion(string token)
        {
            int length = token.Length;
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < length; i++)
            {
                if (char.IsNumber(token[i]))
                {
                    string s = new string(token[i], 1);
                    queue.Enqueue(s);
                }
                else if (IsOperator(token[i]))
                {
                    string checkStr = new string(token[i], 1);
                    if (0 == stack.Count)
                    {
                        stack.Push(checkStr);
                        continue;
                    }

                    if ((0 != stack.Count) &&
                        (GetOperatorLevel(checkStr) > GetOperatorLevel(stack.Peek())))
                    {
                        stack.Push(checkStr);
                    }
                    else
                    {
                        while (0 != stack.Count)
                        {
                            string str = stack.Pop();
                            queue.Enqueue(str);
                        }
                        stack.Push(checkStr);
                    }
                }
                else
                {
                    continue;
                }
            }
            if (0!=stack.Count)
            {
                while (0 != stack.Count)
                {
                    string str = stack.Pop();
                    queue.Enqueue(str);
                }
            }
            return queue;
        }

        //---------------------------------------------------------
        private double DoCalculate(Queue<string> queue)
        {
            double answer = 0.0;
            Queue<string> copyQueue = new Queue<string>(queue);
            Stack<double> stack = new Stack<double>();
            while (0 != copyQueue.Count)
            {
                string s = copyQueue.Dequeue();
                if (double.TryParse(s, out double d))
                {
                    stack.Push(d);
                }
                else
                {
                    double arg2 = stack.Pop();
                    double arg1 = stack.Pop();
                    double result = Calculate(arg1, arg2, s);
                    stack.Push(result);
                }
            }
            answer = stack.Pop();
            return answer;
        }

        //---------------------------------------------------------
        private bool IsOperator(char c)
        {
            switch ( c )
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    return true;
                default:
                    return false;
            }
        }

        //---------------------------------------------------------
        private int GetOperatorLevel(string c)
        {
            switch (c)
            {
                case "*":
                case "/":
                    return 1;
                default:
                    return 0;
            }
        }

        private double Calculate(double arg1, double arg2, string s)
        {
            double result = 0.0;
            switch (s)
            {
                case "+":
                    result = arg1 + arg2;
                    break;
                case "-":
                    result = arg1 - arg2;
                    break;
                case "*":
                    result = arg1 * arg2;
                    break;
                case "/":
                    result = arg1 / arg2;
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    //-------------------------------------------------------------
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("キーを入力してください。");
            Console.WriteLine("S：開始、E：終了");
            string s = Console.ReadLine();
            while (("S" != s) && ("E" != s))
            {
                Console.WriteLine("入力が正しくありません。再度入力してください。");
                s = Console.ReadLine();
            }
            if ("S" == s)
            {
                // 計算機スタート
                try
                {
                    string judge = null;
                    Calculator calculator = new Calculator();
                    do
                    { 
                        calculator.DoOperation();
                        Console.WriteLine("\nキーを入力してください。");
                        Console.WriteLine("C：継続、E：終了");
                        judge = Console.ReadLine();
                        while (("C" != judge) && ("E" != judge))
                        {
                            Console.WriteLine("入力が正しくありません。再度入力してください。");
                            judge = Console.ReadLine();
                        }
                    } while ("E" != judge);
                }
                catch (Exception e)
                {
                    Console.WriteLine("想定外のエラーです。\n - エラー内容： " + e.Message);
                }
            }
            Console.WriteLine("プログラムを終了します。");
            return;
        }
    }
}
