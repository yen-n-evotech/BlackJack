using System.Text;

namespace BlackJack
{
    /// <summary>
    /// Playerクラスは、プレイヤーとディーラーの両方に使用されます。
    /// </summary>
    internal class Player 
    {
        public List<Card> Hand { get; set; } = new List<Card>();        
        /// <summary>
        /// プレーヤーまたはディーラーの手札にカードを追加メソード
        /// </summary>
        /// <param name="card"></param>
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        /// <summary>
        /// Rankに対応するValueを返却するメソード
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
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
        /// 手札カードの合計値を計算するメソード
        /// </summary>
        /// <returns></returns>
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
        /// 手札を表示するメソード
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
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