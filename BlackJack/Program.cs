using BlackJack;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("★☆★☆ブラックジャックへようこそ！★☆★☆");

        Casio casio = new Casio();
        casio.StartGame();

        Console.ReadLine();
    }
}