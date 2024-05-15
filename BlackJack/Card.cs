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
        public Card(string type, string rank, int value)
        {
            Type = type;
            Rank = rank;
            Value = value;
        }
    }
}