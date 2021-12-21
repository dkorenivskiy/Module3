using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Calculator
    {
        public int Add(int x, int y)
        {
            Console.WriteLine($"x + y = {x + y}");
            return (x + y);
        }

        public int Difference(int x, int y)
        {
            Console.WriteLine($"x - y = {x - y}");
            return (x - y);
        }

        public int Product(int x, int y)
        {
            Console.WriteLine($"x * y = {x * y}");
            return (x * y);
        }

        public int Division(int x, int y)
        {
            try
            {
                Console.WriteLine($"x / y = {x / y}");
                return (x / y);
            }
            catch
            {
                return 0;
            }
        }
    }
}
