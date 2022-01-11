using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice3
{
    public class Player : IPlayer
    {
        public PlayerTypes PlayerType { get; protected set; }
        public int CheckingWeigth { get; protected set; }
        public string Name { get; set; }

        public virtual void TryCheckWeight()
        {
            var random = new Random();

            CheckingWeigth = random.Next(40, 141);
        }
    }
}
