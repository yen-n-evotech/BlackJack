using System.Text;

namespace BlackJack
{
    /// <summary>
    /// Playerクラスは、プレイヤーとディーラーの両方に使用されます。
    /// </summary>
    internal class Player 
    {
        /// <summary>
        /// 手札のカードリスト
        /// </summary>
        public List<Card> Hand { get; set; } = new List<Card>();  
        
        /// <summary>
        /// プレーヤーまたはディーラーの手札にカードを追加メソッド
        /// </summary>
        /// <param name="card">カード</param>
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        /// <summary>
        /// Rankに対応するValueを返却するメソッド
        /// </summary>
        /// <param name="rank">カードのランク</param>
        /// <returns>カードの値</returns>
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

        /// <summary>
        /// 手札カードの合計値を計算するメソッド
        /// </summary>
        /// <returns>手札カードの合計値</returns>
        public int GetHandValue()
        {
            int value = 0;
            foreach (Card card in Hand)
            {
                value += GetCardValue(card.Rank);
            }
            return value;
        }

        /// <summary>
        /// 手札を表示するメソッド
        /// </summary>
        /// <param name="hand">手札カード</param>
        /// <returns>手札</returns>
        public string ShowCards(List<Card> hand)
        {
            StringBuilder cardString = new StringBuilder();
            foreach (Card card in hand)
            {
                cardString.Append($"{card.Type}の{card.Rank}、");
            }

            // 最後の読点を削除する（ある場合）
            if (cardString.Length > 0)
            {
                cardString.Length--;
            }
            return cardString.ToString();
        }
    }
}