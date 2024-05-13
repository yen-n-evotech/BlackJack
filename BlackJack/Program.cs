using BlackJack;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("★☆★☆　ブラックジャックへようこそ！　★☆★☆");
        while (true)
        {
            Casio casio = new Casio();
            casio.StartGame();

            //もう一度プレー
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("ゲームをリスタートしますか。リスタートしたい場合は Y を、終了したい場合は任意のキーを入力してください！");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                casio.StartGame();
            }
            else
            {
                Console.WriteLine("★☆★☆　ゲームを終了しました！★☆★☆");
                break;
            }
        }

       Console.ReadLine();
    }
}