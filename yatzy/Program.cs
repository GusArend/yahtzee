namespace yatzy
{
    internal class Program
    {
       
        private static void Main(string[] args)
        {
            int Width = 150, Height = 40;
            List<Player> players = new List<Player>();
            GameLogic gameLogic = new GameLogic(players);
            Art art = new Art();
            Console.SetWindowSize(Width, Height);
           
            Console.WriteLine(art.yahtzee);

            Console.Write("\nPress Enter to start.");
            Console.ReadLine();

            game();
           
            void game()
            {
                Console.Write("How many players? ");
                int playerCount = int.Parse(Console.ReadLine());

                for (int i = 0; i < playerCount; i++)
                {
                    Console.Write("Player{0} Enter name: ", i + 1);
                    string name = Console.ReadLine();
                    players.Add(new Player(name));
                }
                gameLogic.StartGame();
            }

            
        }
    }
}