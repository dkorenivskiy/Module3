using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03
{
    public delegate bool ResultDelegate(int number);

    class Class2
    {

        public ResultDelegate resultDelegate;

        private int _result;

        private Class1 _class1 = new Class1();

        public ResultDelegate Calc(int a, int b, PowDelegate powDelegate)
        {
            _result = powDelegate(a, b);

            resultDelegate = Result;
            return resultDelegate;
        }

        private bool Result(int number)
        {
            if(_result % number == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
