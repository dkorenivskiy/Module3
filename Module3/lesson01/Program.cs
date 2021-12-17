using System;

namespace lesson01
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            list.Add(5);
            list.Add(6);
            list.Add(200);
            list.Add(54);

            int[] array = new int[] { 5, 6, 2, 2, 3, 1, 5};
            list.AddRange(array);
            int[] array1 = new int[] { 7, 2, 1, 67, 123, 564, 23 };
            list.AddRange(array1);

            list.Remove(6);
            list.RemoveAt(2);
            list.Sort();

            foreach(var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
