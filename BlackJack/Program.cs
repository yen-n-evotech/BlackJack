using BlackJack;

class Program
{
    static void Main(string[] args)
    {        
        Console.WriteLine("★☆★☆　ブラックジャックへようこそ！　★☆★☆");

        bool KeepPlaying = true;
        while (KeepPlaying)
        {
            Casio casio = new Casio();
            casio.StartGame();

            //もう一度プレー
            Console.WriteLine(Line);
            Console.WriteLine("ゲームをリスタートしますか。リスタートしたい場合は Y を、終了したい場合は任意のキーを入力してください！");
            string answer = Console.ReadLine().ToLower();
            KeepPlaying = (answer == "y");
        }
        Console.WriteLine(Line);
        Console.WriteLine("★☆★☆　ゲームを終了しました！★☆★☆");
        Console.ReadLine();
    }
    public const string Line = "-------------------------------------------------";
}