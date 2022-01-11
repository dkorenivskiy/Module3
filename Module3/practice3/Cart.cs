using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice3
{
    class Cart
    {
        private int _weigth;
        public bool EndGame;

        public Cart(int weigth)
        {
            _weigth = weigth;
        }

        public void CheckWeigth(int weight, Player player)
        {
            if (_weigth == weight)
            {
                EndGame = true;
                Console.WriteLine($"{player.Name} - won!");
            }
            else
            {
                EndGame = false;
            }
        }
    }
}
