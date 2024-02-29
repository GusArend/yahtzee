namespace yatzy
{
    internal class Dice
    {
        private Random random;

        public Dice()
        {
            random = new Random();
        }

        public int[] Roll()
        {
            int[] diceValues = new int[5];

            for (int i = 0; i < 5; i++)
            {
                diceValues[i] = random.Next(1, 7);
            }
            return diceValues;
        }

        public int[] Reroll(ref int[] diceValues)
        {
            Console.Write("Choose the dice to re-roll: ");

            string[] diceChoice = [];
            int[] diceToReroll = [];

            while ((diceChoice.Length <= 0) || (diceToReroll.Length <= 0)) {
                try
                {
                    diceChoice = Console.ReadLine().Split(" ");
                    diceToReroll = new int[diceChoice.Length];
                    for (int i = 0; i < diceChoice.Length; i++)
                    {
                        diceToReroll[i] = int.Parse(diceChoice[i]);
                    }

                    foreach (int index in diceToReroll)
                    {
                        diceValues[index - 1] = random.Next(1, 7);
                    }
                } 
                catch (FormatException)
                {
                    Console.WriteLine("Please enter numbers (1-5) seperated by a space.");
                    diceChoice = [];
                    diceToReroll = [];
                } 
                catch (Exception)
                {
                    Console.WriteLine("Please enter numbers (1-5) seperated by a space.");
                    diceChoice = [];
                    diceToReroll = [];
                }
                
                
            }

            
            return diceValues;
        }
    }
}