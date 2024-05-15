using BlackJack;

class Program
{
    public const string Line = "-------------------------------------------------";

    static void Main(string[] args)
    {        
        Console.WriteLine("★☆★☆　ブラックジャックへようこそ！　★☆★☆");
        bool KeepPlaying = true;
        while (KeepPlaying)
        {
            Control control = new Control();
            control.StartGame();
            KeepPlaying = AskToRestart();
        }
        GoodbyeMessage();
    }

    /// <summary>
    /// リスタートしかいか確認するメソード
    /// </summary>
    /// <returns></returns>
    private static bool AskToRestart()
    {
        Console.WriteLine(Line);
        Console.WriteLine("ゲームをリスタートしますか。リスタートしたい場合は Y を、終了したい場合は任意のキーを入力してください！");
        string answer = Console.ReadLine().ToLower();
        return (answer == "y");
    }

    /// <summary>
    /// Goodbyeメッセージを表示するメソード
    /// </summary>
    private static void GoodbyeMessage()
    {
        Console.WriteLine(Line);
        Console.WriteLine("★☆★☆　ゲームを終了しました！★☆★☆");
    }
}