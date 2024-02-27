namespace yatzy
{
    public class Player
    {
        public string Name { get; set; }
        public Scoreboard scoreboard;

        public Player(string name)
        {
            Name = name;
            scoreboard = new Scoreboard();
        }

        public void ShowScoreboard()
        {
            scoreboard.ShowScoreboard();
        }
    }
}