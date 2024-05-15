namespace BlackJack
{
    /// <summary>
    /// カードを作成するクラス
    /// </summary>
    internal class Card
    {
        public string Type { get; set; }
        public string Rank { get; set; }
        public int Value { get; set; }

        /// <summary>
        /// カードのコンストラクタ
        /// </summary>
        /// <param name="type">カードの種類</param>
        /// <param name="rank">カードのランク</param>
        /// <param name="value">カードの値</param>
        public Card(string type, string rank, int value)
        {
            Type = type;
            Rank = rank;
            Value = value;
        }
    }
}