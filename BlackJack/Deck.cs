namespace BlackJack
{
    /// <summary>
    /// 山札を表すクラス
    /// </summary>
    internal class Deck  
    {
        /// <summary>
        /// カードリスト
        /// </summary>
        private List<Card> CardsList = new List<Card>();

        /// <summary>
        /// 山札コンストラクタ
        /// </summary>
        public Deck()
        {
            string[] type = {"ハート","ダイヤ","スペード","クラブ"};
            string[] rank = {"A", "2", "3", "4", "5", "6", "7", "8", "9","10", "J", "Q", "K" };
            int[] value = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            // カードをcreateしてdeckに追加
            for (int i = 0; i < type.Length; i++)
            {
                for (int j = 0; j < rank.Length; j++)
                {
                    Card card = new Card(type[i], rank[j], value[j]); 
                    CardsList.Add(card);
                }
            }
        }

        /// <summary>
        /// カードをシャッフル
        /// </summary>
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = CardsList.Count - 1; i > 0; i--)
            {
                int j = random.Next(i+1);
                Card temp = CardsList[j];
                CardsList[j] = CardsList[i];
                CardsList[i] = temp;
            }
        }

        /// <summary>
        /// カードを引いて、deckでそのカードを削除するメソッド
        /// </summary>
        /// <returns>カード</returns>
        public Card GetCard()
        {
            Card card = CardsList[0];
            CardsList.RemoveAt(0);
            return card;
        }        
    }
}