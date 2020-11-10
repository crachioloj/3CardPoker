using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeCardPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();

            Console.WriteLine("Please enter game data:" + "\r\n");
            string header = Console.ReadLine();
            sb.AppendLine(header);

            if (!int.TryParse(header.Trim(), out int playerCount) || playerCount <= 0 || playerCount >= 24)
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            else if (playerCount == 0)
            {
                return;
            }

            for (int i = 0; i < playerCount; i++)
            {
                var line = Console.ReadLine();
                sb.AppendLine(line);
            }

            var input = sb.ToString();
            var (info, error) = InputProcessor.GetGameInfoFromStringInput(input);

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine($"Invalid input: {error}");
                return;
            }

            var game = new Game(info);


            Console.WriteLine();
            Console.WriteLine("Winner(s):");
            Console.WriteLine(game.DetermineWinner());
        }
    }
}
