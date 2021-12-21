using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03
{
    class Class1
    {
        public delegate int CalcPow();

        static int Pow(int a, int b)
        {
            return (a * b);
        }
    }
}
