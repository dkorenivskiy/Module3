using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace practice2
{
    class MessageBox
    {
        public delegate void OnWindowOpenClose(State state);

        public event OnWindowOpenClose windowOpenClose;

        public async void Open(CancellationToken cancellationToken)
        {
            await Task.Run(() => 
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    Console.WriteLine("Window is open");
                    Thread.Sleep(3000);
                    Console.WriteLine("Window is closed by user");

                    Random random = new Random();
                    int choice = random.Next(0, 2);
                    windowOpenClose((State)choice);
                }
            });
        }
    }
}