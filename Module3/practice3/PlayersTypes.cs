using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice3
{
    public enum PlayerTypes
    {
        Winner,
        Default,
        Uber,
        Notebook,
        Cheater
    }

    public class DefaultPlayer : Player, IPlayer
    {
        public DefaultPlayer()
        {
            PlayerType = PlayerTypes.Default;
            Name = "Alex";
        }
    }

    public class UberPlayer : Player, IPlayer
    {
        public UberPlayer()
        {
            PlayerType = PlayerTypes.Uber;
            Name = "Tony";
            CheckingWeigth = 39;
        }

        public override void TryCheckWeight()
        {
            CheckingWeigth++;
        }
    }

    public class NotePlayer : Player, IPlayer
    {
        private List<int> _checkedNumbs = new List<int>();
        public NotePlayer()
        {
            PlayerType = PlayerTypes.Default;
            Name = "Kane";
        }

        public override void TryCheckWeight()
        {
            var random = new Random();

            CheckingWeigth = random.Next(40, 141);

            if(_checkedNumbs.Contains(CheckingWeigth))
            {
                while(_checkedNumbs.Contains(CheckingWeigth))
                {
                    CheckingWeigth = random.Next(40, 141);
                }
            }
            else
            {
                _checkedNumbs.Add(CheckingWeigth);
            }
        }
    }
}
