using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure
{
    class Cops
    {
        public virtual void CopAttack()
        {
            Console.WriteLine("The Cop shoots you with his handgun.");
            Player.TakeDamage(1);
        }

        public class RiotCop : Cops
        {
            public override void CopAttack()
            {
                Console.WriteLine("The Armored cop shoots you with his shotgun.");
                Player.TakeDamage(1);
            }
        }

        public class SWATCop : Cops
        {
            public override void CopAttack()
            {
                Console.WriteLine("The SWAT officer shoots you with his rifle.");
                Player.TakeDamage(1);
            }
        }

        public class SniperCop : Cops
        {
            public override void CopAttack()
            {
                Console.WriteLine("The Sniper Cop shoots you with his rifle.");
                Player.TakeDamage(2);
            }
        }
    }
}
