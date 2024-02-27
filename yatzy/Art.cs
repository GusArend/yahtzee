﻿
namespace yatzy
{
    public class Art
    {
        public string yahtzee = " /$$     /$$        /$$         /$$                                 \r\n|  $$   /$$/       | $$        | $$                                 \r\n \\  $$ /$$//$$$$$$ | $$$$$$$  /$$$$$$  /$$$$$$$$  /$$$$$$   /$$$$$$ \r\n  \\  $$$$/|____  $$| $$__  $$|_  $$_/ |____ /$$/ /$$__  $$ /$$__  $$\r\n   \\  $$/  /$$$$$$$| $$  \\ $$  | $$      /$$$$/ | $$$$$$$$| $$$$$$$$\r\n    | $$  /$$__  $$| $$  | $$  | $$ /$$ /$$__/  | $$_____/| $$_____/\r\n    | $$ |  $$$$$$$| $$  | $$  |  $$$$//$$$$$$$$|  $$$$$$$|  $$$$$$$\r\n    |__/  \\_______/|__/  |__/   \\___/ |________/ \\_______/ \\_______/";

        public Dictionary<int, string[]> diceFace = new Dictionary<int, string[]>();

        public Art()
        {
            diceFace.Add(1, ["+----------+", "|          |", "|          |", "|    ()    |", "|          |", "|          |", "+----------+"]);
            diceFace.Add(2, ["+----------+", "|  ()      |", "|          |", "|          |", "|          |", "|      ()  |", "+----------+"]);
            diceFace.Add(3, ["+----------+", "|  ()      |", "|          |", "|    ()    |", "|          |", "|      ()  |", "+----------+"]);
            diceFace.Add(4, ["+----------+", "|  ()  ()  |", "|          |", "|          |", "|          |", "|  ()  ()  |", "+----------+"]);
            diceFace.Add(5, ["+----------+", "|  ()  ()  |", "|          |", "|    ()    |", "|          |", "|  ()  ()  |", "+----------+"]);
            diceFace.Add(6, ["+----------+", "|  ()  ()  |", "|          |", "|  ()  ()  |", "|          |", "|  ()  ()  |", "+----------+"]);
        }
    }
           
        
    
}
    