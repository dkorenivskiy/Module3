using System;
using System.Collections.Generic;

namespace Practice1
{
    class Program
    {
        public delegate int CalcOperation(int x, int y);

        static CalcOperation calcOperation;

        static void Main(string[] args)
        {
            var calculator = new Calculator();

            string choice;
            int count = 0;
            do
            {
                if (count == 0)
                {
                    Console.WriteLine("=====Calculator=====");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Add another method or start program");
                    Console.WriteLine();
                }

                Console.WriteLine("1 - (x + y)");
                Console.WriteLine("2 - (x - y)");
                Console.WriteLine("3 - (x * y)");
                Console.WriteLine("4 - (x / y)");
                Console.WriteLine("5 - Result of program");
                Console.WriteLine("0 - exit");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        calcOperation += calculator.Add;
                        count++;
                        break;

                    case "2":
                        calcOperation += calculator.Difference;
                        count++;
                        break;

                    case "3":
                        calcOperation += calculator.Product;
                        count++;
                        break;

                    case "4":
                        calcOperation += calculator.Division;
                        count++;
                        break;

                    case "5":
                        Start(calcOperation);
                        count = 0;
                        Console.WriteLine("Type any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "0":
                        break;

                    default:
                        Console.WriteLine("Wrong value!");
                        break;
                }
            } while (choice != "0");
        }

        private static void Start(CalcOperation calcOperation)
        {
            Console.WriteLine("Enter x");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter y");
            int y = Convert.ToInt32(Console.ReadLine());
            var listOfCalcOperations = calcOperation.GetInvocationList();
            int sum = 0;

            foreach (var operation in listOfCalcOperations)
            {
                try
                {
                    sum += (int)operation.DynamicInvoke(x, y);
                }
                catch(DivideByZeroException ex)
                {
                    Console.WriteLine($"Error! {ex.Message}");
                } 
            }

            Console.WriteLine($"Sum = {sum}");
        }
    }
}



