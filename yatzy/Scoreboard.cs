namespace yatzy
{
    public class Scoreboard
    {
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

        // public int[] TopBoard;
        public int TopBoardScore { get; set; }
        public int LowerBoardScore { get; set; }

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
                FullHouse = 40;
            }
            else
            {
                FullHouse = 0;
            }

            LowerBoardScore += FullHouse;
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
        }

        public void ShowScoreboard()
        {
            int secoundColStart = Console.WindowWidth / 2;
            scoreboard =
                [
                    $"1. 1’ere: Summen af alle terninger med 1.______________________________{(Ones == -1 ? "X" : Ones)}",
                    $"2. 2’ere: Summen af alle terninger med 2.______________________________{(Twos == -1 ? "X" : Twos)}",
                    $"3. 3’ere: Summen af alle terninger med 3.______________________________{(Threes == -1 ? "X" : Threes)}",
                    $"4. 4’ere: Summen af alle terninger med 4.______________________________{(Fours == -1 ? "X" : Fours)}",
                    $"5. 5’ere: Summen af alle terninger med 5.______________________________{(Fives == -1 ? "X" : Fives)}",
                    $"6. 6’ere: Summen af alle terninger med 6.______________________________{(Sixes == -1 ? "X" : Sixes)}",
                    $"                                                                           ",
                    $"Den samlede score for øverste del:_____________________________________{TopBoardScore}",
                    $"                                                                           ",
                    $"7. Et par: To terninger med samme værdi. Summen af terningerne.________{(OnePair == -1 ? "X" : OnePair)}",
                    $"8. To par: To forskellige par.Summen af terningerne.___________________{(TwoPairs == -1 ? "X" : TwoPairs)}",
                    $"9. Tre ens: Tre terninger med samme værdi. Summen af terningerne.______{(ThreeOfKind == -1 ? "X" : ThreeOfKind)}",
                    $"10. Fire ens:Fire terninger med samme værdi. Summen af terningerne.____{(FourOfKind == -1 ? "X" : FourOfKind)}",
                    $"11. Fuldt hus: Tre ens og et par. 40 point.____________________________{(FullHouse == -1 ? "X" : FullHouse)}",
                    $"12. Lille straight: Fem terninger i rækkefølge fra 1 til 5. 15 point.__{(SmallStraight == -1 ? "X" : SmallStraight)}",
                    $"13. Storestraight: Fem terninger i rækkefølge fra 2 til 6. 20 point.___{(BigStraight == -1 ? "X" : BigStraight)}",
                    $"14. Chancen: Summen af alle fem terninger._____________________________{(Chance == -1 ? "X" : Chance)}",
                    $"15. Yatzy: Fem terninger med samme værdi. 50 point.____________________{(Yahtzee == -1 ? "X" : Yahtzee)}",
                    $"                                                                           ",
                    $"Den samlede score for nederste del:____________________________________{LowerBoardScore}",
                ];
            
         
            for (int i = 0; i < scoreboard.Count(); i++)
            {
                Console.SetCursorPosition(secoundColStart, Console.CursorTop = 0+i);
                Console.WriteLine(scoreboard[i]);
                
            }
        }
    }
}