﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Casio //ゲームの進行を管理
    {
        private Deck deck;  
        private Player dealer;　
        private Player player;　

        public Casio()
        {
            deck = new Deck();  //Deckクラスのインスタンス
            deck.Shuffle();

            dealer = new Player("Dealer"); //Playerクラスのインスタンス
            player = new Player("Player"); //Playerクラスのインスタンス
        }

        //ゲームをスタート
        public void StartGame()
        {
            Console.WriteLine("Start Game!");

            //playerと dealerはカードを引く
            player.AddCardToHand(deck.GetCards());
            player.AddCardToHand(deck.GetCards());
            dealer.AddCardToHand(deck.GetCards());           
            dealer.AddCardToHand(deck.GetCards());

            //プレーヤーの手札を表示
            Console.WriteLine("あなたの引いたカードは");
            foreach (Card card in player.Hand)
            {
                Console.WriteLine($"{0} of {1}, {card.Rank} {card.Type}");
            }

            //ディーラーの手札を表示
            Console.WriteLine("ディーラーのカードは:");
            Console.WriteLine($"{0}of{1}, {dealer.Hand[0].Rank} {dealer.Hand[0].Type}");
            Console.WriteLine("ディーラーの2枚目のカードは分かりません。");

            //プレーヤーのターン
            while (true)
            {
                //プレーヤーがヒットするかスタンドするかを選択
                Console.WriteLine("カードを引きますか。引く場合は y を、引かない場合は n を入力してください！");
                string choice = Console.ReadLine();

                if (choice == "y" )
                {
                    //カードを引いてdeckに追加
                    Card card = deck.GetCards();
                    player.AddCardToHand(card);

                    //プレーヤーの手札を表示
                    Console.WriteLine("あなたが引いたカードは");
                    foreach (Card playercard in player.Hand)
                    {
                        Console.WriteLine($"{0} of {1}, {playercard.Rank} {playercard.Type}");
                    }

                    //プレーヤーの合計値が21以上になら、burstになる
                    if (player.GetHandValue() >= 21)
                    {
                        break;
                    }
                }

                else if (choice == "n")
                {
                    break;
                }
            }

            //ディーラーのターン
            while (dealer.GetHandValue() < 17)
            {
                Card card = deck.GetCards();
                dealer.AddCardToHand(card);
            }

            //プレーヤーとディーラーの手札を表示
            Console.WriteLine("あなたのカードは");
            foreach (Card card in player.Hand)
            {
                Console.WriteLine("{0}of{1}", card.Rank, card.Type);
            }
            Console.WriteLine("あなたの得点：{0}", player.GetHandValue());

            Console.WriteLine("ディーラーのカードは");
            foreach (Card card in dealer.Hand)
            {
                Console.WriteLine("{0}of{1}", card.Rank, card.Type);
            }
            Console.WriteLine("ディーラーの得点は：{0}", dealer.GetHandValue());

            //勝敗を判断
            if (player.GetHandValue() > 21)
            {
                Console.WriteLine("あなたの負けです！");
            }
            else if (dealer.GetHandValue() > 21)
            {
                Console.WriteLine("あなたの勝ちです！");
            }
            else if (player.GetHandValue() > dealer.GetHandValue() )
            {
                Console.WriteLine("あなたの勝ちです！");
            }
            else if (player.GetHandValue() == dealer.GetHandValue())
            {
                Console.WriteLine("引き分けで終わりました！");
            }
            else
            {
                Console.WriteLine("あなたの負けです！");
            }
        }
    }
}
