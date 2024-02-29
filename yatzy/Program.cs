namespace yatzy
{
    internal class Program
    {
       
        private static void Main(string[] args)
        {
            
            GameLogic gameLogic = new GameLogic();
            Art art = new Art();
            
           
            Console.WriteLine(art.yahtzee);

            Console.Write("\nPress Enter to start.");
            Console.ReadLine();
            Console.Clear();

            gameLogic.StartGame();
        }
    }
}