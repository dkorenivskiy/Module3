using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace practice3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            Player[] players =
            {
            new DefaultPlayer(),
            new UberPlayer(),
            new NotePlayer()
            };

            Console.WriteLine("Enter the weight of Cart");
            int playerWeight = Convert.ToInt32(Console.ReadLine());

            var cart = new Cart(playerWeight);

            for (var j = 0; j < 3; j++)
            {
                tasks.Add(Task.Run(async () =>
                {
                    for (var i = 0; i < 100; i++)
                    {
                        if(cart.EndGame == true)
                        {

                        }
                    }
                }));
            }

        }
    }
}
