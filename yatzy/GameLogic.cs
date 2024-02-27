namespace yatzy
{
    internal class GameLogic
    {
        private Dice dice;
        private int currentPlayerIndex;
        private List<Player> players;

        private bool gameOver = false;

        public GameLogic(List<Player> players)
        {
            this.players = players;
            dice = new Dice();
            currentPlayerIndex = 0;
        }

        public void StartGame()
        {
            while (!gameOver)
            {
                Player currentPlayer = players[currentPlayerIndex];
                Console.Clear();
                Console.WriteLine($"It is {currentPlayer.Name}'s turn: ");
                TakeTurn();
                currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            }
        } 

        private void TakeTurn()
        {
            Console.Write("Press Enter to roll the dice. \n");
            Console.ReadLine();
            int[] diceValues = dice.Roll();
            Console.WriteLine($"You roll: {string.Join(", ", diceValues)}");
            Console.Write("Do you want to re-roll any of the dice? (y/n): ");
            string reroll = Console.ReadLine();
            if (reroll == "y")
            {
                int[] diceToReroll = Reroll();

                dice.Reroll(ref diceValues, diceToReroll);
                Console.WriteLine($"You roll: {string.Join(", ", diceValues)}");
                Console.Write("Do you want to re-roll any of the dice? (y/n): ");
                reroll = Console.ReadLine();
                if (reroll == "y")
                {
                    diceToReroll = Reroll();

                    int[] newDiceValues = dice.Reroll(ref diceValues, diceToReroll);
                    Console.WriteLine($"You roll: {string.Join(", ", newDiceValues)}");

                    diceValues = newDiceValues;
                }
            }
            ChooseScore(diceValues);
            Console.Write("\nPress enter to continue.");
            Console.ReadLine();

            
        }

        private int[] Reroll()
        {
            Console.Write("Choose the dice to re-roll: ");
            string[] diceChoice = Console.ReadLine().Split(",");
            int[] diceToReroll = new int[diceChoice.Length];

            for (int i = 0; i < diceChoice.Length; i++)
            {
                diceToReroll[i] = int.Parse(diceChoice[i]);
            }
            return diceToReroll;
        }

        private void ChooseScore(int[] diceValues)
        {
            
            bool isScoreSet = false;

            while (!isScoreSet)
            {
                Console.WriteLine("Choose where to score: ");
                players[currentPlayerIndex].ShowScoreboard();
                int choice = int.Parse(Console.ReadLine());

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
                        
                        if (players[currentPlayerIndex].scoreboard.Fours == -1){
                            Console.WriteLine("Four's");
                            players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 4);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 5:
                       
                        if (players[currentPlayerIndex].scoreboard.Fives == -1){
                            Console.WriteLine("Five's");
                            players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 5);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 6:
                       
                        if (players[currentPlayerIndex].scoreboard.Sixes == -1){
                            Console.WriteLine("Six's");
                            players[currentPlayerIndex].scoreboard.UpdateUpperBoard(diceValues, 6);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 7:
                        
                        if (players[currentPlayerIndex].scoreboard.OnePair == -1){
                            Console.WriteLine("One Pair");
                            players[currentPlayerIndex].scoreboard.UpdateOnePair(diceValues);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 8:
                        
                        if (players[currentPlayerIndex].scoreboard.TwoPairs == -1){
                            Console.WriteLine("Two Pairs");
                            players[currentPlayerIndex].scoreboard.UpdateTwoPair(diceValues);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 9:
                       
                        if (players[currentPlayerIndex].scoreboard.ThreeOfKind == -1){
                            Console.WriteLine("Three of a Kind");
                            players[currentPlayerIndex].scoreboard.UpdateThreeOfKind(diceValues);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 10:
                       
                        if (players[currentPlayerIndex].scoreboard.FourOfKind == -1){
                            Console.WriteLine("Four of a Kind");
                            players[currentPlayerIndex].scoreboard.UpdateFourOfKind(diceValues);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 11:
                        
                        if (players[currentPlayerIndex].scoreboard.SmallStraight == -1){
                            Console.WriteLine("Small Straight");
                            players[currentPlayerIndex].scoreboard.UpdateSmallStraight(diceValues);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 12:
                        
                        if (players[currentPlayerIndex].scoreboard.BigStraight == -1){
                            Console.WriteLine("Big Stragiht");
                            players[currentPlayerIndex].scoreboard.UpdateBigStraight(diceValues);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 13:
                        
                        if (players[currentPlayerIndex].scoreboard.Chance == -1) {
                            Console.WriteLine("Chance");
                            players[currentPlayerIndex].scoreboard.UpdateChance(diceValues);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    case 14:
                        
                        if (players[currentPlayerIndex].scoreboard.Yahtzee == -1)
                        {
                            Console.WriteLine("Yahtzee!");
                            players[currentPlayerIndex].scoreboard.UpdateYahtzee(diceValues);
                            isScoreSet = true;
                            break;
                        }
                        goto default;

                    default:
                        Console.WriteLine("You can't choose this one again!");
                        break;
                }
            }
            
           
            players[currentPlayerIndex].ShowScoreboard();
        }
    }
}