namespace yatzy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Player> players = new List<Player>();
            GameLogic gameLogic = new GameLogic(players);

            string yahtzee = " /$$     /$$        /$$         /$$                                 \r\n|  $$   /$$/       | $$        | $$                                 \r\n \\  $$ /$$//$$$$$$ | $$$$$$$  /$$$$$$  /$$$$$$$$  /$$$$$$   /$$$$$$ \r\n  \\  $$$$/|____  $$| $$__  $$|_  $$_/ |____ /$$/ /$$__  $$ /$$__  $$\r\n   \\  $$/  /$$$$$$$| $$  \\ $$  | $$      /$$$$/ | $$$$$$$$| $$$$$$$$\r\n    | $$  /$$__  $$| $$  | $$  | $$ /$$ /$$__/  | $$_____/| $$_____/\r\n    | $$ |  $$$$$$$| $$  | $$  |  $$$$//$$$$$$$$|  $$$$$$$|  $$$$$$$\r\n    |__/  \\_______/|__/  |__/   \\___/ |________/ \\_______/ \\_______/";
            Console.WriteLine(yahtzee);

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