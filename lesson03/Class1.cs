using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03
{
    public delegate int PowDelegate(int a, int b);

    class Class1
    {
        public delegate void boolDelegate();

        public PowDelegate powDelegate;

        public Class1()
        {
            powDelegate = Pow;
        }

        static int Pow(int a, int b)
        {
            return (a * b);
        }
    }
}
