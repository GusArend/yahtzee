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

        public int[] Reroll(ref int[] diceValues, int[] diceToReroll)
        {
            foreach (int index in diceToReroll)
            {
                diceValues[index - 1] = random.Next(1, 7);
            }
            return diceValues;
        }
    }
}