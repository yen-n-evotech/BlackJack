using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Casio
    {
        private Deck deck;
        private Player dealer;
        private Player player;

        public Casio()
        {
            deck = new Deck();
            deck.Shuffle();

            dealer = new Player("Dealer");
            player = new Player("Player");
        }

        public void StartGame()
        {
            Console.WriteLine("Start Game!");

            //playerと dealerはカードを引く
            player.AddCardToHand(deck.GetCards());
            player.AddCardToHand(deck.GetCards());
            dealer.AddCardToHand(deck.GetCards());           
            dealer.AddCardToHand(deck.GetCards());

            Console.WriteLine("あなたの引いたカードは");
            foreach (Card card in player.Hand)
            {
                Console.WriteLine($"{card.Rank} {card.Type}");
            }
        }

   

        


     
    }
}
