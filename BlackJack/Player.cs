using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player 
    {
        public List<Card> Hand { get; set; } = new List<Card>();
        
        //プレーヤーまたはディーラーの手札にカードを追加
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        // Rankに対応するValueを返却する
        public int GetCardValue(string rank)
        {
            switch (rank)
            {
                case "A":
                    return 1;
                case "J":
                case "Q":
                case "K":
                    return 10;
                default:
                    return int.Parse(rank);
            }
        }

        //手札カードの合計値を計算
        public int GetHandValue()
        {
            int value = 0;
            foreach (Card card in Hand)
            {
                value += GetCardValue(card.Rank);
            }
            return value;
        }

        //手札をリセットして、新ゲームをする
        public void ResetHand()
        {
            Hand.Clear();
        }

    }
}
