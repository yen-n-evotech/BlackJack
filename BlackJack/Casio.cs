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
            Console.WriteLine("\nゲームを開始します");

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

            int value = player.GetHandValue();
            Console.WriteLine($"あなたの現在の得点は{value}です。\n");

            //ディーラーの手札を表示
            Console.Write("ディーラーの引いたカード: ");
            Console.WriteLine($"{dealer.Hand[0].Type}の{dealer.Hand[0].Rank}");
            Console.WriteLine("ディーラーの2枚目のカードは裏向きです。");

            SetPlayerTurn();            
            GetResults();
            ResetGame();
        }
        //プレーヤーのターン
        public void SetPlayerTurn()
        {
            int value = player.GetHandValue();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("カードを引きますか。引く場合は Y を、引かない場合は N を入力してください！");

            //プレーヤーがヒットするかスタンドするかを選択
            while (true)
            {                
                string choice = Console.ReadLine().ToLower();
                if (choice == "y") //ヒット
                {
                    //カードを引いてdeckに追加
                    Card card = deck.GetCards();
                    player.AddCardToHand(card);

                    //プレーヤーが引いたカードを表示
                    Console.WriteLine($"あなたが引いたカード: {card.Type}の{card.Rank}");

                    value += card.Value;
                    Console.WriteLine($"あなたの現在の得点は{value}です。");

                    //プレーヤーの合計値が21以上になら、burstになる
                    if (player.GetHandValue() >= 21)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("カードを引きますか。引く場合は Y を、引かない場合は N を入力してください！");
                    }
                }

                else if (choice == "n")　//スタンド
                {
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("あなたの番が終了したのでディーラーの番になります。\r\nディーラーは得点が17点以上になるまでカードを引きます。");
                    SetDealerTurn();
                    break;
                }                
            }
        }

        //ディーラーのターン
        public void SetDealerTurn()
        {
           int value = dealer.GetHandValue();
            Console.WriteLine($"\n裏向きの2枚目のカードは{dealer.Hand[1].Type}の{dealer.Hand[1].Rank}でした。");
            Console.WriteLine($"ディーラーの現在の得点は{value}です。");
            while (true)
            {
                
                if (dealer.GetHandValue() < 17)
                {
                    Card card = deck.GetCards();
                    dealer.AddCardToHand(card);
                    
                    //ディーラーが引いたカードを表示
                    Console.WriteLine($"ディーラーが引いたカード: {card.Type}の{card.Rank}");

                    value += card.Value;
                    Console.WriteLine($"ディーラーの現在の得点は{value}です。");
                }
                else
                {
                    Console.WriteLine("17点以上になったため、ディーラーの番を終了します。");
                    break;
                }
            }
        }

        //プレーヤーとディーラーの手札を表示
        public void GetResults()
        {
            Console.WriteLine("\r\nゲームが終了しました。\r\n");
            Console.WriteLine("結果\r\n-------------------------------------------------");
            Console.WriteLine("あなた");
            Console.Write("  カード: ");
            string playerCard = "";
            foreach (Card card in player.Hand)
            {
                playerCard += $"{card.Type}の{card.Rank}、";
            }
            playerCard = playerCard.Remove(playerCard.Length - 1);
            Console.WriteLine(playerCard);
            Console.WriteLine($"  得点  ： {player.GetHandValue()}点");

            Console.WriteLine("-------------------------------------------------\r\nディーラー");
            Console.Write("  カード: ");
            string dealerCard = "";
            foreach (Card card in dealer.Hand)
            {
                dealerCard += $"{card.Type}の{card.Rank}、";
            }
            dealerCard = dealerCard.Remove(dealerCard.Length - 1);
            Console.WriteLine(dealerCard);
            Console.WriteLine($"  得点  ： {dealer.GetHandValue()}点");
            Console.WriteLine("-------------------------------------------------");


            //勝敗を判断
            if (player.GetHandValue() > 21)
            {
                Console.WriteLine("あなたの負けです！");
            }
            else if (dealer.GetHandValue() > 21)
            {
                Console.WriteLine("あなたの勝ちです！");
            }
            else if (player.GetHandValue() > dealer.GetHandValue())
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

        public void ResetGame()
        { 
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
