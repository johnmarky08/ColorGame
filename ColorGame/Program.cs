namespace ColorGame
{
    internal class Program
    {
        public static string[] colors = { "RED", "BLUE", "YELLOW", "WHITE", "GREEN", "PINK" };
        public static int currentBalance = 100;
        public static int bet = 0;
        public static string chosenColor = "";
        public static int wonBet = 0;
        public static bool chosen = false;
        public static bool beted = false;

        static void Main()
        {
            Console.WriteLine("===========");
            Console.WriteLine("COLOR GAME");
            Console.WriteLine("===========\n");

            Console.WriteLine("Current Balance: " + Convert.ToString(currentBalance) + "\n\n");

            while (!chosen)
            {
                if ((chosenColor == colors[0]) || (chosenColor == colors[1]) || (chosenColor == colors[2]) || (chosenColor == colors[3]) || (chosenColor == colors[4]) || (chosenColor == colors[5]))
                {
                    chosen = true;
                }
                else
                {
                    Console.WriteLine("Pick Your Color: ");
                    chosenColor = Console.ReadLine();
                    chosenColor = chosenColor.ToUpper();
                }
            }

            while (!beted)
            {
                try
                {
                    if ((bet > 0) && (bet <= currentBalance))
                    {
                        beted = true;
                    }
                    else
                    {
                        Console.Write("Place Your Bet: ");
                        bet = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch
                {
                    Console.WriteLine("Something Went Wrong! Try Again!");
                }
            }

            Random random = new Random();

            string[] dC = {
                colors[random.Next(0, colors.Length)],
                colors[random.Next(0, colors.Length)],
                colors[random.Next(0, colors.Length)]
            };

            if ((dC[0] == dC[1]) && (dC[1] == dC[2])) wonBet = bet * 3;
            else if ((dC[0] == dC[1]) || (dC[0] == dC[2]) || (dC[1] == dC[2])) wonBet = bet * 2;
            else wonBet = 0;

            Console.WriteLine("Drawn Colors:");
            Console.WriteLine("First Color: " + dC[0]);
            Console.WriteLine("Second Color: " + dC[1]);
            Console.WriteLine("Third Color: " + dC[2]);

            Console.WriteLine("\nYour Color: " + chosenColor);
            Console.WriteLine("\nYour Bet: " + bet);

            Console.Beep();
            Console.Beep();
            Console.Beep();

            currentBalance -= bet;
            currentBalance += wonBet;

            Console.WriteLine("\n\nWon Bet: " + wonBet);
            Console.WriteLine("\nCurrent Balance: " + currentBalance);
            Console.WriteLine("\n\nWant To Play Again? Y/N");

            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.Clear();
                bet = 0;
                chosenColor = "";
                wonBet = 0;
                chosen = false;
                beted = false;
                Main();
            }
        }
    }
}
