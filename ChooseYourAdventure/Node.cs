using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure
{
    internal class Node
    {
        public string playerItems;
        public Node m_next;
        public Node(string items)
        {
            playerItems = items;
        }

        public void Traverse()
        {
            Console.WriteLine(playerItems);
            if (m_next != null)
            {
                m_next.Traverse();
            }
        }
        public bool FindItem(string itemToFind)
        {
            bool found = false;

            if(playerItems.Contains(itemToFind)) 
            {
                Console.WriteLine(itemToFind);
                return true;
            }

            if (m_next != null)
            {
                found = m_next.FindItem(itemToFind);
                
            }

            return found;   
        }
    }
}
