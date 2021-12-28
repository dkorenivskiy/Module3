using System;
using System.Threading;

namespace practice2
{
    enum State
    {
        Ok,
        Cancel
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            MessageBox messageBox = new MessageBox();
            messageBox.windowOpenClose += Open;
            messageBox.Open(cts.Token);

            string quitProgram = Console.ReadKey().ToString();
            if (quitProgram == "Q" || quitProgram == "q")
            {
                cts.Cancel();
            }
        }

        private static void Open(State state)
        {
            if (state == State.Ok)
            {
                Console.WriteLine("Ok - operation succeed\n");
            }

            if (state == State.Cancel)
            {
                Console.WriteLine("Cancel - operation unsucceed\n   ");
            }
        }
    }
}
