using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Module3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //List<int> List = new List<int>() { 5, 12, 12424, 53, 88, 214 };
            List<string> List = new List<string>() { "John", "Joe", "Steve", "Tony", "Arthur", "Barbara" };
            //List<char> List = new List<char>() { 'K', 'Z', 's', 'P', ',', 'L', 'A', 'C' };

            var methods = new Methods<string>();

            await methods.PrintAnswers(List);
        }
    }
}
