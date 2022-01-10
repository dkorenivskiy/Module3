using System;

namespace lesson03
{
    class Program
    {
        static void Show(ResultDelegate resultDelegate)
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 25);

            Console.WriteLine("Result = {0}", resultDelegate?.Invoke(number));
        }

        static void Main(string[] args)
        {
            var class1 = new Class1();
            var class2 = new Class2();
            Show(class2.Calc(5, 5, class1.powDelegate));
        }
    }
}
