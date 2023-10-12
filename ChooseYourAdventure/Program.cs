using ChooseYourAdventure;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using static ChooseYourAdventure.Cops;

namespace CopsNRobbers
{
    class Program
    {
        public static Node[] inventory = new Node[5];

        Cops beatCop1 = new Cops();
        Cops beatCop2 = new Cops();
        Cops sniper = new SniperCop();
        Cops swat = new SWATCop();
        Cops riot = new RiotCop();

        static public void Main(string[] args)
        {
            Player player = new Player();
            Program program = new Program();


            //inventory[0] = new Node("Stun Grenade");
            //inventory[1] = new Node("Smoke Grenade");

            //inventory[0].m_next = inventory[1];

            program.FirstChoice();
            
        }

        public void FirstChoice()
        {
            Console.WriteLine("You are a mobster escaping from the cops with your friends, from a deal gone bad. But you get separated from them, now you need to find a way to the escape vehicle.");
            Console.WriteLine("You have 2 bandages to heal yourself in case you get hit.");
            Console.WriteLine("The alley before you splits into 2 paths.");
            Console.WriteLine("Type 1 or 2 to choose.");
            Console.WriteLine("");

            int choiceOne = Convert.ToInt32(Console.ReadLine());

            if (choiceOne == 1)
            {
                LeftAlley();
            }

            if (choiceOne == 2)
            {
                RightAlley();
            }

            if(choiceOne != 1 && choiceOne != 2)
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid choice, please enter either 1 or 2.");
                Console.WriteLine("");
                FirstChoice();
            }

            else
            {
                Console.WriteLine("Invalid choice, please press 1 or 2.");
            }
        }
        
        public void LeftAlley()
        {
            Console.WriteLine("");
            Console.WriteLine("You took the alleyway to the left.");
            Console.WriteLine("However, a police officer has spotted you and you must fight your way out!");
            Console.WriteLine("Press A to attack! Your attack must be greater than 8 to hit!");
            Console.WriteLine("Press I to check your inventory.");
            Console.WriteLine("");

            LAlleyResult();
        }

        public void RightAlley()
        {
            Console.WriteLine("");
            Console.WriteLine("You decided to escape into alley to the right.");
            Console.WriteLine("However, a police officer has spotted you and you must fight your way out!");
            Console.WriteLine("He is wearing body armor!");
            Console.WriteLine("Press A to attack! Your attack must be greater than 11 to hit!");
            Console.WriteLine("Press I to check your inventory.");
            Console.WriteLine("");

            RAlleyResult(); 
        }

        public void LAlleyResult()
        {
            string choiceTwoA = Console.ReadLine();

            if (choiceTwoA == "a" || choiceTwoA == "A")
            {
                LAlleyAttack();
            }

            if (choiceTwoA == "h" || choiceTwoA == "H")
            {
                Player.Heal();
                Console.WriteLine("Press A to attack again.");
                LAlleyResult();
            }

            if (choiceTwoA == "i" || choiceTwoA == "I")
            {
                Console.WriteLine("");
                checkInventory();
                Console.WriteLine("Press A to attack! Your attack must be greater than 8 to hit!");
                LAlleyResult();
            }

            else
            {
                Console.WriteLine("Invalid choice, please press A to attack, or press H to heal.");
            }
        }

        public void LAlleyAttack()
        {
            Random rnd = new Random();
            int result;

            result = rnd.Next(1, 20);
            Console.WriteLine(result);

            if (result <= 8)
            {
                Console.WriteLine("");
                Console.WriteLine("Your shot missed the cop!");
                beatCop1.CopAttack();
                Console.WriteLine("You have " + Player.GetHeatlth + " health left.");
                Console.WriteLine("Press A to attack! Your attack must be greater than 8 to hit!");
                Console.WriteLine("Press H to heal yourself.");
                Console.WriteLine("");
                LAlleyResult();
            }

            else
            {
                Console.WriteLine("");
                Console.WriteLine("Your shot hit the police officer right in the chest, he collapsed onto the floor.");
                Console.WriteLine("You noticed that he was carrying a stun grenade on his belt, so you take it with you.");
                inventory[0] = new Node("Stun Grenade");

                Avenue();
            }
        }

        public void RAlleyResult()
        {
            Console.WriteLine("");

            string choiceOneB = Console.ReadLine();
            
            if(choiceOneB == "a" || choiceOneB == "A")
            {
                RAlleyAttack();
            }

            if (choiceOneB == "h" || choiceOneB == "H")
            {
                Player.Heal();
                Console.WriteLine("Press A to attack again.");
                RAlleyResult();
            }

            if (choiceOneB == "i" || choiceOneB == "I")
            {
                Console.WriteLine("");
                checkInventory();
                Console.WriteLine("Press A to attack! Your attack must be greater than 8 to hit!");
                RAlleyResult();
            }

            else
            {
                Console.WriteLine("Invalid choice, please press A.");
            }
        }

        public void RAlleyAttack() 
        {
            Random rnd = new Random();
            int result;

            result = rnd.Next(1, 20);
            Console.WriteLine(result);

            if (result <= 11)
            {
            
                Console.WriteLine("Your shot was absorbed by the cop's armor!");
                beatCop2.CopAttack();
                Console.WriteLine("You have " + Player.GetHeatlth + " health left.");
                Console.WriteLine("Press A to attack! Your attack must be greater than 11 to hit!");
                Console.WriteLine("Press H to heal yourself.");
                Console.WriteLine("");
                RAlleyResult();
            }
            
            if (result > 11)
            {
                Console.WriteLine("");
                Console.WriteLine("Your shot goes through the officer's armor and he collapsed!");
                Console.WriteLine("His body armor seems useful, so you decided to wear it yourself.");
                inventory[0] = new Node("Body Armor");
            
                Avenue();
            }
        }

        public void Avenue()
        {
            Console.WriteLine("");
            Console.WriteLine("You comes out of the alley and into a shopping avenue.");
            Console.WriteLine("However, you spot a light at the corner of your eye!");
            Console.WriteLine("A police sniper is taking his shot!");
            Console.WriteLine("Press H to heal yourself.");
            Console.WriteLine("Press I to check your inventory.");

            if (inventory[0].FindItem("Body Armor") == true)
            {
                Console.WriteLine("Press A to dodge the bullet!");
                Console.WriteLine("");
                Console.WriteLine("Since you have the body armor, you only need 7 or more to dodge the bullet!");
                AvenueResult();
            }

            if (inventory[0].FindItem("Stun Grenade") == true)
            {
                Console.WriteLine("Press A to dodge the bullet!");
                Console.WriteLine("You need 10 or more to dodge the bullet!");
                Console.WriteLine("");
                Console.WriteLine("Since you have the stun grenade, you may use it to skip the dodge entirely!");
                Console.WriteLine("Press S to use the stun grenade!");
                AvenueResult();
            }
        }

        public void AvenueResult()
        {
            Random rnd = new Random();
            int result;

            result = rnd.Next(1, 20);

            string choiceAvenue = Console.ReadLine();

            if(choiceAvenue == "a" || choiceAvenue == "A")
            {
                if (inventory[0].FindItem("Body Armor") == true)
                {
                    if (result >= 7)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(result);
                        Console.WriteLine("The shot hits your armor. The force of the bullet almost makes you trip, but you kept going!");
                        Intersection();
                    }

                    else
                    {
                        Console.WriteLine(result);
                        sniper.CopAttack();
                        Console.WriteLine("You have " + Player.GetHeatlth + " health left.");
                        Console.WriteLine("The sniper bullet hits you in the arm! But you managed to get away before he can fire again!");
                        Intersection();
                    }
                }

                if (inventory[0].FindItem("Body Armor") == false)
                {
                    if (result >= 10)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(result);
                        Console.WriteLine("The shot barely misses your body, causing you to run even faster.");
                        Intersection();
                    }

                    else
                    {
                        Console.WriteLine(result);
                        sniper.CopAttack();
                        Console.WriteLine("You have " + Player.GetHeatlth + " health left.");
                        Console.WriteLine("The sniper bullet hits you in the arm! But you managed to get away before he can fire again!");
                        Intersection();
                    }
                }

            }

            if (choiceAvenue == "s" || choiceAvenue == "S")
            {
                inventory[0] = null;
                Console.WriteLine("You throw the stun grenade into the air! It explodes right into the sniper's scope, blinding him!");
                Console.WriteLine("You use this opportunity to run away!");
                Intersection();
            }

            if (choiceAvenue == "h" || choiceAvenue == "H")
            {
                Player.Heal();
                Console.WriteLine("Press A to dodge the bullet.");
                AvenueResult();
            }

            if (choiceAvenue == "i" || choiceAvenue == "I")
            {
                Console.WriteLine("");
                checkInventory();
                Console.WriteLine("Press A to dodge the shot!");
                AvenueResult();
            }

        }

        public void Intersection()
        {
            Console.WriteLine("");
            Console.WriteLine("You run out of the avenue into the streets. The intersection splits into 2 paths, and you must choose.");
            Console.WriteLine("Press 1 to go left, or press 2 to go right.");
            Console.WriteLine("");

            int choiceStreet = Convert.ToInt32(Console.ReadLine());

            if (choiceStreet == 1)
            {
                LeftStreet();
            }

            if (choiceStreet == 2)
            {
                RightStreet();
            }

            if (choiceStreet != 1 && choiceStreet != 2)
            {
                Console.WriteLine("");
                Console.WriteLine("Invalid choice, please enter either 1 or 2.");
                Console.WriteLine("");
                FirstChoice();
            }

            else
            {
                Console.WriteLine("Invalid choice, please press 1 or 2.");
            }
        }

        public void LeftStreet()
        {
            Console.WriteLine("");
            Console.WriteLine("You took the left turn of the intersection.");
            Console.WriteLine("However, you come face to face with a SWAT member, you have to take him out!");
            Console.WriteLine("Press H to heal yourself.");
            Console.WriteLine("Press I to check your inventory.");

            if (inventory[0].FindItem("Body Armor") == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press A to attack, you need more than 10 to land your shot!");
                Console.WriteLine("Since you have the body armor, his first attack will not hit!");
                Console.WriteLine("");
                LSResult();
            }

            if (inventory[0].FindItem("Stun Grenade") == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press A to attack, you need more than 10 to land your shot!");
                Console.WriteLine("");
                Console.WriteLine("Since you have the stun grenade, you may use it for a guaranteed killshot!");
                Console.WriteLine("Press S to use the stun grenade!");
                Console.WriteLine("");
                LSResult();
            }

            if(inventory[0].FindItem("Body Armor") == false && inventory[0].FindItem("Stun Grenade") == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Press A to attack, you need more than 10 to land your shot!");
                LSResult();
            }
        }

        public void LSResult()
        {
            Random rnd = new Random();
            int result;

            bool haveArmor = false;
            bool isHit = false;

            result = rnd.Next(1, 20);

            string choiceLStreet = Console.ReadLine();

            if (inventory[0].FindItem("Body Armor") == true && isHit == false)
            {
                haveArmor = true;
            }

            if (choiceLStreet == "a" || choiceLStreet == "A")
            {
                if (result > 10)
                {
                    Console.WriteLine(result);
                    Console.WriteLine("You shot the SWAT officer right in the head, he's dead on the spot.");
                    Console.WriteLine("You noticed he has a tear gas grenade on his vest, you decided to grab it.");

                    if (inventory[0]  != null)
                    {
                        inventory[1] = new Node("Tear Gas Grenade");
                    }

                    else
                    {
                        inventory[0] = new Node("Tear Gas Grenade");
                    }

                    EndResult();
                }

                if (result <= 10)
                {
                    Console.WriteLine("");
                    Console.WriteLine(result);
                    Console.WriteLine("Your shot hit the SWAT officer's armor!");
                    swat.CopAttack();


                    if (isHit == false)
                    {
                        Console.WriteLine("The SWAT officer hit your armor, you took no damage!.");
                        Console.WriteLine("He realizes what you are wearing and adjusted his aim.");
                        isHit = true;
                    }

                    Console.WriteLine("You have " + Player.GetHeatlth + " health left.");
                    Console.WriteLine("Press A to attack, you need more than 10 to land your shot!");
                    Console.WriteLine("Press H to heal yourself.");
                    Console.WriteLine("");
                    LSResult();
                }
            }

            if (choiceLStreet == "s" || choiceLStreet == "S")
            {
                inventory[0] = null;
                Console.WriteLine("You throw the stun grenade at the SWAT officer, blinding him!");
                Console.WriteLine("You use this opportunity to quickly shoot him, his corpse falls onto the ground!");
                inventory[0] = new Node("Tear Gas Grenade");

                EndResult();
            }

            if (choiceLStreet == "h" || choiceLStreet == "H")
            {
                Player.Heal();
                Console.WriteLine("Press A to attack, you need more than 10 to land your shot!");
                LSResult();
            }

            if (choiceLStreet == "i" || choiceLStreet == "I")
            {
                Console.WriteLine("");
                checkInventory();
                Console.WriteLine("Press A to attack, you need more than 10 to land your shot!");
                LSResult();
            }
        }

        public void RightStreet()
        {
            Console.WriteLine("");
            Console.WriteLine("You took the right turn of the intersection.");
            Console.WriteLine("You came across an empty SWAT van with bodies of police officers around it. Your friends definitely came through here.");
            Console.WriteLine("You poke inside an see armor-piercing bullets, compaitble with your gun. So you take it.");

            if (inventory[0] != null)
            {
                inventory[1] = new Node("Armor-Piercing Rounds");
            }

            if (inventory[0] == null)
            {
                inventory[0] = new Node("Armor-Piercing Rounds");
            }

            EndResult();
        }

        public void End()
        {
            Console.WriteLine("");
            Console.WriteLine("You come across a heavily armored police officer, he must be hit twice to be killed!");
            Console.WriteLine("Press H to heal yourself.");
            Console.WriteLine("Press I to check your inventory.");

            if (inventory[0].FindItem("Body Armor") == true && inventory[1].FindItem("Armor-Piercing Rounds") == true)
            {
                Console.WriteLine(""); 
                Console.WriteLine("Press A to attack, you need more than 11 to land your shot!");
                Console.WriteLine("Since you have armor-piercing bullets, you have greater chance to hit him!");
                Console.WriteLine("Since you have the body armor, his first attack will not hit!");
                Console.WriteLine("");
            }

            if (inventory[0].FindItem("Body Armor") == true && inventory[1].FindItem("Tear Gas Grenade") == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press A to attack, you need more than 8 to land your shot!");
                Console.WriteLine("Since you have the body armor, his first attack will not hit!");
                Console.WriteLine("Since you have the tear gas grenade, you can land a successful hit by using it!");
                Console.WriteLine("Press T to use the tear gas grenade!");
                Console.WriteLine("");
            }

            if (inventory[0].FindItem("Stun Grenade") == true && inventory[1].FindItem("Armor-Piercing Rounds") == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press A to attack, you need more than 11 to land your shot!");
                Console.WriteLine("Since you have armor-piercing bullets, you have greater chance to hit him!");
                Console.WriteLine("Since you have the stun grenade, you can land a successful hit by using it!");
                Console.WriteLine("Press S to use the stun grenade!");
                Console.WriteLine("");
            }

            if (inventory[0].FindItem("Stun Grenade") == true && inventory[1].FindItem("Tear Gas Grenade") == true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press A to attack, you need more than 8 to land your shot!");
                Console.WriteLine("Since you have the stun grenade, you can land a successful hit by using it!");
                Console.WriteLine("Press S to use the stun grenade!");
                Console.WriteLine("Since you have the tear gas grenade, you can land a successful hit by using it!");
                Console.WriteLine("Press T to use the tear gas grenade!");
                Console.WriteLine("");
            }

            if (inventory[0].FindItem("Tear Gas Grenade") == true && inventory[1] == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Since you have the tear gas grenade, you can land a successful hit by using it!");
                Console.WriteLine("Press T to use the tear gas grenade!");
                Console.WriteLine("");
            }

            if (inventory[0].FindItem("Body Armor") == true && inventory[1] == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Press A to attack, you need more than 11 to land your shot!");
                Console.WriteLine("Since you have armor-piercing bullets, you have greater chance to hit him!");
                Console.WriteLine("Since you have the body armor, his first attack will not hit!");
                Console.WriteLine("");
            }
        }

        public void EndResult()
        {
            Console.WriteLine("");
            Console.WriteLine("You see your escape vehicle in the distance, and you run for it!");
            Console.WriteLine("You managed to escape the cops with some bags full of cash!");
            Console.WriteLine("");

            checkInventory();
        }

        public void checkInventory()
        {
            Player.BandagesLeft();

            Console.WriteLine("As for your inventory, you have...");

            if (inventory[0] == null)
            {
                Console.WriteLine("....nothing else.");
                Console.WriteLine("");
            }

            else
            {
                inventory[0].Traverse();
                Console.WriteLine("");
            }
        }
    }
}