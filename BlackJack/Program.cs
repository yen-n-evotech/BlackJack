using BlackJack;

public class Program
{
    static void Main(string[] args)
    {        
        Console.WriteLine("★☆★☆ ブラックジャックへようこそ！ ★☆★☆");
        bool KeepPlaying = true;
        while (KeepPlaying)
        {
            Control control = new Control();
            control.StartGame();
            KeepPlaying = AskToRestart();
        }
        ShowGoodbyeMessage();
    }

    /// <summary>
    /// リスタートしたいか確認するメソッド
    /// </summary>
    /// <returns>リセットするか確認メッセージ</returns>
    private static bool AskToRestart()
    {
        Console.WriteLine(ConstString.SeparatorLine);
        Console.WriteLine("ゲームをリスタートしますか。リスタートしたい場合は Y を、終了したい場合は任意のキーを入力してください！");
        string answer = Console.ReadLine().ToLower();
        return (answer == "y");
    }

    /// <summary>
    /// Goodbyeメッセージを表示するメソッド
    /// </summary>
    private static void ShowGoodbyeMessage()
    {
        Console.WriteLine(ConstString.SeparatorLine);
        Console.WriteLine("★☆★☆ ゲームを終了しました！ ★☆★☆");
    }
}

/// <summary>
/// ConstStringクラス
/// </summary>
public static class ConstString
{
    /// <summary>
    /// 区切り線の定数 
    /// </summary>
    public const string SeparatorLine = "-------------------------------------------------";
}