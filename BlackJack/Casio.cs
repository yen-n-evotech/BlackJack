using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            Console.WriteLine("ゲームを開始します");

            //playerと dealerはカードを引く
            player.AddCardToHand(deck.GetCards());
            player.AddCardToHand(deck.GetCards());
            dealer.AddCardToHand(deck.GetCards());           
            dealer.AddCardToHand(deck.GetCards());

            //プレーヤーの手札を表示
            Console.Write("あなたの引いたカード: ");
            string playerCard = "";
            foreach (Card card in player.Hand)
            {
                playerCard += $"{card.Type}の{card.Rank}、";
            }
            playerCard = playerCard.Remove(playerCard.Length - 1);
            Console.WriteLine(playerCard);

            //ディーラーの手札を表示
            Console.Write("ディーラーの引いたカード: ");
            Console.WriteLine($"{dealer.Hand[0].Type}の{dealer.Hand[0].Rank}");
            Console.WriteLine("ディーラーの2枚目のカードは分かりません。");

            int value = player.GetHandValue();
            Console.WriteLine($"あなたの現在の得点は{value}です。");

            //プレーヤーのターン
            while (true)
            {
                //プレーヤーがヒットするかスタンドするかを選択
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("カードを引きますか。引く場合は Y を、引かない場合は N を入力してください！");
                string choice = Console.ReadLine().ToLower();

                if (choice == "y" ) //ヒット
                {
                    //カードを引いてdeckに追加
                    Card card = deck.GetCards();
                    player.AddCardToHand(card);

                    //プレーヤーが引いたカードを表示
                    Console.WriteLine($"あなたが引いたカード:　{card.Type}の{card.Rank}");

                    value += card.Value;
                    Console.WriteLine($"あなたの現在の得点は{value}です。");

                    //プレーヤーの合計値が21以上になら、burstになる
                    if (player.GetHandValue() >= 21)
                    {
                        break;
                    }
                }

                else if (choice == "n")　//スタンド
                {
                    break;
                }
                else
                {
                    Console.WriteLine("無効な選択です。");
                }
            }

            //ディーラーのターン
            while (dealer.GetHandValue() < 17)
            {
                Card card = deck.GetCards();
                dealer.AddCardToHand(card);
            }

            //プレーヤーとディーラーの手札を表示
            Console.WriteLine("-------------------------------------------------");
            Console.Write("あなたのカード:　");
            playerCard = "";
            foreach (Card card in player.Hand)
            {
                playerCard += $"{card.Type}の{card.Rank}、" ;            
            }
            playerCard = playerCard.Remove(playerCard.Length - 1);
            Console.WriteLine(playerCard);
            Console.WriteLine($"あなたの得点：{player.GetHandValue()}点");

            Console.WriteLine("-------------------------------------------------");
            Console.Write("ディーラーのカード:　");
            string dealerCard = "";
            foreach (Card card in dealer.Hand)
            {
                dealerCard += $"{card.Type}の{card.Rank}、";
            }
            dealerCard = dealerCard.Remove(dealerCard.Length - 1);
            Console.WriteLine(dealerCard);
            Console.WriteLine($"ディーラーの得点：{dealer.GetHandValue()}点");

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

            //手札をリセット
            player.ResetHand();
            dealer.ResetHand();

            //もう一度プレー
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("ゲームをリスタートしますか。リスタートしたい場合は Y を、終了したい場合は任意のキーを入力してください！");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                StartGame();
            }
            else
            {
                Console.WriteLine("★☆★☆　ゲームを終了しました！★☆★☆");
            }
        }
    }
}
