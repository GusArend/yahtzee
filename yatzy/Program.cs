namespace yatzy
{
    internal class Program
    {
       
        private static void Main(string[] args)
        {
            
            List<Player> players = new List<Player>();
            GameLogic gameLogic = new GameLogic(players);
            Art art = new Art();
            
           
            Console.WriteLine(art.yahtzee);

            Console.Write("\nPress Enter to start.");
            Console.ReadLine();

            game();
           
            void game()
            {
                Console.Write("How many players? ");
                int playerCount = 0;
                while (playerCount == 0)
                {
                    try
                    {
                        playerCount = int.Parse(Console.ReadLine());
                        for (int i = 0; i < playerCount; i++)
                        {
                            Console.Write("Player{0} Enter name: ", i + 1);
                            string name = Console.ReadLine();
                            players.Add(new Player(name));
                        }
                    } 
                    catch (FormatException e)
                    {
                        Console.WriteLine("Enter only numbers");
                        playerCount = 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Something went wrong!");
                        playerCount = 0;
                    }

                }
              
                gameLogic.StartGame();

                List<string> winners = new List<string>();
                int highestScore = 0;
                Console.Clear();
                Console.WriteLine(art.scoreBoard);

                foreach (Player player in players)
                {
                    Console.WriteLine($"{player.Name}'s total score is: {player.scoreboard.TotalScore}");

                    if (player.scoreboard.TotalScore > highestScore)
                    {
                        winners.Clear();
                        winners.Add(player.Name);
                        highestScore = player.scoreboard.TotalScore;
                    }
                    else if (player.scoreboard.TotalScore == highestScore)
                    {
                        winners.Add(player.Name);
                    }
                }

                if (winners.Count == 1)
                {
                    Console.WriteLine($"\nThe winner is {winners[0]}!\n");
                }
                else if (winners.Count > 1)
                {
                    Console.WriteLine($"\n{string.Join(" and ", winners)} are tied for the winning position.");
                }



                Console.Write("PLay Again? (y/n): ");
                string playAgain = Console.ReadLine();
                if (playAgain == "y")
                {
                    players.Clear();
                    gameLogic.Rounds = 0;
                    gameLogic.gameOver = false;
                    Console.Clear();
                    game();
                }
                
            }

            
        }
    }
}