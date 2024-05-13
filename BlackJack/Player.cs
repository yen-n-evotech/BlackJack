﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player 
    {
        public List<Card> Hand { get; set; } = new List<Card>(5);
        
        //プレーヤーまたはディーラーの手札にカードを追加
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        //手札カードの合計値を計算
        public int GetHandValue()
        {
            int value = 0;
            foreach (Card card in Hand)
            {
                switch(card.Rank) 
                {
                    case "A":
                        value += 1;
                        break;
                    case "J":
                        value += 10;
                        break;
                    case "Q":
                        value += 10;
                        break;
                    case "K":
                        value += 10;
                        break;
                    default:
                        value += int.Parse(card.Rank);
                        break;
                }
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
