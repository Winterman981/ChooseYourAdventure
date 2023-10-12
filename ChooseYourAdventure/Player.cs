using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure
{
    internal class Player
    {
        private static int health = 5;
        private static int bandages = 2;

        public Player()
        {
            
        }

        public static void TakeDamage(int damage)
        {
            health = health - damage;

            if (health <= 0)
            {
                health = 0;
                Console.WriteLine("You died.");
            }
        }

        public static void Heal()
        {
            if(bandages > 0)
            {
                health = health + 1;
                Console.WriteLine("You healed yourself to " + Player.health + " health.");
                Console.WriteLine("You have " + Player.bandages + " bandages left.");

                bandages = bandages - 1;
            }

            else
            {
                Console.WriteLine("You have run out of bandages");
            }
        }

        public static int GetHeatlth
        {
            get{ return health; }
            set { health = value; }
        }

        public static void BandagesLeft()
        {
            Console.WriteLine("You have " + Player.bandages + " bandages left.");
        }
    }
}
