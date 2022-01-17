using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Module3
{

    class Methods<T>
    {
        public delegate Task Method(List<T> tList);

        public event Method OnMethods;

        public Methods()
        {
            OnMethods += FirstMethod;
            OnMethods += SecondMethod;
            OnMethods += ThirdMethod;
        }

        public ConcurrentDictionary<int, int> Answers { get; private set; } = new ConcurrentDictionary<int, int>();

        private async Task FirstMethod(List<T> tList)
        {
            int count = 0;

            foreach (T t in tList)
            {
                string name = t.ToString();
                if (name[0] == 'A')
                {
                    count++;
                }
            }

            Answers.TryAdd(1, count);

            await Task.Delay(1000);
        }

        private async Task SecondMethod(List<T> tList)
        {
            int count = 0;

            for (int i = 0; i < tList.Count; i++)
            {
                if (i >= 2 && i <= 5)
                {
                    count += tList[i].ToString().Length;
                }
            }

            Answers.TryAdd(2, count);

            await Task.Delay(1000);
        }

        private async Task ThirdMethod(List<T> tList)
        {
            for (var i = 1; i < tList.Count; i++)
            {
                for (var j = 0; j < tList.Count - i; j++)
                {
                    if (tList[j].ToString().Length < tList[j + 1].ToString().Length)
                    {
                        T buffer = tList[j];
                        tList[j] = tList[j + 1];
                        tList[j + 1] = buffer;
                    }
                }
            }

            int count = 0;

            for (int i = 0; i < 3; i++)
            {
                count += tList[i].ToString().Length;
            }

            Answers.TryAdd(3, count);

            await Task.Delay(1000);
        }

        public async Task PrintAnswers(List<T> list)
        {
            await OnMethods.Invoke(list);

            foreach (var answer in Answers)
            {
                Console.WriteLine($"Stat: {answer.Value}");
            }
        }
    }
}