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
        private Deck Deck;
        private Player Dealer;
        private Player Player;

        public const string Line = "-------------------------------------------------";
        public Casio()
        {
            Deck = new Deck();  //Deckクラスのインスタンス
            Deck.Shuffle();

            Dealer = new Player(); //Playerクラスのインスタンス
            Player = new Player(); //Playerクラスのインスタンス
        }

        //ゲームをスタート
        public void StartGame()
        {
            Console.WriteLine("\nゲームを開始します");

            //playerと dealerはカードを引く
            Player.AddCardToHand(Deck.GetCard());
            Player.AddCardToHand(Deck.GetCard());
            Dealer.AddCardToHand(Deck.GetCard());
            Dealer.AddCardToHand(Deck.GetCard());

            //プレーヤーの手札を表示
            Console.Write("あなたの引いたカード: ");
            string playerCard = "";
            foreach (Card card in Player.Hand)
            {
                playerCard += $"{card.Type}の{card.Rank}、";
            }
            playerCard = playerCard.Remove(playerCard.Length - 1);
            Console.WriteLine(playerCard);

            int value = Player.GetHandValue();
            Console.WriteLine($"あなたの現在の得点は{value}です。\n");

            //ディーラーの手札を表示
            Console.Write("ディーラーの引いたカード: ");
            Console.WriteLine($"{Dealer.Hand[0].Type}の{Dealer.Hand[0].Rank}");
            Console.WriteLine("ディーラーの2枚目のカードは裏向きです。");

            SetPlayerTurn();            
            ShowResults();

            //手札をリセット
            Player.ResetHand();
            Dealer.ResetHand();

         
        }
        //プレーヤーのターン

        public void ConfirmKeepPlaying()
        {
            Console.WriteLine(Line);
            Console.WriteLine("カードを引きますか。引く場合は Y を、引かない場合は N を入力してください！");
        }
        public void SetPlayerTurn()
        {
            int value = Player.GetHandValue();
            ConfirmKeepPlaying();

            //プレーヤーがヒットするかスタンドするかを選択
            while (true)
            {                
                string choice = Console.ReadLine().ToLower();
                if (choice == "y") //ヒット
                {
                    //カードを引いてdeckに追加
                    Card card = Deck.GetCard();
                    Player.AddCardToHand(card);

                    //プレーヤーが引いたカードを表示
                    Console.WriteLine($"あなたが引いたカード: {card.Type}の{card.Rank}");

                    value += card.Value;
                    Console.WriteLine($"あなたの現在の得点は{value}です。");

                    //プレーヤーの合計値が22以上になら、burstになる
                    if (Player.GetHandValue() >= 22)
                    {
                        Console.WriteLine("プレイヤーはバーストしたら、ディーラーがカードを引きません。");
                        break;
                    }
                    else
                    {
                        ConfirmKeepPlaying(); 
                    }
                }

                else if (choice == "n")　//スタンド
                {
                    Console.WriteLine(Line);
                    Console.WriteLine("あなたの番が終了したのでディーラーの番になります。\r\nディーラーは得点が17点以上になるまでカードを引きます。");
                    SetDealerTurn();
                    break;
                }                
            }
        }

        //ディーラーのターン
        public void SetDealerTurn()
        {
           int value = Dealer.GetHandValue();
            Console.WriteLine($"\n裏向きの2枚目のカードは{Dealer.Hand[1].Type}の{Dealer.Hand[1].Rank}でした。");
            Console.WriteLine($"ディーラーの現在の得点は{value}です。");
            while (true)
            {
                
                if (Dealer.GetHandValue() < 17)
                {
                    Card card = Deck.GetCard();
                    Dealer.AddCardToHand(card);
                    
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
        public void ShowResults()
        {
            Console.WriteLine("\r\nゲームが終了しました。\r\n");
            Console.WriteLine("結果");
            Console.WriteLine(Line);
            ShowPlayerCards();
            Console.WriteLine(Line);
            ShowDealerCards();
            Console.WriteLine(Line);
            GetResults(); 

        }
        private void ShowPlayerCards()
        {
            Console.WriteLine("あなた");
            Console.Write("  カード: ");
            Console.WriteLine(ShowCards(Player.Hand));
            Console.WriteLine($"  得点  ： {Player.GetHandValue()}点");
        }
        private void ShowDealerCards()
        {
            Console.WriteLine("ディーラー");
            Console.Write("  カード: ");
            Console.WriteLine(ShowCards(Dealer.Hand));
            Console.WriteLine($"  得点  ： {Dealer.GetHandValue()}点");
        }

        private string ShowCards(List<Card> hand)
        {
            StringBuilder cardString = new StringBuilder();
            foreach (Card card in hand)
            {
                cardString.Append($"{card.Type}の{card.Rank}、");
            }
            // Xóa dấu phẩy cuối cùng nếu có
            if (cardString.Length > 0)
            {
                cardString.Length--;
            }
            return cardString.ToString();
        }

            //勝敗を判断

        public bool? DetermineWinner()
        {
            if (Player.GetHandValue() > 21)
            {
                return false;
            }
            else if (Dealer.GetHandValue() > 21)
            {
                return true;
            }
            else if (Player.GetHandValue() > Dealer.GetHandValue())
            {
                return true;
            }
            else if (Player.GetHandValue() == Dealer.GetHandValue())
            {
                return null; // 引き分け
            }
            else
            {
                return false;
            }
        }

        public void GetResults()
        {
            bool? result = DetermineWinner();
            if (result == true)
            {
                Console.WriteLine("あなたの勝ちです！");
            }
            else if (result == false)
            {
                Console.WriteLine("あなたの負けです！");
            }
            else
            {
                Console.WriteLine("引き分けで終わりました！");
            }
        }
    }
}
