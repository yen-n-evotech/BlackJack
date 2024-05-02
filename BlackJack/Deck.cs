using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck
    {
        public List<Card> cardsList = new List<Card>();
        public Deck()
        {
            string[] type = {"heart","diamond","spade","clover"};
            string[] rank = { "A", "1", "2", "3", "4", "5", "6", "7", "8", "9","10", "J", "Q", "K" };
            int[] value = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            for (int i = 0; i < type.Length; i++)
            {
                for (int j = 0; j < rank.Length; j++)
                {
                    Card card = new Card(type[i], rank[j], value[j]);
                    cardsList.Add(card);
                }
            }
        }

        //Suffle cards
        public void Suffle()
        {
            Random random = new Random();
            for (int i = cardsList.Count - 1; i >= 0; i--)
            {
                int j = random.Next(i+1);
                Card temp = cardsList[j];
                cardsList[i] = cardsList[j];
                cardsList[j] = temp;
            }
        }


    }
}
