using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson03
{
    class Class2
    {
        public delegate bool ResultDelegate(int result);

        public ResultDelegate resultDelegate;

        public Class2()
        {
            resultDelegate = Result;
        }

        private int _result;

        private Class1 _class1 = new Class1();

        private ResultDelegate Calc(int a, int b, PowDelegate powDelegate)
        {
            powDelegate = _class1.powDelegate;
            _result = powDelegate(a, b);


        }

        private bool Result(int result)
        {


            return false;
        }
    }
}
