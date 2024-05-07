using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Deck  //山札を表すクラス
    {
        public List<Card> cardsList = new List<Card>();
        public Deck()
        {
            string[] type = {"ハート","ダイヤ","スペード","クラブ"};
            string[] rank = { "A", "2", "3", "4", "5", "6", "7", "8", "9","10", "J", "Q", "K" };
            int[] value = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            //カードをcreateしてdeckに追加
            for (int i = 0; i < type.Length; i++)
            {
                for (int j = 0; j < rank.Length; j++)
                {
                    Card card = new Card(type[i], rank[j], value[j]); 
                    cardsList.Add(card);
                }
            }
        }

        //カードをシャッフル
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = cardsList.Count - 1; i > 0; i--)
            {
                int j = random.Next(i+1);
                Card temp = cardsList[i];
                cardsList[i] = cardsList[j];
                cardsList[j] = temp;
            }
        }

        //カードを引いて、deckでそのカードを削除
        public Card GetCards()
        {
            Card card = cardsList[0];
            cardsList.RemoveAt(0);
            return card;
        }

        //残るカード数を数える
        public int GetRemainingCards()
        { 
            return cardsList.Count; 
        }
        
    }
}
