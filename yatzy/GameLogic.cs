namespace yatzy
{
    internal class GameLogic
    {
        Art art = new Art();
        private Dice dice;
        private int currentPlayerIndex;
        private List<Player> players;

        public bool gameOver = false;
        public int Rounds = 0;

      
        public GameLogic()
        {
            players = new List<Player>();
            dice = new Dice();
            currentPlayerIndex = 0;
           
        }

        public void StartGame()
        {
            choosePlayers();
            while (!gameOver)
            {
                
                Player currentPlayer = players[currentPlayerIndex];
                Console.Clear();
                currentPlayer.ShowScoreboard();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(art.yahtzee);
                Console.WriteLine($"\nIt is {currentPlayer.Name}'s turn: ");
                TakeTurn();
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
                if (Rounds / players.Count == 14)
                {
                    gameOver = true;
                }
                
            }
            endOfGame();
        } 

        private void choosePlayers()
        {
            Console.WriteLine(art.yahtzee);
            int playerCount = 0;
            while (playerCount == 0)
            {
                try
                {
                    Console.Write("\nHow many players? ");
                    playerCount = int.Parse(Console.ReadLine());
                    for (int i = 0; i < playerCount; i++)
                    {
                        Console.Write("Player{0} Enter name: ", i + 1);
                        string name = Console.ReadLine();
                        players.Add(new Player(name));
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter only numbers");
                    playerCount = 0;
                }
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong!");
                    playerCount = 0;
                }
            }
        }

        private void endOfGame()
        {
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



            Console.Write("PLay Again?(enter) or Exit(x): ");
            string playAgain = Console.ReadLine();
            if (playAgain != "x")
            {
                players.Clear();
                Rounds = 0;
                gameOver = false;
                Console.Clear();
                StartGame();
            }
        }

        private void TakeTurn()
        {
            Console.Write("Press Enter to roll the dice. \n");
            Console.ReadLine();
            int[] diceValues = dice.Roll();
            Console.WriteLine($"You roll: {string.Join(", ", diceValues)}");
            
            ShowDice(diceValues);
            

            Console.Write("\nDo you want to re-roll any of the dice? (y/n): ");
            string reroll = Console.ReadLine();
            if (reroll == "y")
            {
                
                int[] newDiceValues = dice.Reroll(ref diceValues);
                Console.WriteLine($"You roll: {string.Join(", ", diceValues)}");
                ShowDice(newDiceValues);
                Console.Write("Do you want to re-roll any of the dice? (y/n): ");
                reroll = Console.ReadLine();

                if (reroll == "y")
                {
                    newDiceValues = dice.Reroll(ref diceValues);
                    Console.WriteLine($"You roll: {string.Join(", ", newDiceValues)}");
                    ShowDice(newDiceValues);
                    diceValues = newDiceValues;
                    
                }
            }
            ChooseScore(diceValues);
            Console.SetCursorPosition(0, 44);
            Console.Write("\nPress any key to continue.");
            Console.ReadKey();
            Rounds++;

            
        }

        private void ShowDice(int[] diceValues)
        {
            (int left, int top) = Console.GetCursorPosition();

            for (int i = 0; i < 7; i++)
            {
                foreach (int value in diceValues)
                {
                    Console.SetCursorPosition(left, top);

                    Console.WriteLine(art.diceFace[value][i]);
                    left += 15;
                }
                left = 0;
                top += 1;
            }
        }

       
        private void ChooseScore(int[] diceValues)
        {
            
            bool isScoreSet = false;

            while (!isScoreSet)
            {
                Console.Write("Choose where to score: ");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:

                            if (players[currentPlayerIndex].scoreboard.Ones == -1)
                            {
                                Console.WriteLine("one's");
                                players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 1);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 2:

                            if (players[currentPlayerIndex].scoreboard.Twos == -1)
                            {
                                Console.WriteLine("Two's");
                                players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 2);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 3:

                            if (players[currentPlayerIndex].scoreboard.Threes == -1)
                            {
                                Console.WriteLine("Three's");
                                players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 3);
                                isScoreSet = true;
                                break;
                            }
                            goto default;


                        case 4:

                            if (players[currentPlayerIndex].scoreboard.Fours == -1)
                            {
                                Console.WriteLine("Four's");
                                players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 4);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 5:

                            if (players[currentPlayerIndex].scoreboard.Fives == -1)
                            {
                                Console.WriteLine("Five's");
                                players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 5);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 6:

                            if (players[currentPlayerIndex].scoreboard.Sixes == -1)
                            {
                                Console.WriteLine("Six's");
                                players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 6);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 7:

                            if (players[currentPlayerIndex].scoreboard.OnePair == -1)
                            {
                                Console.WriteLine("One Pair");
                                players[currentPlayerIndex].scoreboard.UpdateOnePair(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 8:

                            if (players[currentPlayerIndex].scoreboard.TwoPairs == -1)
                            {
                                Console.WriteLine("Two Pairs");
                                players[currentPlayerIndex].scoreboard.UpdateTwoPair(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 9:

                            if (players[currentPlayerIndex].scoreboard.ThreeOfKind == -1)
                            {
                                Console.WriteLine("Three of a Kind");
                                players[currentPlayerIndex].scoreboard.UpdateThreeOfKind(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 10:

                            if (players[currentPlayerIndex].scoreboard.FourOfKind == -1)
                            {
                                Console.WriteLine("Four of a Kind");
                                players[currentPlayerIndex].scoreboard.UpdateFourOfKind(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 11:
                            if (players[currentPlayerIndex].scoreboard.FullHouse == -1)
                            {
                                Console.WriteLine("Full House");
                                players[currentPlayerIndex].scoreboard.UpdateFullHouse(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 12:

                            if (players[currentPlayerIndex].scoreboard.SmallStraight == -1)
                            {
                                Console.WriteLine("Small Straight");
                                players[currentPlayerIndex].scoreboard.UpdateSmallStraight(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 13:

                            if (players[currentPlayerIndex].scoreboard.BigStraight == -1)
                            {
                                Console.WriteLine("Big Stragiht");
                                players[currentPlayerIndex].scoreboard.UpdateBigStraight(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 14:

                            if (players[currentPlayerIndex].scoreboard.Chance == -1)
                            {
                                Console.WriteLine("Chance");
                                players[currentPlayerIndex].scoreboard.UpdateChance(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        case 15:

                            if (players[currentPlayerIndex].scoreboard.Yahtzee == -1)
                            {
                                Console.WriteLine("Yahtzee!");
                                players[currentPlayerIndex].scoreboard.UpdateYahtzee(diceValues);
                                isScoreSet = true;
                                break;
                            }
                            goto default;

                        default:
                            if ((choice > 15) || (choice < 1))
                            {
                                Console.WriteLine("Choose a number between 1-15.");
                            } else
                            {
                                Console.WriteLine("You can't choose this one again!");
                            }
                            
                            break;
                    }
                } catch (FormatException)
                {
                    Console.WriteLine("Enter only numbers!");
                }

                
            }
            
           
            players[currentPlayerIndex].ShowScoreboard();
        }
    }
}