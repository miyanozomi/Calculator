using System;

namespace Calculator
{
    class Calculator
    {
        public void DoOperation()
        {
            // 入力
            Console.WriteLine("計算式を入力してください。");
            string token = Console.ReadLine();
            // 【暫定】動作確認用
            Console.WriteLine(token);
            Console.WriteLine(token.Length);

            // 変換
            string que = ConvInfixNotationToReversePolishNotion(token);

            // 計算
            // 出力
        }

        private string ConvInfixNotationToReversePolishNotion(string token)
        {
            string que = null;
            return que;
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
