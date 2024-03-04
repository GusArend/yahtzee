namespace yatzy
{
    internal class Program
    {
       
        private static void Main(string[] args)
        {
            
            GameLogic gameLogic = new GameLogic();
            Art art = new Art();
            Console.WriteLine(art.yahtzee);

            int width = Console.WindowWidth;
            int height = Console.WindowHeight;

            while ((height < 50) || (width < 180))
            {
                Console.WriteLine("\nPlease go to full-screen or zoom out using 'ctrl -'");
                Console.WriteLine("Press enter to test window size.");
                Console.ReadLine();
                height = Console.WindowHeight;
                width = Console.WindowWidth;

            }
            Console.Write("\n\nPress Enter to start.");
            Console.ReadLine();
            Console.Clear();

            gameLogic.StartGame();
        }
    }
}