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

            Console.WriteLine("Enter the number of players.");
            string header = Console.ReadLine();
            sb.AppendLine(header);

            if (!int.TryParse(header.Trim(), out int playerCount) || playerCount < 0)
            {
                Console.WriteLine("Invalid input.");
            }
            else
            {
                Console.WriteLine("Enter player data.");
            }

            for (int i = 0; i < playerCount; i++)
            {
                var line = Console.ReadLine();
                sb.AppendLine(line);
            }

            var input = sb.ToString();
            var info = InputProcessor.GetGameInfoFromStringInput(input);
            var game = new Game(info);

            Console.WriteLine("Winner(s):");
            Console.WriteLine(game.DetermineWinner());
        }
    }
}
