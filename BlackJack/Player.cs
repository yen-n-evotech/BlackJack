using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player 
    {
         
        public Player(string name)
        { 
        }

        public List<Card> Hand = new List<Card>();
        
        
        public void AddCardToHand(Card card)
        {
            Console.WriteLine($"Playerのカードは{card}");
        }


    }
}
