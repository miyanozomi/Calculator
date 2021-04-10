using System;

namespace Calculator
{
    class Calculator
    {
        public void DoOperation()
        {
            // 入力
            Console.WriteLine("計算式を入力してください。");
            Console.WriteLine("入力は整数もしくは演算子のみとします。");
            string token = Console.ReadLine();
            // 【暫定】動作確認用。あとで消す。
            Console.WriteLine(token);
            Console.WriteLine(token.Length);

            // 中置記法変換
            string que = ConvInfixNotationToReversePolishNotion(token);
            Console.WriteLine(que);

            // 計算
            // 出力
        }

        private string ConvInfixNotationToReversePolishNotion(string token)
        {
            int length = token.Length;
            string que = null;
            int queIndex = 0;
            string stack = null;
            int stackIndex = 0;
            for (int i = 0; i < length; i++)
            {
                if (char.IsNumber(token[i]))
                {
                    string q = new string(token[i], 1);
                    que = que.Insert(queIndex, q);
                    queIndex++;
                }
                else if (IsOperator(token[i]))
                {
                    string s = new string(token[i], 1);
                    stack = stack.Insert(stackIndex, s);
                    stackIndex++;
                    if (IsPriorityOperator(token[i]))
                    {
                        que = que.Insert(queIndex, stack);
                        queIndex += stack.Length;
                        stackIndex = 0;
                    }
                }
                else
                {
                    continue;
                }
            }
            return que;
        }
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
        private bool IsPriorityOperator(char c)
        {
            switch (c)
            {
                case '*':
                case '/':
                    return true;
                default:
                    return false;
            }
        }
    }

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
