namespace yatzy
{
    public class Scoreboard
    {
        Art art = new Art();
        public int Ones { get; set; }
        public int Twos { get; set; }
        public int Threes { get; set; }
        public int Fours { get; set; }
        public int Fives { get; set; }
        public int Sixes { get; set; }
        public int OnePair { get; set; }
        public int TwoPairs { get; set; }
        public int ThreeOfKind { get; set; }
        public int FourOfKind { get; set; }
        public int FullHouse { get; set; }
        public int SmallStraight { get; set; }
        public int BigStraight { get; set; }
        public int Chance { get; set; }
        public int Yahtzee { get; set; }

        public int TopBoardScore { get; set; }
        public int LowerBoardScore { get; set; }
        public int TotalScore { get; set; }

        public string[] scoreboard;

        public Scoreboard()
        {
            Ones = -1;
            Twos = -1;
            Threes = -1;
            Fours = -1;
            Fives = -1;
            Sixes = -1;
            OnePair = -1;
            TwoPairs = -1;
            ThreeOfKind = -1;
            FourOfKind = -1;
            FullHouse = -1;
            SmallStraight = -1;
            BigStraight = -1;
            Chance = -1;
            Yahtzee = -1;

        }

        public void UpdateUpperBoard(int[] diceValues, int num)
        {
            int sum = 0;
            foreach (int diceValue in diceValues)
            {
                if (diceValue == num)
                {
                    sum += diceValue;
                }
            }
            TopBoardScore += sum;
            TotalScore += sum;
            switch (num)
            {
                case 1: Ones = sum; break;
                case 2: Twos = sum; break;
                case 3: Threes = sum; break;
                case 4: Fours = sum; break;
                case 5: Fives = sum; break;
                case 6: Sixes = sum; break;
            }
            
        }

        

        public void UpdateOnePair(int[] diceValues)
        {
            var frequencies = new Dictionary<int, int>();
            int highestPairValue = 0;

            foreach (int value in diceValues)
            {
                if (!frequencies.ContainsKey(value))
                {
                    frequencies[value] = 0;
                }
                frequencies[value]++;
            }

            foreach (int value in frequencies.Keys)
            {
                if (frequencies[value] >= 2)
                {
                    highestPairValue = Math.Max(highestPairValue, value);
                }
            }
            OnePair = highestPairValue * 2;
            LowerBoardScore += OnePair;
            TotalScore += OnePair;
        }

        public void UpdateTwoPair(int[] diceValues)
        {
            var frequencies = new Dictionary<int, int>();
            int pairValue = 0;

            foreach (int value in diceValues)
            {
                if (!frequencies.ContainsKey(value))
                {
                    frequencies[value] = 0;
                }
                frequencies[value]++;
            }

            foreach (int value in frequencies.Keys)
            {
                if (frequencies[value] == 2)
                {
                    pairValue += (value * 2);
                }
            }
            TwoPairs = pairValue;
            LowerBoardScore += TwoPairs;
            TotalScore += TwoPairs;
        }

        public void UpdateThreeOfKind(int[] diceValues)
        {
            var frequencies = new Dictionary<int, int>();
            int pairValue = 0;

            foreach (int value in diceValues)
            {
                if (!frequencies.ContainsKey(value))
                {
                    frequencies[value] = 0;
                }
                frequencies[value]++;
            }

            foreach (int value in frequencies.Keys)
            {
                if (frequencies[value] >= 3)
                {
                    pairValue += (value * 3);
                }
            }
            ThreeOfKind = pairValue;
            LowerBoardScore += ThreeOfKind;
            TotalScore += ThreeOfKind;
        }

        public void UpdateFourOfKind(int[] diceValues)
        {
            var frequencies = new Dictionary<int, int>();
            int pairValue = 0;

            foreach (int value in diceValues)
            {
                if (!frequencies.ContainsKey(value))
                {
                    frequencies[value] = 0;
                }
                frequencies[value]++;
            }

            foreach (int value in frequencies.Keys)
            {
                if (frequencies[value] >= 4)
                {
                    pairValue += (value * 4);
                }
            }
            FourOfKind = pairValue;
            LowerBoardScore += FourOfKind;
            TotalScore += FourOfKind;
        }

        public void UpdateFullHouse(int[] diceValues)
        {
            var frequencies = new Dictionary<int, int>();
            bool three = false;
            bool pair = false;

            foreach (int value in diceValues)
            {
                if (!frequencies.ContainsKey(value))
                {
                    frequencies[value] = 0;
                }
                frequencies[value]++;
            }

            foreach (int value in frequencies.Keys)
            {
                if (frequencies[value] == 3)
                {
                    three = true;
                }
                else if (frequencies[value] == 2)
                {
                    pair = true;
                }
            }
            if (three && pair)
            {
                FullHouse = 30;
            }
            else
            {
                FullHouse = 0;
            }

            LowerBoardScore += FullHouse;
            TotalScore += FullHouse;
        }

        public void UpdateSmallStraight(int[] diceValues)
        {
            int score = 0;

            if (diceValues.Contains(1))
                if (diceValues.Contains(2))
                    if (diceValues.Contains(3))
                        if (diceValues.Contains(4))
                            if (diceValues.Contains(5))
                                score = 15;

            SmallStraight = score;
            LowerBoardScore += SmallStraight;
            TotalScore += SmallStraight;
        }

        public void UpdateBigStraight(int[] diceValues)
        {
            int score = 0;

            if (diceValues.Contains(2))
                if (diceValues.Contains(3))
                    if (diceValues.Contains(4))
                        if (diceValues.Contains(5))
                            if (diceValues.Contains(6))
                                score = 20;

            BigStraight = score;
            LowerBoardScore += BigStraight;
            TotalScore += BigStraight;
        }

        public void UpdateChance(int[] diceValues)
        {
            int score = 0;
            foreach (int diceValue in diceValues)
            {
                score += diceValue;
            }
            Chance = score;
            LowerBoardScore += Chance;
            TotalScore += Chance;
        }

        public void UpdateYahtzee(int[] diceValues)
        {
            var frequencies = new Dictionary<int, int>();
            int score = 0;
            foreach (int value in diceValues)
            {
                if (!frequencies.ContainsKey(value))
                {
                    frequencies[value] = 0;
                }
                frequencies[value]++;
            }

            foreach (int value in frequencies.Keys)
            {
                if (frequencies[value] == 5)
                {
                    score = 50;
                }
            }
            Yahtzee = score;
            LowerBoardScore += Yahtzee;
            TotalScore += Yahtzee;
        }

        public void ShowScoreboard()
        {
            int secoundColStart = Console.WindowWidth / 2;
            scoreboard =
                [
                    $"1. Ones: Sum of all dice showing 1.____________________________________{(Ones == -1 ? "X" : Ones)}",
                    $"2. Twos: Sum of all dice showing 2.____________________________________{(Twos == -1 ? "X" : Twos)}",
                    $"3. Threes: Sum of all dice showing 3.__________________________________{(Threes == -1 ? "X" : Threes)}",
                    $"4. Fours: Sum of all dice showing 4.___________________________________{(Fours == -1 ? "X" : Fours)}",
                    $"5. Fives: Sum of all dice showing 5.___________________________________{(Fives == -1 ? "X" : Fives)}",
                    $"6. Sixes: Sum of all dice showing 6.___________________________________{(Sixes == -1 ? "X" : Sixes)}",
                    $"",
                    $"Total score for upper section:_________________________________________{TopBoardScore}",
                    $"",
                    $"7. One Pair: Two dice with the same value. Sum of the dice.____________{(OnePair == -1 ? "X" : OnePair)}",
                    $"8. Two Pairs: Two different pairs. Sum of the dice.____________________{(TwoPairs == -1 ? "X" : TwoPairs)}",
                    $"9. Three of a Kind: Three dice with the same value. Sum of the dice.___{(ThreeOfKind == -1 ? "X" : ThreeOfKind)}",
                    $"10. Four of a Kind: Four dice with the same value. Sum of the dice.____{(FourOfKind == -1 ? "X" : FourOfKind)}",
                    $"11. Full House: Three of a Kind and a Pair. 30 points._________________{(FullHouse == -1 ? "X" : FullHouse)}",
                    $"12. Small Straight: Five dice in sequence from 1 to 5. 15 points.______{(SmallStraight == -1 ? "X" : SmallStraight)}",
                    $"13. Large Straight: Five dice in sequence from 2 to 6. 20 points.______{(BigStraight == -1 ? "X" : BigStraight)}",
                    $"14. Chance: Sum of all five dice.______________________________________{(Chance == -1 ? "X" : Chance)}",
                    $"15. Yahtzee: Five dice with the same value. 50 points._________________{(Yahtzee == -1 ? "X" : Yahtzee)}",
                    $"",
                    $"Total score for lower section:_________________________________________{LowerBoardScore}",
                    $"",
                    $"Total score:___________________________________________________________{TotalScore}",
                ];
            
            for (int i = 0; i < art.scoreBoard.Length; i++)
            {
                Console.SetCursorPosition(secoundColStart, Console.CursorTop = 0 + i);
                Console.WriteLine(art.scoreBoard[i]);
            }
         
            for (int i = 0; i < scoreboard.Count(); i++)
            {
                Console.SetCursorPosition(secoundColStart, Console.CursorTop = art.scoreBoard.Length + 1 + i);
                Console.WriteLine(scoreboard[i]);
            }
        }
    }
}