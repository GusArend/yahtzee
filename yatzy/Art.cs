﻿
namespace yatzy
{
    public class Art
    {
        public string yahtzee =
            " /$$     /$$        /$$         /$$                                 \r\n" +
            "|  $$   /$$/       | $$        | $$                                 \r\n" +
            " \\  $$ /$$//$$$$$$ | $$$$$$$  /$$$$$$  /$$$$$$$$  /$$$$$$   /$$$$$$ \r\n" +
            "  \\  $$$$/|____  $$| $$__  $$|_  $$_/ |____ /$$/ /$$__  $$ /$$__  $$\r\n" +
            "   \\  $$/  /$$$$$$$| $$  \\ $$  | $$      /$$$$/ | $$$$$$$$| $$$$$$$$\r\n" +
            "    | $$  /$$__  $$| $$  | $$  | $$ /$$ /$$__/  | $$_____/| $$_____/\r\n" +
            "    | $$ |  $$$$$$$| $$  | $$  |  $$$$//$$$$$$$$|  $$$$$$$|  $$$$$$$\r\n" +
            "    |__/  \\_______/|__/  |__/   \\___/ |________/ \\_______/ \\_______/";

        public string[] scoreBoard =
            [
            "  /$$$$$$                                          /$$                                           /$$",
            " /$$__  $$                                        | $$                                          | $$",
            "| $$  \\__/  /$$$$$$$  /$$$$$$   /$$$$$$   /$$$$$$ | $$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$   /$$$$$$$",
            "|  $$$$$$  /$$_____/ /$$__  $$ /$$__  $$ /$$__  $$| $$__  $$ /$$__  $$ |____  $$ /$$__  $$ /$$__  $$",
            " \\____  $$| $$      | $$  \\ $$| $$  \\__/| $$$$$$$$| $$  \\ $$| $$  \\ $$  /$$$$$$$| $$  \\__/| $$  | $$",
            " /$$  \\ $$| $$      | $$  | $$| $$      | $$_____/| $$  | $$| $$  | $$ /$$__  $$| $$      | $$  | $$",
            "|  $$$$$$/|  $$$$$$$|  $$$$$$/| $$      |  $$$$$$$| $$$$$$$/|  $$$$$$/|  $$$$$$$| $$      |  $$$$$$$",
            " \\______/  \\_______/ \\______/ |__/       \\_______/|_______/  \\______/  \\_______/|__/       \\_______/"
            ];

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
    