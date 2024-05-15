using System.Text;

namespace BlackJack
{/// <summary>
/// ゲームの進行を管理クラスです。
/// </summary>
    internal class Control
    {
        private Deck Deck;
        private Player Dealer;
        private Player Player;
        public const string Line = "-------------------------------------------------";
        public Control()
        {
            Deck = new Deck(); //Deckクラスのインスタンス
            Deck.Shuffle();
            Dealer = new Player(); //Playerクラスのインスタンス
            Player = new Player(); //Playerクラスのインスタンス
        }

        /// <summary>
        /// ゲームをスタート
        /// </summary>
        public void StartGame()
        {
            Console.WriteLine("\nゲームを開始します");
            // playerと dealerはカードを引く
            Player.AddCardToHand(Deck.GetCard());
            Player.AddCardToHand(Deck.GetCard());
            Dealer.AddCardToHand(Deck.GetCard());
            Dealer.AddCardToHand(Deck.GetCard());
            // プレーヤーの手札を表示
            Console.WriteLine("あなたの引いたカード: " + Player.ShowCards(Player.Hand));
            Console.WriteLine($"あなたの現在の得点は{Player.GetHandValue()}です。\n");
            // ディーラーの手札を表示
            Console.WriteLine("ディーラーの引いたカード: " + Player.ShowCards(new List<Card> { Dealer.Hand[0] }));
            Console.WriteLine("ディーラーの2枚目のカードは裏向きです。");
            SetPlayerTurn();
            ShowResults();
        }

        /// <summary>
        /// カードを引きたいか確認するメソード
        /// </summary>
        private void ConfirmKeepPlaying()
        {
            Console.WriteLine(Line);
            Console.WriteLine("カードを引きますか。引く場合は Y を、引かない場合は N を入力してください！");
        }

        /// <summary>
        /// プレーヤーのターン
        /// </summary>
        private void SetPlayerTurn()
        {
            int value = Player.GetHandValue();
            ConfirmKeepPlaying();
            // プレーヤーがヒットするかスタンドするかを選択
            while (true)
            {
                string choice = Console.ReadLine().ToLower();
                if (choice == "y") // ヒット
                {
                    // カードを引いてdeckに追加
                    Card card = Deck.GetCard();
                    Player.AddCardToHand(card);
                    // プレーヤーが引いたカードを表示
                    Console.WriteLine($"あなたが引いたカード: {card.Type}の{card.Rank}");
                    value += card.Value;
                    Console.WriteLine($"あなたの現在の得点は{value}です。");
                    // プレーヤーの合計値が22以上になら、burstになる
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
                else if (choice == "n") // スタンド
                {
                    Console.WriteLine(Line);
                    Console.WriteLine("あなたの番が終了したのでディーラーの番になります。\r\nディーラーは得点が17点以上になるまでカードを引きます。");
                    SetDealerTurn();
                    break;
                }
            }
        }

        /// <summary>
        /// ディーラーのターン
        /// </summary>
        private void SetDealerTurn()
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
                    // ディーラーが引いたカードを表示
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

        /// <summary>
        /// プレーヤーとディーラーの手札と勝敗を表示して結果を表示メソード
        /// </summary>
        private void ShowResults()
        {
            Console.WriteLine("\r\nゲームが終了しました。\r\n");
            Console.WriteLine("結果");
            Console.WriteLine(Line);
            ShowParticipantCards("あなた", Player);
            ShowParticipantCards("ディーラー", Dealer);
            GetResults();
        }

        /// <summary>
        /// プレーヤーまたはディーラーの手札を表示するメソード
        /// </summary>
        /// <param name="participant"></param>
        /// <param name="handHolder"></param>
        private void ShowParticipantCards(string participant, Player handHolder)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(participant);
            sb.Append("  カード: ");
            sb.AppendLine(handHolder.ShowCards(handHolder.Hand)); // ShowCards は Player クラスのメソッドと仮定
            sb.AppendLine($"  得点  ： {handHolder.GetHandValue()}点");
            sb.AppendLine(Line);
            Console.Write(sb.ToString());
        }

        // 勝敗の結果を表す enum
        private enum GameResult
        {
            Win,
            Lose,
            Draw
        }

        /// <summary>
        /// 勝敗を判断メソード
        /// </summary>
        /// <returns></returns>
        private GameResult? DetermineWinner()
        {
            if (Player.GetHandValue() > 21)
            {
                return GameResult.Lose;
            }
            else if (Dealer.GetHandValue() > 21)
            {
                return GameResult.Win;
            }
            else if (Player.GetHandValue() > Dealer.GetHandValue())
            {
                return GameResult.Win;
            }
            else if (Player.GetHandValue() == Dealer.GetHandValue())
            {
                return GameResult.Draw; // 引き分け
            }
            else
            {
                return GameResult.Lose;
            }
        }

        /// <summary>
        /// 勝敗を表示するメソッド
        /// </summary>
        private void GetResults()
        {
            GameResult? result = DetermineWinner();
            switch (result)
            {
                case GameResult.Win:
                    Console.WriteLine("あなたの勝ちです！");
                    break;
                case GameResult.Lose:
                    Console.WriteLine("あなたの負けです！");
                    break;
                case GameResult.Draw:
                    Console.WriteLine("引き分けで終わりました！");
                    break;
                default:
                    Console.WriteLine("結果が不明です。");
                    break;
            }
        }
    }
}